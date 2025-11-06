using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceCalculations.ViewModel.PriceCalculation1.Commands
{
    public class SetPricesService
    {
        private readonly IUnityContainer _container;

        public SetPricesService(IUnityContainer container)
        {
            _container = container;
        }
    }

    public class FinishCommand : BaseBasePriceCalculationCommandNotifyCommand
    {
        protected override string ConfirmationMessage => "Вы уверены, что хотите завершить расчёт ПЗ?";
        protected override PriceCalculationHistoryItemType HistoryItemType => PriceCalculationHistoryItemType.Finish;

        public FinishCommand(PriceCalculationViewModel viewModel, IUnityContainer container) : base(viewModel, container)
        {
        }

        protected override bool CanExecuteMethod()
        {
            if (ViewModel.PriceCalculationWrapper == null)
            {
                return false;
            }

            if (ViewModel.PriceCalculationWrapper.IsNeedExcelFile && !ViewModel.CalculationHasFile)
            {
                return false;
            }

            return ViewModel.IsStarted &&
                   !ViewModel.IsFinished &&
                   ViewModel.PriceCalculationWrapper.IsValid &&
                   ViewModel.PriceCalculationWrapper.PriceCalculationItems.SelectMany(item => item.StructureCosts).All(structureCost => structureCost.UnitPrice.HasValue);

        }

        protected override void ExecuteMethod()
        {
            base.ExecuteMethod();

            //добавление новых ПЗ в блоки
            if (this.DialogResult == true)
            {
                AddPricesInProductBlocks(ViewModel.PriceCalculationWrapper.Model.PriceCalculationItems);
            }
        }

        /// <summary>
        /// Добавление новых ПЗ в блоки
        /// </summary>
        private void AddPricesInProductBlocks(IEnumerable<PriceCalculationItem> priceCalculationItems)
        {
            //все стракчакосты подходящие под критерии
            var structureCosts = priceCalculationItems
                .Where(priceCalculationItem => priceCalculationItem.RealizationDate >= DateTime.Today)  //расчёты из прошлого откидываем
                .SelectMany(calculationItem => calculationItem.StructureCosts)
                .Where(structureCost => structureCost.OriginalStructureCostNumber != null)
                .Where(structureCost => structureCost.OriginalStructureCostProductBlock != null)
                .Where(structureCost => structureCost.OriginalStructureCostProductBlock.StructureCostNumber ==
                                        structureCost.OriginalStructureCostNumber) //номер стракчакоста из строки расчёта соответствует номеру стракчакоста блока
                .Where(structureCost => structureCost.UnitPrice.HasValue)
                .ToList();

            using (var unitOfWork = Container.Resolve<IUnitOfWork>())
            {
                foreach (var structureCost in structureCosts)
                {
                    //целевой блок продукта
                    var productBlock = unitOfWork.Repository<ProductBlock>()
                        .GetById(structureCost.OriginalStructureCostProductBlock.Id);
                    //целевая строка расчёта
                    var calculationItem = unitOfWork.Repository<PriceCalculationItem>()
                        .GetById(structureCost.PriceCalculationItemId);

                    var sum = structureCost.PriceIncreaseFactor.HasValue
                        ? structureCost.UnitPrice.Value / structureCost.PriceIncreaseFactor.Value
                        : structureCost.UnitPrice.Value;
                    var date = calculationItem.RealizationDate;
                    var sumOnDate = new SumOnDate { Sum = sum, Date = date };

                    if (productBlock.AllowAddThisPriceFromCalculation(sumOnDate))
                    {
                        productBlock.Prices.Add(sumOnDate);
                        unitOfWork.SaveChanges();
                    }
                }
            }
        }

        protected override IEnumerable<NotificationUnit> GetNotificationUnits()
        {
            var users = ViewModel.PriceCalculationWrapper.Model.PriceCalculationItems
                .SelectMany(priceCalculationItem => priceCalculationItem.SalesUnits)
                .Select(salesUnit => salesUnit.Project.Manager)
                .Distinct();

            foreach (var user in users)
            {
                yield return new NotificationUnit
                {
                    ActionType = NotificationActionType.FinishPriceCalculation,
                    RecipientRole = Role.SalesManager,
                    RecipientUser = user,
                    TargetEntityId = ViewModel.PriceCalculationWrapper.Model.Id
                };
            }
        }
    }
}