using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class PaymentActualWrapper2 : WrapperBase<PaymentActual>
    {
        #region WrapperProperties

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date
        {
            get => Model.Date;
            set => SetValue(value);
        }
        public DateTime DateOriginalValue => GetOriginalValue<DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Сумма
        /// </summary>
        public double Sum
        {
            get => Model.Sum;
            set => SetValue(value);
        }
        public double SumOriginalValue => GetOriginalValue<double>(nameof(Sum));
        public bool SumIsChanged => GetIsChanged(nameof(Sum));

        #endregion

        public double SumNotPaid => Model.SalesUnit.Cost - Model.SalesUnit.PaymentsActual.Sum(x => x.Sum);
        public double SumNotPaidWithVat => this.SumNotPaid * (100.0 + Model.SalesUnit.Vat) / 100.0;

        public double SumWithVat
        {
            get => Sum * (100.0 + Model.SalesUnit.Vat) / 100.0;
            set
            {
                Sum = value / ((100.0 + Model.SalesUnit.Vat) / 100.0);
                RaisePropertyChanged();
            }
        }

        public string ErrorMessages => this.Errors.ActualErrors?.Select(errorInfo => errorInfo.Message).ToStringEnum();


        public PaymentActualWrapper2(PaymentActual model) : base(model)
        {
            this.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Sum))
                {
                    RaisePropertyChanged(nameof(SumWithVat));
                    RaisePropertyChanged(nameof(SumNotPaidWithVat));
                }

                this.Model.SalesUnit.RefreshFirstPaymentInfo();
            };

            this.ErrorsChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(ErrorMessages));
            };
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            if (this.Date > DateTime.Today.AddYears(50))
            {
                yield return new ValidationResult("Даты позже 50 лет с текущей даты недопустимы!", new[] { nameof(Date) });
            }

            if (this.Sum < 0)
            {
                yield return new ValidationResult("Сумма платежа не должна быть меньше 0", new[] { nameof(Sum) });
            }

            if (this.SumNotPaid < 0)
            {
                yield return new ValidationResult("Сумма платежа не должна быть больше остатка на оплату", new[] { nameof(Sum) });
            }
        }
    }
}