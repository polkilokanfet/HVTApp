using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;

namespace HVTApp.UI.PriceCalculations.ViewModel.Wrapper
{
    public class StructureCost2Wrapper : WrapperBase<StructureCost>
    {
        #region SimpleProperties

        /// <summary>
        /// Номер
        /// </summary>
        public string Number
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string NumberOriginalValue => GetOriginalValue<string>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Номер scc оригинального блока
        /// </summary>
        public string OriginalStructureCostNumber
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string OriginalStructureCostNumberOriginalValue => GetOriginalValue<string>(nameof(OriginalStructureCostNumber));
        public bool OriginalStructureCostNumberIsChanged => GetIsChanged(nameof(OriginalStructureCostNumber));

        /// <summary>
        /// Количество (числитель)
        /// </summary>
        public double AmountNumerator
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double AmountNumeratorOriginalValue => GetOriginalValue<double>(nameof(AmountNumerator));
        public bool AmountNumeratorIsChanged => GetIsChanged(nameof(AmountNumerator));

        /// <summary>
        /// Количество (знаменатель)
        /// </summary>
        public double AmountDenomerator
        {
            get => GetValue<double>();
            set => SetValue(value);
        }
        public double AmountDenomeratorOriginalValue => GetOriginalValue<double>(nameof(AmountDenomerator));
        public bool AmountDenomeratorIsChanged => GetIsChanged(nameof(AmountDenomerator));

        /// <summary>
        /// Себестоимость единицы
        /// </summary>
        public double? UnitPrice
        {
            get => GetValue<double?>();
            set => SetValue(value);
        }
        public double? UnitPriceOriginalValue => GetOriginalValue<double?>(nameof(UnitPrice));
        public bool UnitPriceIsChanged => GetIsChanged(nameof(UnitPrice));

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment
        {
            get => GetValue<string>();
            set => SetValue(value);
        }
        public string CommentOriginalValue => GetOriginalValue<string>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id
        {
            get => GetValue<System.Guid>();
            set => SetValue(value);
        }
        public System.Guid IdOriginalValue => GetOriginalValue<System.Guid>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        #endregion

        #region GetProperties

        /// <summary>
        /// Количество на единицу
        /// </summary>
        public double Amount => GetValue<double>();

        /// <summary>
        /// Total
        /// </summary>
        public double? Total => GetValue<double?>();

        #endregion

        public StructureCost2Wrapper(StructureCost model) : base(model)
        {
            this.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(UnitPrice))
                {
                    RaisePropertyChanged(nameof(Total));
                }

                if (args.PropertyName == nameof(AmountNumerator) || 
                    args.PropertyName == nameof(AmountDenomerator))
                {
                    RaisePropertyChanged(nameof(Amount));
                    RaisePropertyChanged(nameof(Total));
                }
            };
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            if (string.IsNullOrWhiteSpace(Number))
            {
                yield return new ValidationResult("Номер стракчакоста не может быть пустым.", new[] { nameof(Number) });
            }

            if (AmountNumerator <= 0)
            {
                yield return new ValidationResult("Количество (числитель) должно быть положительным.", new[] { nameof(AmountNumerator) });
            }

            if (AmountDenomerator <= 0)
            {
                yield return new ValidationResult("Количество (знаменатель) должно быть положительным.", new[] { nameof(AmountDenomerator) });
            }
        }

    }
}