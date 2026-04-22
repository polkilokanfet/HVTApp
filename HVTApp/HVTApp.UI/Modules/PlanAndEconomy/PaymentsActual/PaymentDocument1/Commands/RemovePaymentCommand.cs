using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class RemovePaymentCommand : BasePaymentDocumentCommand
    {
        public RemovePaymentCommand(PaymentDocumentViewModel viewModel, IUnityContainer container) : base(viewModel, container)
        {
        }

        protected override void ExecuteMethod()
        {
            var payment = ViewModel.SelectedPayment;

            //добавление  платежа в список потенциальных
            ViewModel.Potential.Insert(0, payment.Model.SalesUnit);

            //удаление платежа из документа
            ViewModel.Item.Payments.Remove(payment);

            //удаление платежа из юнита автоматически идет в PaymentActualWrapper2
        }

        protected override bool CanExecuteMethod()
        {
            return ViewModel.SelectedPayment != null;
        }
    }
}