using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using EnumerableExtensions = Microsoft.Practices.ObjectBuilder2.EnumerableExtensions;

namespace HVTApp.UI.PriceEngineering.DoStepCommand
{
    public class DoStepCommandProductionRequestFinish : DoStepCommand<TaskViewModelPlanMaker>
    {
        protected override ScriptStep Step => ScriptStep.ProductionRequestFinish;

        protected override string ConfirmationMessage => "¬ы уверены, что открыли производство?";

        public DoStepCommandProductionRequestFinish(TaskViewModelPlanMaker viewModel, IUnityContainer container, Action doAfter) : base(viewModel, container, doAfter)
        {
        }

        protected override IEnumerable<NotificationUnit> GetNotificationUnits()
        {
            yield return new NotificationUnit
            {
                ActionType = NotificationActionType.PriceEngineeringTaskProductionRequestFinish,
                RecipientRole = Role.SalesManager,
                RecipientUser = Manager,
                TargetEntityId = ViewModel.Model.Id
            };

        }

        protected override bool NeedAddSameStatusOnSubTasks => true;

        protected override void BeforeDoStepAction()
        {
            var ordersGroups = ViewModel.SalesUnits.GroupBy(x => new {OrderNumber = x.OrderNumber.Trim(), x.DateOpen});
            foreach (var ordersGroup in ordersGroups)
            {
                var order = new Order {DateOpen = ordersGroup.Key.DateOpen, Number = ordersGroup.Key.OrderNumber};
                EnumerableExtensions.ForEach(ordersGroup, x => x.Model.Order = order);
            }
            ViewModel.SignalToStartProductionDone = DateTime.Now;

            //установка флага того, что документаци€ загружена в TeamCenter
            foreach (var priceEngineeringTask in ViewModel.Model.GetAllPriceEngineeringTasks())
            {
                priceEngineeringTask.IsUploadedDocumentationToTeamCenter = true;
            }
        }

        protected override string GetStatusComment()
        {
            return $"з/з {ViewModel.SalesUnits.Select(x => x.OrderNumber.Trim()).Distinct().ToStringEnum()}";
        }
    }
}