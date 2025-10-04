using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;


namespace HVTApp.DataAccess
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IUnityContainer _container;

        public UnitOfWork(DbContext context, IUnityContainer container)
        {
            _context = context;
            _container = container;
            InitializeRepositories();
        }

        public IRepository<T> Repository<T>() where T : class, IBaseEntity
        {
            var repositoryFieldInfo = this.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)                                   
                .Single(fieldInfo => typeof(IRepository<T>)
                .IsAssignableFrom(fieldInfo.FieldType));

            return (IRepository<T>) repositoryFieldInfo.GetValue(this);
        }

        public UnitOfWorkOperationResult SaveChanges()
        {
            UnitOfWorkOperationResult result;
#if DEBUG
#else
            try
            {
#endif
#if DEBUG
                var entries = _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Unchanged) continue;
                    if (entry.State == EntityState.Deleted) continue;
                    Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
                    foreach (var property in entry.CurrentValues.PropertyNames)
                    {
                        Console.WriteLine($"  {property}: {entry.CurrentValues[property]}");
                    }
                }
#else
#endif
                //обновление момента обновления параметров
                var parametersIsUpdating = _context.ChangeTracker.Entries<Parameter>().Any(dbEntityEntry =>
                    dbEntityEntry.State == EntityState.Added ||
                    dbEntityEntry.State == EntityState.Modified ||
                    dbEntityEntry.State == EntityState.Deleted);
                var parameterRelationsIsUpdating = _context.ChangeTracker.Entries<ParameterRelation>().Any(dbEntityEntry =>
                    dbEntityEntry.State == EntityState.Added ||
                    dbEntityEntry.State == EntityState.Modified ||
                    dbEntityEntry.State == EntityState.Deleted);

                if (parametersIsUpdating || parameterRelationsIsUpdating)
                {
                    _container.Resolve<ILastUpdateMomentService>().SetLastUpdateMomentOfParameters();
                }

                _context.SaveChanges(); 
                result = new UnitOfWorkOperationResult();
#if DEBUG
#else
            }
            catch (Exception e)
            {
                result = new UnitOfWorkOperationResult(e);
                this.OnOperationFailedEvent(result);
                throw;
            }
#endif

            return result;
        }

        private void OnOperationFailedEvent(UnitOfWorkOperationResult unitOfWorkOperationResult)
        {
            string message = string.Empty;
            if (unitOfWorkOperationResult.Exception is DbEntityValidationException e)
            {
                foreach (var entityValidationResult in e.EntityValidationErrors)
                {
                    message += $"Entity of type \"{entityValidationResult.Entry.Entity.GetType().Name}\" in state \"{entityValidationResult.Entry.State}\" has the following validation errors:";
                    message += Environment.NewLine;

                    foreach (var ve in entityValidationResult.ValidationErrors)
                    {
                        message += $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";
                    }
                }
            }
            else
            {
                message = unitOfWorkOperationResult.Exception.PrintAllExceptions();
            }

            _container.Resolve<IMessageService>().Message(unitOfWorkOperationResult.Exception.GetType().Name, message);
            _container.Resolve<IHvtAppLogger>().LogError(unitOfWorkOperationResult.Exception.GetType().Name, unitOfWorkOperationResult.Exception);
        }

        public UnitOfWorkOperationResult SaveEntity<T>(T entity) where T : class, IBaseEntity
        {
            //проверяем, есть ли сущность в контексте
            if (this.Repository<T>().GetById(entity.Id) == null)
            {
                var result = this.Repository<T>().Add(entity);
                if (result.OperationCompletedSuccessfully == false)
                {
                    return result;
                }
            }

            //сохранение сущности в контекст
            return this.SaveChanges();
        }

        public UnitOfWorkOperationResult RemoveEntity<T>(T entity) where T : class, IBaseEntity
        {
            //проверяем, есть ли сущность в контексте
            var entityToRemove = this.Repository<T>().GetById(entity.Id);
            
            //если сущности и не было в контексте
            if (entityToRemove == null)
            {
                return new UnitOfWorkOperationResult();
            }

            var result = this.Repository<T>().Delete(entityToRemove);
            if (result.OperationCompletedSuccessfully == false)
            {
                return result;
            }

            //сохранение
            return this.SaveChanges();
        }

        public void Dispose()
        {
            this.DisposeRepositories();
            _context?.Dispose();
        }
    }
}
