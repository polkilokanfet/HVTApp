using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.ViewModels
{
    public partial class PriceEngineeringTaskDetailsViewModel
    {
        protected override void InitSpecialCommands()
        {
            RemoveFromStatusesCommand = new DelegateLogCommand(
                () =>
                {
                    var dr = Container.Resolve<IMessageService>().ConfirmationDialog("Вы уверены? Осторожно! Удаление потом не вернуть!");
                    if (dr == false) return;

                    var status = this.SelectedStatusesItem;

                    using (var unitOfWork = Container.Resolve<IUnitOfWork>())
                    {
                        var statusModel = unitOfWork.Repository<PriceEngineeringTaskStatus>().GetById(status.Id);
                        if (statusModel.StatusEnum == ScriptStep.ProductionRequestFinish.Value)
                        {
                            this.Item.Model.SalesUnits.ForEach(salesUnit => salesUnit.SignalToStartProductionDone = null);
                            var orders = this.Item.Model.SalesUnits
                                .Select(salesUnit => unitOfWork.Repository<Order>().GetById(salesUnit.Order.Id))
                                .Distinct()
                                .ToList();
                            foreach (var order in orders)
                            {
                                unitOfWork.Repository<Order>().Delete(order);
                            }
                        }

                        unitOfWork.Repository<PriceEngineeringTaskStatus>().Delete(statusModel);
                        unitOfWork.SaveChanges();
                    }

                    this.Item.Statuses.Remove(status);
                }, () => this.SelectedStatusesItem != null);

            SelectProductBlockEngineerCommand = new DelegateLogCommand(() =>
            {
                var getProductService = Container.Resolve<IGetProductService>();
                var productBlock = getProductService.GetProductBlock(this.Item.Model.ProductBlockEngineer);
                if (productBlock == null) return;

                using (var unitOfWork = Container.Resolve<IUnitOfWork>())
                {
                    var priceEngineeringTask = unitOfWork.Repository<PriceEngineeringTask>().GetById(this.Item.Model.Id);
                    productBlock = unitOfWork.Repository<ProductBlock>().GetById(productBlock.Id);
                    priceEngineeringTask.ProductBlockEngineer = productBlock;
                    unitOfWork.SaveChanges();
                }
            });
        }
    }
}