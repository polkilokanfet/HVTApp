using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceEngineering.DoStepCommand
{
    public class DoStepCommandLoadToTceFinish : DoStepCommand<TaskViewModelBackManager>
    {
        private readonly Action _doAfter;
        protected override ScriptStep Step => ScriptStep.LoadToTceFinish;

        protected override string ConfirmationMessage => "Вы уверены, что загрузили результаты проработки в TeamCenter?";

        public DoStepCommandLoadToTceFinish(TaskViewModelBackManager viewModel, IUnityContainer container, Action doAfter) : base(viewModel, container)
        {
            _doAfter = doAfter;
        }

        protected override IEnumerable<NotificationUnit> GetNotificationUnits()
        {
            yield return new NotificationUnit
            {
                ActionType = NotificationActionType.PriceEngineeringTaskLoadToTceFinish,
                RecipientRole = Role.SalesManager,
                RecipientUser = Manager,
                TargetEntityId = ViewModel.Model.Id
            };
        }

        protected override bool NeedAddSameStatusOnSubTasks => true;

        protected override void DoStepAction()
        {
            base.DoStepAction();
            _doAfter?.Invoke();
        }

        protected override string GetStatusComment()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Заявка в TeamCenter: {ViewModel.TasksWrapperBackManager.TceNumber}");
            foreach (var sccVersion in ViewModel.TasksTceItem.SccVersions.Where(scc => scc.IsActual))
            {
                sb.AppendLine(sccVersion.Model.PriceIncreaseFactor.HasValue
                    ? $" - {sccVersion.Name}: [{sccVersion.OriginalStructureCostNumber} => {sccVersion.Version}], [К уд. = {sccVersion.Model.PriceIncreaseFactor.Value}]"
                    : $" - {sccVersion.Name}: [{sccVersion.OriginalStructureCostNumber} => {sccVersion.Version}]");
            }

            return sb.ToString();
        }

        protected override bool CanExecuteMethod()
        {
            if (ViewModel.TasksWrapperBackManager.IsValid == false) return false;
            if (ViewModel.TasksTceItem.IsValid == false) return false;
            return ViewModel.Status.Equals(ScriptStep.LoadToTceStart) || 
                   ViewModel.Status.Equals(ScriptStep.Accept);
        }
    }
}