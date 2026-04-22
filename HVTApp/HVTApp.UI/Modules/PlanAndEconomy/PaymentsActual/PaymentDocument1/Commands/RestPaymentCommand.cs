using System.Linq;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class RestPaymentCommand : BasePaymentDocumentCommand
    {
        public RestPaymentCommand(PaymentDocumentViewModel viewModel, IUnityContainer container) : base(viewModel, container)
        {
        }

        protected override void ExecuteMethod()
        {
            foreach (var payment in ViewModel.Item.Payments)
            {
                payment.Sum += payment.SumNotPaid;
            }
        }

        protected override bool CanExecuteMethod()
        {
            return ViewModel.Item != null &&
                   ViewModel.Item.Payments.Any();
        }
    }
}