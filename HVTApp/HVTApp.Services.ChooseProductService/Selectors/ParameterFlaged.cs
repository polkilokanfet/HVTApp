using System;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ParameterFlaged : BindableBase, IComparable<ParameterFlaged>
    {
        #region props

        private bool _isActual;
        private bool? _isRequired;

        /// <summary>
        /// Актуальность параметра (с учётом обязательных и выбранных параметров).
        /// </summary>
        public bool IsActual
        {
            get
            {
                if (this.IsRequired.HasValue &&
                    this.IsRequired.Value == false)
                {
                    return false;
                }

                return _isActual;
            }
            set
            {
                bool result = value;
                if (this.IsRequired.HasValue &&
                    this.IsRequired.Value == false)
                {
                    result = false;
                }

                this.SetProperty(ref _isActual, result, () => { IsActualChanged?.Invoke(this); });
            }
        }

        /// <summary>
        /// Параметр является обязательным в выбранном блоке
        /// </summary>
        public bool? IsRequired
        {
            get => _isRequired;
            set => SetProperty(ref _isRequired, value, () =>
            {
                if (this.IsRequired.HasValue &&
                    this.IsRequired.Value == false)
                {
                    this.IsActual = false;
                }
            });
        }

        public Parameter Parameter { get; }

        #endregion

        #region ctor

        public ParameterFlaged(Parameter parameter)
        {
            Parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
            _isActual = Parameter.IsOrigin;
        }

        #endregion

        #region events

        /// <summary>
        /// Событие изменения актуальности праметра
        /// </summary>
        public event Action<ParameterFlaged> IsActualChanged;

        #endregion

        public override string ToString()
        {
            return this.IsActual 
                ? $"{this.Parameter} - актуален" 
                : $"{this.Parameter} - не актуален";
        }

        public int CompareTo(ParameterFlaged other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return this.Parameter.CompareTo(other.Parameter);
        }
    }
}