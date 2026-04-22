using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Model.POCOs;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class SalesUnitPaymentGroup
    {
        private readonly List<SalesUnit> _salesUnits;

        public List<SalesUnitPayment> SalesUnitPayments { get; }

        public SalesUnitPayment SalesUnitPayment => SalesUnitPayments.First();

        public int Amount => _salesUnits.Count;
        public bool IsPaid => _salesUnits.All(salesUnit => salesUnit.IsPaid);

        public double SumToPay => _salesUnits.Sum(salesUnit => salesUnit.Cost);
        public double Sum => SalesUnitPayments.Sum(x => x.Payment.Sum);
        public double SumWithVat => SalesUnitPayments.Sum(x => x.SumWithVat);

        public double PercentPaid => Math.Abs(SumToPay) < 0.000001
            ? 0
            : SalesUnitPayments.Sum(x => x.Payment.Sum) / SumToPay * 100.0;

        public double PercentNotPaid => 100.0 - PercentPaid;

        public double SumNotPaidWithVat => _salesUnits.Sum(salesUnit => salesUnit.SumNotPaidWithVat);
        public DateTime LastDate => SalesUnitPayments.Select(x => x.Payment.Date).Max();

        public SalesUnitPaymentGroup(IEnumerable<SalesUnitPayment> salesUnitPayments)
        {
            SalesUnitPayments = salesUnitPayments
                .OrderByDescending(x => x.Payment.Date)
                .ThenBy(x => x.Payment.SalesUnit.OrderPosition)
                .ToList();

            _salesUnits = SalesUnitPayments.Select(x => x.Payment.SalesUnit).Distinct().ToList();
        }
    }

    public class SalesUnitPayment
    {
        public PaymentActual Payment { get; }

        public double SumWithVat => Payment.Sum * (100.0 + Payment.SalesUnit.Vat) / 100.0;
        public Contract Contract => Payment.SalesUnit.Specification?.Contract;
        public Company Contragent => Contract?.Contragent;
        public double Percent => Payment.Sum / Payment.SalesUnit.Cost * 100.0;
        public double PercentNotPaid => 100.0 - Percent;

        public SalesUnitPayment(PaymentActual payment)
        {
            Payment = payment;
        }
    }
}