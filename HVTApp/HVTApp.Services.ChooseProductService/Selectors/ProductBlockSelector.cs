using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ProductBlockSelector : BindableBase, IDisposable
    {
        #region fields

        private readonly IGetService _getService;

        #endregion

        #region private props

        private List<Parameter> SelectedParameters => ParameterSelectors
            .Select(selector => selector.SelectedParameterFlaged)
            .Where(x => x != null && x.IsActual)
            .Select(x => x.Parameter)
            .ToList();

        #endregion

        #region props

        public IReadOnlyCollection<ParameterSelector> ParameterSelectors { get; }

        /// <summary>
        /// Выбранный блок
        /// </summary>
        public ProductBlock SelectedBlock
        {
            get => _getService.GetProductBlock(SelectedParameters) 
                   ?? new ProductBlock { Parameters = SelectedParameters };
            set
            {
                var blockToSet = value;

                if (blockToSet == null)
                {
                    var parameterSelector = this.ParameterSelectors.Single(x => x.ParametersFlaged.Any(xx => xx.Parameter.IsOrigin));
                    parameterSelector.SelectedParameterFlaged = parameterSelector.ParametersFlaged.First();
                    return;
                }

                var parameters = this.ParameterSelectors
                    .SelectMany(x => x.ParametersFlaged)
                    .Select(x => x.Parameter);
                if (blockToSet.Parameters.AllContainsInById(parameters) == false)
                        throw new ArgumentException("Параметры блока не соответствуют возможным параметрам.");

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

        internal ProductBlockSelector(
            IGetService getService,
            ICollection<Parameter> requiredParameters, 
            ProductBlock originProductBlock)
        {
            _getService = getService;

            //общий путь до обязательных параметров
            var path = requiredParameters
                .Select(parameter => parameter.Paths().Select(pathToOrigin => pathToOrigin.Parameters).Union())
                .Intersect()
                .Distinct()
                .ToList();

            //группы обязательных параметров
            var parameterGroups = path
                .Union(requiredParameters)
                .Select(parameter => parameter.ParameterGroup)
                .Distinct()
                .ToList();

            var parameters = getService
                .GetParameters(originProductBlock)
                .Except(path)
                .Except(requiredParameters)
                .Where(parameter => parameterGroups.ContainsById(parameter.ParameterGroup) == false)
                .Where(parameter => parameter.Paths().Any(dd => path.AllContainsInById(dd.Parameters)))
                .Union(path)
                .Union(requiredParameters);

            //создаем селекторы параметров
            ParameterSelectors = parameters
                .GroupBy(parameter => parameter.ParameterGroup.Id)
                .Select(x => new ParameterSelector(x))
                .OrderBy(parameterSelector => parameterSelector)
                .ToReadOnlyCollection();

            //подписка на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterFlagedChanged += OnSelectedParameterChanged);

            this.SelectedBlock = originProductBlock;
        }

        #endregion

        #region events

        /// <summary>
        /// Событие изменения выбранного блока.
        /// </summary>
        public event Action<ProductBlockSelector> SelectedBlockChanged;

        #endregion

        /// <summary>
        /// Реакция на изменение выбранного параметра в селекторе.
        /// </summary>
        /// <param name="parameterSelector"></param>
        private void OnSelectedParameterChanged(ParameterSelector parameterSelector)
        {
            //перепроверка актуальности параметров
            var parametersAll = ParameterSelectors.SelectMany(selector => selector.ParametersFlaged);
            foreach (var parameter in parametersAll)
            {
                parameter.IsActual = parameter.Parameter.IsOrigin ||
                                     parameter.Parameter.ParameterRelations.Any(parameterRelation => parameterRelation.RequiredParameters.AllContainsInById(SelectedParameters));
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