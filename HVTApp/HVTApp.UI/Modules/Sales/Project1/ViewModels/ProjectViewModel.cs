using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using HVTApp.DataAccess;
using HVTApp.Infrastructure.Interfaces.Services.DialogService;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Services;
using HVTApp.Infrastructure.ViewModels;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Model.Wrapper;
using HVTApp.UI.Commands;
using HVTApp.UI.Modules.Sales.Project1.Commands;
using HVTApp.UI.Modules.Sales.Project1.Wrappers;
using HVTApp.UI.Modules.Sales.ViewModels.Groups;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;

namespace HVTApp.UI.Modules.Sales.Project1.ViewModels
{
    public class ProjectViewModel : ViewModelBaseCanExportToExcel
    {
        public ProjectWrapper1 ProjectWrapper { get; }

        public ProjectTypes ProjectTypes { get; private set; }

        private IProjectUnit _selectedUnit;
        private ProjectUnitProductIncludedGroup _selectedProjectUnitProductIncludedGroup;

        public IProjectUnit SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                if (_selectedUnit == value) return;
                _selectedUnit = value;
                SelectedUnitChanged?.Invoke();
                RaisePropertyChanged();
            }
        }

        public event Action SelectedUnitChanged;

        public ProjectUnitProductIncludedGroup SelectedProjectUnitProductIncludedGroup
        {
            get => _selectedProjectUnitProductIncludedGroup;
            set => SetProperty(ref _selectedProjectUnitProductIncludedGroup, value, () => SelectedProjectUnitProductIncludedGroupToSalesUnitCommand.RaiseCanExecuteChanged());
        }

        public RoundUpModule RoundUpModule { get; } = new RoundUpModule();

        #region Commands

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }

        public ICommand RoundUpCommand { get; }

        public ICommand SaveCommand { get; }


        /// <summary>
        /// Перенести оборудование в новый проект
        /// </summary>
        public MoveToNewProjectCommand MoveToNewProjectCommand { get; }

        /// <summary>
        /// Перенести оборудование в существующий проект
        /// </summary>
        public MoveToExistsProjectCommand MoveToExistsProjectCommand { get; }

        /// <summary>
        /// Включить услугу в спецификацию
        /// </summary>
        public ICommand IncludeServiceInSpecificationCommand { get; }

        public DelegateLogConfirmationCommand SelectedProjectUnitProductIncludedGroupToSalesUnitCommand { get; }

        #endregion

        /// <summary>
        /// Создание проекта
        /// </summary>
        /// <param name="container"></param>
        public ProjectViewModel(IUnityContainer container) : this(new Project
        {
            ProjectTypeId = GlobalAppProperties.Actual.DefaultProjectType.Id
        }, container)
        {
            ProjectWrapper.Manager = new UserEmptyWrapper(this.UnitOfWork.Repository<User>().GetById(GlobalAppProperties.User.Id));
        }

        /// <summary>
        /// Редактирование проекта
        /// </summary>
        /// <param name="project"></param>
        /// <param name="container"></param>
        public ProjectViewModel(Project project, IUnityContainer container) : base(container)
        {
            project = ((IProjectRepository)(UnitOfWork.Repository<Project>())).GetForEdit(project.Id) ?? project;
            ProjectWrapper = new ProjectWrapper1(project);
            ProjectTypes = new ProjectTypes(UnitOfWork, this.ProjectWrapper);

            var selectService = container.Resolve<ISelectService>();
            var dialogService = container.Resolve<IDialogService>();
            var getProductService = container.Resolve<IGetProductService>();
            var eventAggregator = container.Resolve<IEventAggregator>();
            var messageService = container.Resolve<IMessageService>();

            EditCommand = new EditProjectUnitCommand(UnitOfWork, selectService, dialogService, this, getProductService);
            AddCommand = new AddProjectUnitCommand(UnitOfWork, selectService, dialogService, this, getProductService);
            RemoveCommand = new RemoveProjectUnitCommand(this, messageService);

            MoveToExistsProjectCommand = new MoveToExistsProjectCommand(this, UnitOfWork, container);
            MoveToNewProjectCommand = new MoveToNewProjectCommand(this, container);

            IncludeServiceInSpecificationCommand = new IncludeServiceInSpecificationCommand(this, container);

            SaveCommand = new SaveProjectCommand(this.ProjectWrapper, UnitOfWork, eventAggregator);

            RoundUpCommand = new DelegateCommand(() =>
            {
                foreach (var projectUnit in this.ProjectWrapper.Units)
                {
                    projectUnit.Cost = RoundUpModule.RoundUp(projectUnit.Cost);
                    if (projectUnit.CostWithReserve.HasValue)
                        projectUnit.CostWithReserve = RoundUpModule.RoundUp(projectUnit.CostWithReserve.Value);
                }
            });

            SelectedProjectUnitProductIncludedGroupToSalesUnitCommand = new DelegateLogConfirmationCommand(
                messageService,
                () =>
                {
                    var target = this.SelectedProjectUnitProductIncludedGroup;
                    var projectUnit = new ProjectUnit(new SalesUnit());
                    projectUnit.CopyProperties(this.SelectedUnit);
                    projectUnit.Product = new ProductEmptyWrapper(target.Product);
                    projectUnit.ProductsIncluded.Clear();
                    projectUnit.Cost = container.Resolve<IPriceService>().GetPrice(projectUnit.Model, projectUnit.Model.RealizationDateCalculated, false).SumPriceTotal;

                    (new ProjectUnitAddViewModel(this.ProjectWrapper, projectUnit, UnitOfWork, selectService, getProductService, dialogService)).Add(projectUnit, target.Amount);

                    foreach (var projectUnitProductIncluded in target.Items.ToList())
                    {
                        foreach (var unit in this.ProjectWrapper.Units)
                        {
                            if (unit.ProductsIncluded.Remove(projectUnitProductIncluded))
                                break;
                        }
                    }
                }, 
                () => this.SelectedProjectUnitProductIncludedGroup != null);
        }

        /// <summary>
        /// Для переноса оборудования в существующий проект
        /// </summary>
        /// <param name="project"></param>
        /// <param name="container"></param>
        /// <param name="salesUnits"></param>
        public ProjectViewModel(Project project, IUnityContainer container, IEnumerable<SalesUnit> salesUnits) : this(project, container)
        {
            foreach (var salesUnit in salesUnits.Select(x => UnitOfWork.Repository<SalesUnit>().GetById(x.Id)))
            {
                salesUnit.Project = this.ProjectWrapper.Model;
                this.ProjectWrapper.Units.Add(new ProjectUnit(salesUnit));
            }
        }

        /// <summary>
        /// Для переноса оборудования в новый проект
        /// </summary>
        /// <param name="container"></param>
        /// <param name="salesUnits"></param>
        public ProjectViewModel(IUnityContainer container, IEnumerable<SalesUnit> salesUnits) : this(container)
        {
            foreach (var salesUnit in salesUnits.Select(x => UnitOfWork.Repository<SalesUnit>().GetById(x.Id)))
            {
                salesUnit.Project = this.ProjectWrapper.Model;
                this.ProjectWrapper.Units.Add(new ProjectUnit(salesUnit));
            }
        }
    }
}