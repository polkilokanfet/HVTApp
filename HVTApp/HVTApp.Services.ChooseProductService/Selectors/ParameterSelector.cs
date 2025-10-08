using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ParameterSelector : BindableBase, IComparable<ParameterSelector>, IDisposable
    {
        #region props

        public bool IsActual => ParametersFlaged.Any(x => x.IsActual) && 
                                ParametersFlaged.Count(x => x.IsActual) > 1;

        private ParameterFlaged _selectedParameterFlaged;
        public ParameterFlaged SelectedParameterFlaged
        {
            get => _selectedParameterFlaged;
            set => this.SetProperty(ref _selectedParameterFlaged, value,
                () =>
                {
                    SelectedParameterFlagedChanged?.Invoke(this);
                });
        }

        public IReadOnlyCollection<ParameterFlaged> ParametersFlaged { get; }

        #endregion

        #region ctor

        public ParameterSelector(IEnumerable<Parameter> parameters)
        {
            var parametersArray = parameters as Parameter[] ?? parameters.ToArray();

            if (parametersArray == null) throw new ArgumentNullException(nameof(parameters));
            if (parametersArray.Any() == false) throw new ArgumentException("В селектор пришло пустое перечисление параметров", nameof(parameters));
            if (parametersArray.GroupBy(parameter => parameter.ParameterGroup.Id).Count() > 1) throw new ArgumentException("В селектор пришли параметры из разных групп", nameof(parameters));

            //упорядочивание параметров
            var parametersFlaged = parametersArray
                .Select(parameter => new ParameterFlaged(parameter))
                .OrderBy(parameterFlaged => parameterFlaged)
                .ToList();
            ParametersFlaged = new ReadOnlyCollection<ParameterFlaged>(parametersFlaged);

            //реакция на изменение актуальности параметра
            ParametersFlaged.ForEach(parameter => parameter.IsActualChanged += ParameterOnActualChanged);
        }

        /// <summary>
        /// Реакция на изменение актуальности параметра
        /// </summary>
        /// <param name="parameter"></param>
        private void ParameterOnActualChanged(ParameterFlaged parameter)
        {
            //актуализация выбранного параметра
            if (SelectedParameterFlaged == null || 
                SelectedParameterFlaged.IsActual == false)
            {
                //если выбранный параметр стал не актуальным, выбираем первый актуальный
                SelectedParameterFlaged = ParametersFlaged.FirstOrDefault(p => p.IsActual);
            }

            //проверка актуальности селектора
            RaisePropertyChanged(nameof(IsActual));
        }

        #endregion

        /// <summary>
        /// Установка обязательных параметров
        /// </summary>
        /// <param name="parameters"></param>
        public void SetRequiredParameters(IEnumerable<Parameter> parameters)
        {
            foreach (var parameterFlaged in this.ParametersFlaged)
            {
                parameterFlaged.IsRequired = parameters.ContainsById(parameterFlaged.Parameter);
            }
        }

        /// <summary>
        /// Скинуть обязательность параметра
        /// </summary>
        public void DropRequiredParameters()
        {
            this.ParametersFlaged.ForEach(x => x.IsRequired = null);
        }


        #region events

        /// <summary>
        /// Событие изменения выбранного параметра
        /// </summary>
        public event Action<ParameterSelector> SelectedParameterFlagedChanged;

        #endregion

        public override string ToString()
        {
            return $"{ParametersFlaged.First().Parameter.ParameterGroup.Name} ({this.ParametersFlaged.ToStringEnum()})";
        }

        public int CompareTo(ParameterSelector other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var parametersThis = this.ParametersFlaged.Select(x => x.Parameter).ToList();
            var parametersOther = other.ParametersFlaged.Select(x => x.Parameter).ToList();

            //if (parametersThis.Select(x => x.Value).Any(x => x == "Трансформатор"))
            //{
            //    if (parametersOther.Select(x => x.Value).Any(x => x == "Напряжения"))
            //    {

            //    }
            //}

            //if (parametersOther.Select(x => x.Value).Any(x => x == "Трансформатор"))
            //{
            //    if (parametersThis.Select(x => x.Value).Any(x => x == "Напряжения"))
            //    {

            //    }
            //}

            //if (parametersThis.Select(x => x.Value).Any(x => x == "Напряжения"))
            //{
            //    if (parametersOther.Select(x => x.Value).Any(x => x == "Трансформатор"))
            //    {

            //    }
            //}

            //if (parametersOther.Select(x => x.Value).Any(x => x == "Напряжения"))
            //{
            //    if (parametersThis.Select(x => x.Value).Any(x => x == "Трансформатор"))
            //    {

            //    }
            //}

            foreach (var parameterThis in parametersThis)
            {
                foreach (var parameterOther in parametersOther)
                {
                    var result = parameterThis.CompareToPaths(parameterOther);
                    if (result != 0)
                        return result;
                }
            }

            return parametersThis.First().CompareTo(parametersOther.First());
        }

        public void Dispose()
        {
            ParametersFlaged.ForEach(parameter => parameter.IsActualChanged -= ParameterOnActualChanged);
        }
    }
}
