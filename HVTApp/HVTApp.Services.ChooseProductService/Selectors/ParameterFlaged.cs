using System;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ParameterFlaged : BindableBase, IComparable<ParameterFlaged>
    {
        #region props

        private bool _isActual = false;

        /// <summary>
        /// Актуальность параметра (с учётом обязательных и выбранных параметров).
        /// </summary>
        public bool IsActual
        {
            get => _isUnreachable != true && _isActual;
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

        #region Reachable

         // Данный параметр недостижим (из-за обязательных к выбору параметров в блоке)
        private bool _isUnreachable = false;
        public bool IsUnreachable => _isUnreachable;

        public void SetAsUnreachable()
        {
            if (_isUnreachable == true)
                return;

            _isUnreachable = true;
            IsActual = false;
        }

        public void SetAsReachable()
        {
            if (_isUnreachable == false)
                return;

            _isUnreachable = false;
            RaisePropertyChanged(nameof(IsActual));
        }

        public override string ToString()
        {
            return this.IsActual 
                ? $"{this.Parameter} - актуален" 
                : $"{this.Parameter} - не актуален";
        }

       #endregion

        public int CompareTo(ParameterFlaged other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return this.Parameter.CompareTo(other.Parameter);
        }
    }
}