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
        #region fields

        private readonly IGetService _getService;

        #endregion

        #region private props

        private List<Parameter> SelectedParameters => ParameterSelectors
            .Select(selector => selector.SelectedParameterFlaged)
            .Where(parameterFlaged => parameterFlaged != null && parameterFlaged.IsActual)
            .Select(parameterFlaged => parameterFlaged.Parameter)
            .ToList();

        #endregion

        #region props

        public IReadOnlyCollection<ParameterSelector> ParameterSelectors { get; }

        /// <summary>
        /// Выбранный блок
        /// </summary>
        public ProductBlock SelectedBlock =>
            _getService.GetProductBlock(SelectedParameters) ?? 
            new ProductBlock { Parameters = SelectedParameters };

        #endregion

        #region ctor

        internal ProductBlockSelector(
            IGetService getService,
            ICollection<Parameter> requiredParameters, 
            ProductBlock originProductBlock)
        {
            _getService = getService;

            //создаем селекторы параметров
            ParameterSelectors = this.GetSelectors(this.GetParameters(requiredParameters, originProductBlock), originProductBlock);

            //подписка на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterChanged += OnSelectedParameterChanged);

            if (originProductBlock is null)
                this.SelectFirstParameter();
            else
                OnSelectedParameterChanged(null);
        }

        internal ProductBlockSelector(
            IGetService getService,
            IEnumerable<IParametersContainer> containers,
            ProductBlock originProductBlock)
        {
            _getService = getService;

            //создаем селекторы параметров
            var parameters = containers
                .Select(x => this.GetParameters(x.Parameters, originProductBlock))
                .Union()
                .Distinct();
            ParameterSelectors = this.GetSelectors(parameters, originProductBlock);

            //подписка на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterChanged += OnSelectedParameterChanged);

            this.SelectFirstParameter();
        }

        internal ProductBlockSelector(
            IGetService getService,
            ProductBlock originProductBlock)
        {
            _getService = getService;

            //создаем селекторы параметров
            var parameters = getService.GetParameters(originProductBlock);
            ParameterSelectors = this.GetSelectors(parameters, originProductBlock);

            //подписка на смену параметра в селекторе
            ParameterSelectors.ForEach(selector => selector.SelectedParameterChanged += OnSelectedParameterChanged);

            if (originProductBlock is null)
                this.SelectFirstParameter();
            else
                OnSelectedParameterChanged(null);
        }

        private IEnumerable<Parameter> GetParameters(
            ICollection<Parameter> requiredParameters,
            ProductBlock originProductBlock)
        {
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

            var allParameters = _getService.GetParameters(originProductBlock).ToList();

            //исключаемые из групп обязательных
            var exceptParameters = allParameters
                .Where(parameter => parameterGroups.ContainsById(parameter.ParameterGroup))
                .Except(path)
                .Except(requiredParameters)
                .ToList();

            return allParameters
                .Except(path)
                .Except(requiredParameters)
                .Except(exceptParameters)
                .Where(parameter => parameter.Paths()
                    .Where(x => x.Parameters.Intersect(exceptParameters).Any() == false)
                    .Any(dd => path.AllContainsInById(dd.Parameters)))
                .Union(path)
                .Union(requiredParameters);
        }

        private IReadOnlyCollection<ParameterSelector> GetSelectors(
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