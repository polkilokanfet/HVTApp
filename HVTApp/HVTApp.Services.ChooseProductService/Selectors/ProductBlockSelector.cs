using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using Prism.Mvvm;

namespace HVTApp.Services.GetProductService
{
    public class ProductBlockSelector : BindableBase, IDisposable
    {
        private static IGetService _getService;

        private List<Parameter> SelectedParameters => ParameterSelectors
            .Select(selector => selector.SelectedParameterFlaged)
            .Where(parameterFlaged => parameterFlaged != null && parameterFlaged.IsActual)
            .Select(parameterFlaged => parameterFlaged.Parameter)
            .ToList();

        public IReadOnlyCollection<ParameterSelector> ParameterSelectors { get; }

        /// <summary>
        /// Выбранный блок
        /// </summary>
        public ProductBlock SelectedBlock =>
            _getService.GetProductBlock(SelectedParameters) ?? 
            new ProductBlock { Parameters = SelectedParameters };

        #region ctor

        public static ProductBlockSelector GetSelector(
            IGetService getService,
            IEnumerable<Parameter> requiredParameters,
            ProductBlock originProductBlock)
        {
            var selectors = GetSelectors(GetParameters(getService, requiredParameters, originProductBlock), originProductBlock);
            return GetSelector(getService, selectors, originProductBlock);
        }

        public static ProductBlockSelector GetSelector(
            IGetService getService,
            IEnumerable<IParametersContainer> containers,
            ProductBlock originProductBlock)
        {
            //создаем селекторы параметров
            var parameters = containers
                .Select(x => GetParameters(getService, x.Parameters, originProductBlock))
                .Union()
                .Distinct();
            var selectors = GetSelectors(parameters, originProductBlock);

            return GetSelector(getService, selectors, originProductBlock);
        }

        public static ProductBlockSelector GetSelector(
            IGetService getService,
            ProductBlock originProductBlock)
        {
            var parameters = getService.GetParameters(originProductBlock);
            var selectors = GetSelectors(parameters, originProductBlock);
            return GetSelector(getService, selectors, originProductBlock);
        }

        private static ProductBlockSelector GetSelector(
            IGetService getService,
            IEnumerable<ParameterSelector> parameterSelectors,
            ProductBlock originProductBlock)
        {
            _getService = getService;
            var productBlockSelector = new ProductBlockSelector(parameterSelectors);
            productBlockSelector.Subscribe(originProductBlock);
            return productBlockSelector;
        }

        private ProductBlockSelector(IEnumerable<ParameterSelector> selectors)
        {
            this.ParameterSelectors = selectors.ToReadOnlyCollection();
        }


        private void Subscribe(ProductBlock originProductBlock)
        {
            //подписка на смену параметра в селекторе
            this.ParameterSelectors.ForEach(selector => selector.SelectedParameterChanged += OnSelectedParameterChanged);
            
            if (originProductBlock is null)
                this.SelectFirstParameter();
            else
                OnSelectedParameterChanged(null);
        }

        private static IEnumerable<Parameter> GetParameters(
            IGetService getService,
            IEnumerable<Parameter> requiredParameters,
            ProductBlock originProductBlock)
        {
            var parameters = requiredParameters as Parameter[] ?? requiredParameters.ToArray();

            //общий путь до обязательных параметров
            var path = parameters
                .Select(parameter => parameter.Paths().Select(pathToOrigin => pathToOrigin.Parameters).Union())
                .Intersect()
                .Distinct()
                .ToList();

            //группы обязательных параметров
            var parameterGroups = path
                .Union(parameters)
                .Select(parameter => parameter.ParameterGroup)
                .Distinct()
                .ToList();

            var allParameters = getService.GetParameters(originProductBlock).ToList();

            //исключаемые из групп обязательных
            var exceptParameters = allParameters
                .Where(parameter => parameterGroups.ContainsById(parameter.ParameterGroup))
                .Except(path)
                .Except(parameters)
                .ToList();

            return allParameters
                .Except(path)
                .Except(parameters)
                .Except(exceptParameters)
                .Where(parameter => parameter.Paths()
                    .Where(x => x.Parameters.Intersect(exceptParameters).Any() == false)
                    .Any(dd => path.AllContainsInById(dd.Parameters)))
                .Union(path)
                .Union(parameters);
        }

        private static IReadOnlyCollection<ParameterSelector> GetSelectors(
            IEnumerable<Parameter> parameters,
            ProductBlock originProductBlock)
        {
            //создаем селекторы параметров
            return parameters
                .GroupBy(parameter => parameter.ParameterGroup.Id)
                .Select(x => new ParameterSelector(x, originProductBlock?.Parameters.SingleOrDefault(x.ContainsById)))
                .OrderBy(parameterSelector => parameterSelector)
                .ToReadOnlyCollection();
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
            ParameterSelectors.ForEach(selector => selector.SelectedParameterChanged -= OnSelectedParameterChanged);
            ParameterSelectors.ForEach(selector => selector.Dispose());
        }

        public void SelectFirstParameter()
        {
            var parameterSelector = ParameterSelectors.Single(selector => selector.ParametersFlaged.Any(p => p.Parameter.IsOrigin));
            parameterSelector.SelectedParameterFlaged = parameterSelector.ParametersFlaged.First();
        }
    }
}