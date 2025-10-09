using System;
using System.Collections.Generic;
using HVTApp.Model;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.UI.Modules.Sales.ViewModels.Groups;
using HVTApp.UI.ViewModels;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Groups.SimpleWrappers;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using HVTApp.DataAccess;
using System.Linq;
using System.Windows.Input;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.Services;
using HVTApp.UI.Commands;
using HVTApp.UI.TaskInvoiceForPayment1.ForManager;
using Prism.Commands;
using Prism.Regions;
using EnumerableExtensions = Microsoft.Practices.ObjectBuilder2.EnumerableExtensions;

namespace HVTApp.UI.Modules.Sales.ViewModels
{
    public class SpecificationViewModel : UnitsContainer<Specification, SpecificationWrapper, SpecificationDetailsViewModel, SpecificationUnitsGroupsViewModel, SalesUnit, AfterSaveSpecificationEvent>
    {
        /// <summary>
        /// Задача на формирование счёта
        /// </summary>
        public ICommand MakeInvoiceForPaymentTaskCommand { get; }

        public ICommand LoadScanCommand { get; private set; }
        public ICommand OpenScanCommand { get; private set; }
        public ICommand PrintContractCommand { get; }
        public ICommand PrintSpecificationCommand { get; }

        public SpecificationViewModel(IUnityContainer container) : base(container)
        {
            MakeInvoiceForPaymentTaskCommand = new DelegateLogConfirmationCommand(container.Resolve<IMessageService>(),
                "Вы уверены, что хотите создать счёт на оплату?",
                () =>
                {
                    var storageDirectory = GlobalAppProperties.Actual.TechnicalRequrementsFilesPath;
                    var specification = this.DetailsViewModel.Entity;

                    if (this.DetailsViewModel.Entity.PriceEngineeringTasks.Any() == false &&
                        this.DetailsViewModel.Entity.TechnicalRequrements.Any() == false)
                    {
                        var dr = container.Resolve<IMessageService>().ConfirmationDialog("Уведомление", "Спецификация не связана ни с одной из задач.\nПроизвести их поиск?");
                        if (dr != true) return;

                        var unitOfWork = container.Resolve<IUnitOfWork>();
                        specification = unitOfWork.Repository<Specification>().GetById(specification.Id);

                        var salesUnits = this.GroupsViewModel.Groups
                            .SelectMany(x => x.SalesUnits)
                            .Distinct()
                            .Select(x => unitOfWork.Repository<SalesUnit>().GetById(x.Id))
                            .ToList();

                        var technicalRequrementsList = unitOfWork.Repository<TechnicalRequrements>()
                            .Find(tr => tr.SalesUnits.AllContainsIn(salesUnits))
                            .Where(tr => unitOfWork.Repository<TechnicalRequrementsTask>().GetById(tr.TaskId).IsAccepted)
                            .ToList();

                        while (technicalRequrementsList.Any())
                        {
                            var target = technicalRequrementsList.First();
                            technicalRequrementsList.Remove(target);
                            var requrementsList = technicalRequrementsList
                                .Where(tr => tr.SalesUnits.MembersAreSame(target.SalesUnits))
                                .ToList();
                            requrementsList.ForEach(x => technicalRequrementsList.Remove(x));
                            if (requrementsList.Any())
                            {
                                requrementsList.Add(target);
                                target = container.Resolve<ISelectService>().SelectItem(requrementsList);
                            }
                            if (target != null)
                                specification.TechnicalRequrements.Add(target);
                        }

                        unitOfWork.SaveChanges();
                    }

                    if (container.Resolve<IFilesStorageService>().FileContainsInStorage(this.DetailsViewModel.Entity.Id, storageDirectory) == false)
                    {
                        container.Resolve<IMessageService>().Message("Уведомление", "Сначала загрузите сканированную версию спецификации");
                        return;
                    }

                    container.Resolve<IRegionManager>().RequestNavigateContentRegion<TaskInvoiceForPaymentManagerView>(new NavigationParameters(){{nameof(Specification), specification}});
                });

            PrintSpecificationCommand = new DelegateCommand(() =>
                container.Resolve<IPrintContract>().PrintSpecification(this.DetailsViewModel.Item.Model.Id));
            PrintContractCommand = new DelegateCommand(() =>
                container.Resolve<IPrintContract>().PrintContract(this.DetailsViewModel.Item.Model.Id));
        }

        public override void Load(Specification model, bool isNew, object parameter = null)
        {
            base.Load(model, isNew, parameter);

            //при создании новой спецификации
            if (isNew)
            {
                DetailsViewModel.Item.Date = DateTime.Today;
                var specificationSimpleWrapper = new SpecificationSimpleWrapper(DetailsViewModel.Item.Model);
                EnumerableExtensions.ForEach(GroupsViewModel.Groups, x => x.Specification = specificationSimpleWrapper);
            }

            this.LoadScanCommand = new LoadSpecificationScanCommand(model, this.Container.Resolve<IFilesStorageService>(), this.Container.Resolve<IMessageService>());
            this.OpenScanCommand = new OpenSpecificationScanCommand(model, this.Container.Resolve<IFilesStorageService>(), this.Container.Resolve<IMessageService>());
        }

        protected override IEnumerable<SalesUnit> GetUnits(Specification specification, object parameter = null)
        {
            if(parameter is Project project)
            {
                var salesUnits = ((ISalesUnitRepository)UnitOfWork.Repository<SalesUnit>()).GetByProject(project.Id);
                return salesUnits
                    .Where(salesUnit => salesUnit.Specification == null)
                    .Where(salesUnit => !salesUnit.IsLoosen && !salesUnit.IsRemoved);
            }
            else
            {
                return ((ISalesUnitRepository)UnitOfWork.Repository<SalesUnit>()).GetBySpecification(specification.Id);
            }
        }

        public override void AfterUnitsLoading()
        {
            var ourCompany = UnitOfWork.Repository<Company>().GetById(GlobalAppProperties.Actual.OurCompany.Id);
            var ourCompanyWrapper = new CompanySimpleWrapper(ourCompany);
            EnumerableExtensions.ForEach(GroupsViewModel.Groups, x => x.Producer = ourCompanyWrapper);
        }
    }
}