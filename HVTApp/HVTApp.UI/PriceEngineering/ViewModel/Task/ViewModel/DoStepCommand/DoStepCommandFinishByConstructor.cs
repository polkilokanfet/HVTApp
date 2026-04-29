using System.Collections.Generic;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceEngineering.DoStepCommand
{
    public class DoStepCommandFinishByConstructor : DoStepCommand<TaskViewModelConstructor>
    {
        protected override ScriptStep Step => ViewModel.Model.VerificationIsRequested
            ? ScriptStep.VerificationRequestByConstructor
            : ScriptStep.FinishByConstructor;

        protected override string ConfirmationMessage => "Вы уверены, что хотите завершить проработку?";

        public DoStepCommandFinishByConstructor(TaskViewModelConstructor viewModel, IUnityContainer container) : base(viewModel, container)
        {
        }
        protected override IEnumerable<NotificationUnit> GetNotificationUnits()
        {
            if (this.ViewModel.Model.VerificationIsRequested)
            {
                if (this.ViewModel.Model.UserConstructorInspector == null)
                {
                    yield return new NotificationUnit
                    {
                        ActionType = NotificationActionType.PriceEngineeringTaskFinishGoToVerification,
                        RecipientRole = Role.DesignDepartmentHead,
                        RecipientUser = ViewModel.Model.DesignDepartment.Head,
                        TargetEntityId = ViewModel.Model.Id
                    };
                }
                else
                {
                    yield return new NotificationUnit
                    {
                        ActionType = NotificationActionType.PriceEngineeringTaskFinishGoToVerification,
                        RecipientRole = Role.Constructor,
                        RecipientUser = ViewModel.Model.UserConstructorInspector,
                        TargetEntityId = ViewModel.Model.Id
                    };
                }
            }
            else
            {
                yield return new NotificationUnit
                {
                    ActionType = NotificationActionType.PriceEngineeringTaskFinish,
                    RecipientRole = Role.SalesManager,
                    RecipientUser = Manager,
                    TargetEntityId = ViewModel.Model.Id
                };
            }
        }

        protected override void BeforeDoStepAction()
        {
            if (ViewModel.Model.HasAnyUpdateStructureCostNumberTaskNotFinished)
            {
                ViewModel.Model.RequestForVerificationFromConstructor = true;
            }
            else
            {
                if (ViewModel.Model.RequestForVerificationFromHead == false)
                    ViewModel.RequestForVerificationFromConstructor = MessageService.ConfirmationDialog("Проверка", "Хотите проверить результаты проработки?", defaultNo: true);
            }

            ViewModel.IsValidForProduction = MessageService.ConfirmationDialog("Проверка", "Предоставленного ТЗ достаточно для производства?", defaultNo: true);
        }

        protected override void DoStepAction()
        {
            base.DoStepAction();
            ViewModel.SplitPriceEngineeringTaskCommand.RaiseCanExecuteChanged();
        }

        protected override string GetStatusComment()
        {
            var sb = new StringBuilder()
                .AppendLine("Информация о результатах проработки.")
                .AppendLine("Основной блок:")
                .AppendLine($" - {ViewModel.ProductBlockEngineer.PrintToMessage()}");

            var pba = ViewModel.ProductBlocksAdded.Where(blockAdded => blockAdded.Model.IsRemoved == false).ToList();
            if (pba.Any())
            {
                sb.AppendLine("Добавленные блоки:");
                pba.ForEach(blockAdded => sb.AppendLine($" - {blockAdded}"));
            }

            var fa = ViewModel.FilesAnswers.Where(x => x.IsActual).ToList();
            if (fa.Any())
            {
                sb.AppendLine("Актуальные приложенные файлы ОГК:");
                fa.ForEach(fileAnswer => sb.AppendLine($" - {fileAnswer}"));
            }

            sb.AppendLine(ViewModel.IsValidForProduction
                ? "\nПредоставленного ТЗ достаточно для производства."
                : "\nПредоставленного ТЗ недостаточно для производства.");

            sb.AppendLine(ViewModel.Model.GetDesignDocumentationAvailabilityInfo());

            return sb.ToString().TrimEnd('\n', '\r');
        }

        protected override bool CanExecuteMethod()
        {
            return ViewModel.IsTarget &&
                   ViewModel.IsEditMode &&
                   base.CanExecuteMethod();
        }
    }
}