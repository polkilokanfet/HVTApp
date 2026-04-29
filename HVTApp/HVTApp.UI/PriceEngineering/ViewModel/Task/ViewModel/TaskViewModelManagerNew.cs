using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using HVTApp.UI.Commands;
using HVTApp.UI.PriceEngineering.ViewModel;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceEngineering
{
    public class TaskViewModelManagerNew : TaskViewModelManager
    {
        /// <summary>
        /// Контейнер задач, в которую вложена эта задача
        /// </summary>
        private readonly TasksViewModelManager _tasksViewModelManager;

        private readonly List<DesignDepartment> _kitDepartments;

        public DelegateLogConfirmationCommand RemoveTaskCommand { get; }

        public DelegateLogCommand SelectDesignDepartmentCommand { get; }


        /// <summary>
        /// Для создания новой технико-стоимостной проработки по единицам продаж
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="salesUnits"></param>
        /// <param name="container"></param>
        /// <param name="tasksViewModelManager">Контейнер задач, в которую вложена эта задача</param>
        public TaskViewModelManagerNew(IUnityContainer container, IUnitOfWork unitOfWork, IEnumerable<SalesUnit> salesUnits, TasksViewModelManager tasksViewModelManager) 
            : this(container, unitOfWork, salesUnits.First().Product, 1)
        {
            _tasksViewModelManager = tasksViewModelManager;
            this.SalesUnits.AddRange(salesUnits.Select(salesUnit => new SalesUnitWithSignalToStartProductionWrapper(salesUnit)));
        }

        /// <summary>
        /// Для создания новой задачи по продукту
        /// </summary>
        /// <param name="container"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public TaskViewModelManagerNew(IUnityContainer container, IUnitOfWork unitOfWork, Product product, int amount) 
            : base(container, unitOfWork)
        {
            this.Model.ProductBlockEngineer = product.ProductBlock;
            this.Model.ProductBlockManager = product.ProductBlock;
            
            this.Amount = amount;

            _kitDepartments = product.DesignDepartmentsKits.Where(department => department.IsKitDepartment).ToList();
            this.DesignDepartment = GetDesignDepartment();
            
            ChildPriceEngineeringTasks = new ValidatableChangeTrackingCollection<TaskViewModel>(new List<TaskViewModel>());
            RegisterCollection(ChildPriceEngineeringTasks, Model.ChildPriceEngineeringTasks);
            
            foreach (var dependentProduct in product.DependentProducts)
            {
                var vm = new TaskViewModelManagerNew(container, unitOfWork, dependentProduct.Product, dependentProduct.Amount);
                this.ChildPriceEngineeringTasks.Add(vm);
                vm.Parent = this;
            }

            #region Commands

            RemoveTaskCommand = new DelegateLogConfirmationCommand(
                container.Resolve<IMessageService>(),
                "Вы уверены, что хотите удалить эту задачу из списка?",
                () =>
                {
                    _tasksViewModelManager?.RemoveChildTask(this);
                },
                () =>
                    _tasksViewModelManager != null &&
                    _tasksViewModelManager.AllowEditProps &&
                    UnitOfWork.Repository<PriceEngineeringTask>().GetById(this.Model.Id) == null);

            SelectDesignDepartmentCommand = new DelegateLogCommand(
                () =>
                {
                    var designDepartment = Container.Resolve<ISelectService>().SelectItem(_kitDepartments);
                    if (designDepartment != null)
                    {
                        this.DesignDepartment =
                            new DesignDepartmentEmptyWrapper(UnitOfWork.Repository<DesignDepartment>()
                                .GetById(designDepartment.Id));
                    }
                },
                () => IsEditMode && _kitDepartments.Any());

            #endregion

            //задача в процессе создания, нужно добавить соответствующий статус
            this.Statuses.Add(new PriceEngineeringTaskStatusEmptyWrapper(new PriceEngineeringTaskStatus { StatusEnum = ScriptStep.Create.Value }));
        }

        private DesignDepartmentEmptyWrapper GetDesignDepartment()
        {
            //если ТСП на ремкомплект
            if (_kitDepartments.Any())
            {
                var designDepartment = UnitOfWork.Repository<DesignDepartment>().GetById(_kitDepartments.First().Id);
                return new DesignDepartmentEmptyWrapper(designDepartment);
            }

            //если ТСП не на ремкомплект
            var department = UnitOfWork.Repository<DesignDepartment>().Find(designDepartment => designDepartment.ProductBlockIsSuitable(this.Model.ProductBlockEngineer)).FirstOrDefault();
            if (department != null)
            {
                return new DesignDepartmentEmptyWrapper(department);
            }

            return null;
        }
    }
}