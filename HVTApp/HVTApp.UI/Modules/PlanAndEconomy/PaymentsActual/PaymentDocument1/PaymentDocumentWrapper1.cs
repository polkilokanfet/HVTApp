using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.ObjectBuilder2;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class PaymentDocumentWrapper1 : WrapperBase<PaymentDocument>
    {
        #region SimpleProperties

        //Number
        public string Number
        {
            get => Model.Number;
            set => SetValue(value);
        }
        public string NumberOriginalValue => GetOriginalValue<string>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        //Vat
        public double Vat
        {
            get => Model.Vat;
            set => SetValue(value);
        }
        public double VatOriginalValue => GetOriginalValue<double>(nameof(Vat));
        public bool VatIsChanged => GetIsChanged(nameof(Vat));

        #endregion

        #region CollectionProperties

        public IValidatableChangeTrackingCollection<PaymentActualWrapper2> Payments { get; }

        #endregion

        /// <summary>
        /// Дата платежей
        /// </summary>
        public DateTime DockDate
        {
            get => Model.Date;
            set
            {
                Payments.ForEach(payment => payment.Date = value);
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Сумма платежного документа с НДС
        /// </summary>
        public double DockSumWithVat
        {
            get
            {
                return Payments != null && Payments.Any()
                    ? Payments.Sum(payment => payment.SumWithVat)
                    : 0;
            }
            set
            {
                //неоплаченное без учета текущего платежа (c НДС)
                var notPaidWithVat =
                    Payments.Sum(payment => payment.Model.SalesUnit.SumNotPaidWithVat) +
                    Payments.Sum(payment => payment.SumWithVat);

                Payments.ForEach(payment => payment.SumWithVat = value * ((payment.Model.SalesUnit.SumNotPaidWithVat + payment.SumWithVat) / notPaidWithVat));
            }
        }


        public PaymentDocumentWrapper1(PaymentDocument model) : base(model)
        {
            #region InitializeCollectionProperties

            if (Model.Payments == null) throw new ArgumentException("Payments cannot be null");
            Payments = new PaymentsCollection(Model.Payments.Select(paymentActual => new PaymentActualWrapper2(paymentActual)));
            RegisterCollection(Payments, Model.Payments);

            #endregion

            this.Payments.PropertyChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(DockSumWithVat));
                RaisePropertyChanged(nameof(DockDate));
            };
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            if (Vat < 0)
            {
                yield return new ValidationResult("НДС не может быть отрицательным", new[] { nameof(Vat) });
            }

            if (Payments != null)
            {
                if (Payments.Any() == false)
                {
                    yield return new ValidationResult("П/п не может быть без оборудования/услуг", new[] { nameof(Payments) });
                }
            }
        }
    }
}