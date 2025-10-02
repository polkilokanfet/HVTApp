using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ProductBlockSelector : BindableBase, IDisposable
    {

        #region fields

        private readonly Bank _bank;

        #endregion

        #region private props

        private List<Parameter> SelectedParameters => ParameterSelectors
            .Select(x => x.SelectedParameterFlaged)
            .Where(x => x != null)
            .Select(x => x.Parameter)
            .ToList();

        #endregion

        #region props

        public ObservableCollection<ParameterSelector> ParameterSelectors { get; }

        /// <summary>
        /// Выбранный блок
        /// </summary>
        public ProductBlock SelectedBlock
        {
            get
            {
                var result = new ProductBlock {Parameters = SelectedParameters};
                result.DesignationSpecial = _bank.GetBlockSpecialDesignation(result.GetHashCode());
                return result;
            }
            set
            {
                var blockToSet = value;
                if(blockToSet == null) throw new ArgumentNullException(nameof(blockToSet));

                //если совпадают выбранные параметры и параметры нового блока
                if (SelectedParameters.MembersAreSame(blockToSet.Parameters)) return;

                var parameterSelectors = ParameterSelectors.ToList();
                //отписываемся от событий выбора нового параметра
                parameterSelectors.ForEach(ps => ps.SelectedParameterFlagedChanged -= OnSelectedParameterChanged);
                //обнуляем выбранные параметры
                parameterSelectors.ForEach(ps => ps.SelectedParameterFlaged = null);

                //назначение в каждый селектор необходимого параметра
                foreach (var parameter in blockToSet.Parameters)
                {
                    //поиск селектора
                    var selector = ParameterSelectors.Single(ps => ps.ParametersFlaged.Select(x => x.Parameter).Contains(parameter));
                    //выбор параметра
                    selector.SelectedParameterFlaged = selector.ParametersFlaged.Single(p => p.Parameter.Equals(parameter));
                    selector.SelectedParameterFlaged.IsActual = true;
                }

                //подписываемся на события выбора нового параметра в каждом селекторе
                parameterSelectors.ForEach(ps => ps.SelectedParameterFlagedChanged += OnSelectedParameterChanged);

                OnSelectedParameterChanged(null);

                RaisePropertyChanged();
                SelectedBlockChanged?.Invoke(this);
            }
        }

        #endregion

        #region ctor

        public ProductBlockSelector(IEnumerable<Parameter> parameters, Bank bank, ProductBlock selectedProductBlock = null)
        {
            _bank = bank;

            var parametersArray = parameters as Parameter[] ?? parameters.ToArray();

            //создаем селекторы параметров
            ParameterSelectors = new ObservableCollection<ParameterSelector>(GetParameterSelectors(parametersArray));

            //подписка на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterFlagedChanged += OnSelectedParameterChanged);

            //если есть выбранный блок
            if (selectedProductBlock != null)
            {
                if(selectedProductBlock.Parameters.AllContainsIn(parametersArray) == false)
                    throw new ArgumentException("Параметры блока не соответствуют возможным параметрам.");

                SelectedBlock = selectedProductBlock;
            }
        }

        #endregion

        #region events

        /// <summary>
        /// Событие изменения выбранного блока.
        /// </summary>
        public event Action<ProductBlockSelector> SelectedBlockChanged;

        #endregion

        /// <summary>
        /// группировка параметров и упорядочивание их
        /// </summary>
        /// <param name="parameters">параметры</param>
        /// <returns></returns>
        private IEnumerable<ParameterSelector> GetParameterSelectors(IEnumerable<Parameter> parameters)
        {
            //группировка параметров по группам и упорядочивание их.
            var groups = parameters
                .GroupBy(parameter => parameter.ParameterGroup.Id)
                //.OrderBy(x => x, new ParametersEnumerableComparerByPaths())
                .Select(x => new ParameterSelector(x))
                .OrderBy(x => x);

            foreach (var group in groups)
            {
                yield return group;
            }
        }

        /// <summary>
        /// Реакция на изменение выбранного параметра в селекторе.
        /// </summary>
        /// <param name="parameterSelector"></param>
        private void OnSelectedParameterChanged(ParameterSelector parameterSelector)
        {
            //перепроверка актуальности параметров
            var parametersFlaged = ParameterSelectors.SelectMany(x => x.ParametersFlaged);
            foreach (var parameter in parametersFlaged)
            {
                parameter.IsActual = parameter.Parameter.IsOrigin ||
                                     parameter.Parameter.ParameterRelations.Any(x => x.RequiredParameters.AllContainsIn(SelectedParameters));
            }

            //событие смены блока
            SelectedBlockChanged?.Invoke(this);
            RaisePropertyChanged(nameof(SelectedBlock));
        }

        public void Dispose()
        {
            //отмена подписки на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterFlagedChanged -= OnSelectedParameterChanged);
            ParameterSelectors.ForEach(selector => selector.Dispose());
        }
    }
}