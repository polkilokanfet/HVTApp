using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HVTApp.UI.Modules.Sales.ViewModels.Groups
{
    public abstract class UnitsContainer<TModel, TWrapper, TDetailsViewModel, TGroupsViewModel, TUnit, TAfterSaveModelEvent> : ViewModelBase
        where TModel : class, IBaseEntity
        where TWrapper : class, IWrapper<TModel>
        where TDetailsViewModel : IDetailsViewModel<TWrapper, TModel>
        where TGroupsViewModel : IGroupsViewModel<TUnit, TWrapper>
        where TAfterSaveModelEvent : PubSubEvent<TModel>, new()
    {

        //детали
        public TDetailsViewModel DetailsViewModel { get; }

        //группы юнитов
        public TGroupsViewModel GroupsViewModel { get; }

        public DelegateLogCommand SaveCommand { get; }


        public RoundUpModule RoundUpModule { get; } = new RoundUpModule();

        /// <summary>
        /// Округлить цены
        /// </summary>
        public DelegateLogCommand RoundUpCommand { get; }

        protected UnitsContainer(IUnityContainer container) : base(container)
        {
            DetailsViewModel = container.Resolve<TDetailsViewModel>();
            GroupsViewModel = container.Resolve<TGroupsViewModel>();

            SaveCommand = new DelegateLogCommand(
                SaveCommand_Execute,
                () =>
                {
                    //все сущности должны быть валидны
                    if (!GroupsViewModel.IsValid || !DetailsViewModel.Item.IsValid)
                        return false;
                    
                    //какая-то сущность должна быть изменена
                    return DetailsViewModel.Item.IsChanged || GroupsViewModel.IsChanged;
                });

            RoundUpCommand = new DelegateLogCommand(
                () =>
                {
                    GroupsViewModel.RoundUpGroupsCosts(RoundUpModule.RoundUpAccuracy);
                });
        }

        public virtual void Load(TModel model, bool isNew, object parameter = null)
        {
            //детали
            DetailsViewModel.Load(model, UnitOfWork);
            DetailsViewModel.Item.PropertyChanged += ItemOnPropertyChanged;

            //группы юнитов
            var units = GetUnits(model, parameter);
            GroupsViewModel.Load(units, DetailsViewModel.Item, UnitOfWork, isNew);
            GroupsViewModel.GroupChanged += OnGroupChanged;

            AfterUnitsLoading();

            SaveCommand.RaiseCanExecuteChanged();
        }

        public virtual void AfterUnitsLoading()
        {
        }

        /// <summary>
        /// Получение связанных с объектом юнитов
        /// </summary>
        /// <param name="model"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TUnit> GetUnits(TModel model, object parameter = null);

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void OnGroupChanged()
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public bool IsConfirmGoBackWithoutSaving { get; private set; } = false;

        protected virtual void SaveCommand_Execute()
        {
            //отписка от событий изменения строк с оборудованием
            this.GroupsViewModel.GroupChanged -= OnGroupChanged;

            GroupsViewModel.AcceptChanges();

            //добавляем сущность, если ее не существовало
            if (UnitOfWork.Repository<TModel>().GetById(DetailsViewModel.Item.Model.Id) == null)
                UnitOfWork.Repository<TModel>().Add(DetailsViewModel.Item.Model);

            DetailsViewModel.Item.AcceptChanges();
            Container.Resolve<IEventAggregator>().GetEvent<TAfterSaveModelEvent>().Publish(DetailsViewModel.Item.Model);

            //сохраняем
            try
            {
                UnitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Container.Resolve<IMessageService>().Message("Ошибка при сохранении", e.PrintAllExceptions());
            }

            //регистрация на события изменения строк с оборудованием
            this.GroupsViewModel.GroupChanged += OnGroupChanged;

            SaveCommand.RaiseCanExecuteChanged();
        }

        protected override void GoBackCommand_Execute()
        {
            //если придет запрос при несохраненных изменениях
            if (SaveCommand.CanExecute())
            {
                var dr = Container.Resolve<IMessageService>().ConfirmationDialog("Сохранение", "Сохранить сделанные изменения?", defaultNo:true);
                if(dr)
                    SaveCommand.Execute();
                else
                    IsConfirmGoBackWithoutSaving = true;
            }

            base.GoBackCommand_Execute();
        }
    }
}