using System;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ParameterFlaged : BindableBase, IComparable<ParameterFlaged>
    {
        #region props

        private bool _isActual;

        /// <summary>
        /// Актуальность параметра при выбранных.
        /// </summary>
        public bool IsActual
        {
            get => _isActual;
            set => this.SetProperty(ref _isActual, value, () => { IsActualChanged?.Invoke(this); });
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

        public int CompareTo(ParameterFlaged other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return this.Parameter.CompareTo(other.Parameter);
        }
    }
}