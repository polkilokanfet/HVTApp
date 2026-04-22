using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using HVTApp.Model.Wrapper.Base.TrackingCollections;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class PaymentsCollection : ValidatableChangeTrackingCollection<PaymentActualWrapper2>
    {
        public PaymentsCollection(IEnumerable<PaymentActualWrapper2> items) : base(items)
        {
            this.CollectionChanged += (sender, args) =>
            {
                //добавляем в SalesUnit новые платежи
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var paymentActualWrapper in args.NewItems.Cast<PaymentActualWrapper2>())
                    {
                        var salesUnit = paymentActualWrapper.Model.SalesUnit;
                        salesUnit.PaymentsActual.Add(paymentActualWrapper.Model);
                        salesUnit.RefreshFirstPaymentInfo();
                    }
                }

                //удаляем из SalesUnit старые платежи
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var paymentActualWrapper in args.OldItems.Cast<PaymentActualWrapper2>())
                    {
                        var salesUnit = paymentActualWrapper.Model.SalesUnit;
                        salesUnit.PaymentsActual.Remove(paymentActualWrapper.Model);
                        salesUnit.RefreshFirstPaymentInfo();
                    }
                }
            };
        }
    }
}