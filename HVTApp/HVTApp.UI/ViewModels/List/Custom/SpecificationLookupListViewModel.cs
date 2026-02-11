using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using HVTApp.DataAccess;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.UI.Commands;
using HVTApp.UI.Lookup;
using HVTApp.UI.Modules.Sales.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace HVTApp.UI.ViewModels
{
    public partial class SpecificationLookupListViewModel
    {
        protected override void InitSpecialCommands()
        {
            EditItemCommand = new DelegateLogCommand(
                () =>
                {
                    if (GlobalAppProperties.UserIsManager)
                        RegionManager.RequestNavigateContentRegion<SpecificationView>(new NavigationParameters { { nameof(Specification), SelectedItem } });
                },
                () => this.SelectedItem != null);

                RemoveItemCommand = new DelegateLogConfirmationCommand(
                    this.Container.Resolve<IMessageService>(),
                    "Вы уверены, что хотите удалить данную спецификацию?",
                    () =>
                    {
                        var unitOfWork = Container.Resolve<IUnitOfWork>();

                        var specification = unitOfWork.Repository<Specification>().GetById(SelectedLookup.Id);
                        if (specification == null) return;

                        var salesUnits = specification.SalesUnits;

                        foreach (var salesUnit in salesUnits)
                        {
                            var items = unitOfWork.Repository<TaskInvoiceForPaymentItem>()
                                .Find(item => item.SalesUnits.Contains(salesUnit));
                            if (items.Any())
                            {
                                var dr = MessageService.ConfirmationDialog("Спецификация фигурирует в заданиях на создание счёта. Вы уверены в удалении?");
                                if(dr == false)
                                    return;

                                break;
                            }
                        }

                        salesUnits.ForEach(salesUnit => salesUnit.Specification = null);
                        specification.PriceEngineeringTasks.ForEach(task => task.Specification = null);
                        specification.TechnicalRequrements.ForEach(requirements => requirements.Specification = null);

                        try
                        {
                            unitOfWork.Repository<Specification>().Delete(specification);
                            unitOfWork.SaveChanges();
                        }
                        catch (DbUpdateException e)
                        {
                            MessageService.Message(e.GetType().ToString(), e.PrintAllExceptions());
                            return;
                        }

                        EventAggregator.GetEvent<AfterRemoveSpecificationEvent>().Publish(specification);

                    },

                    //() =>
                    //{
                    //    var unitOfWork = Container.Resolve<IUnitOfWork>();
                    //    unitOfWork.RemoveEntity(this.SelectedItem);
                    //    Container.Resolve<IEventAggregator>().GetEvent<AfterRemoveSpecificationEvent>().Publish(this.SelectedItem);
                    //},
                    () => GlobalAppProperties.UserIsManager && this.SelectedItem != null);

            this.SelectedLookupChanged += lookup =>
            {
                ((DelegateLogConfirmationCommand) RemoveItemCommand).RaiseCanExecuteChanged();
                ((DelegateLogCommand) EditItemCommand).RaiseCanExecuteChanged();
            };
        }

        public override IEnumerable<SpecificationLookup> GetAllLookups()
        {
            if (GlobalAppProperties.UserIsManager)
                return ((ISalesUnitRepository) UnitOfWork.Repository<SalesUnit>())
                    .GetAllOfCurrentUser()
                    .Where(salesUnit => salesUnit.Specification != null)
                    .Select(salesUnit => salesUnit.Specification)
                    .Distinct()
                    .Select(specification => new SpecificationLookup(specification));

            return UnitOfWork.Repository<Specification>()
                .GetAll()
                .Select(specification => new SpecificationLookup(specification));
        }
    }
}