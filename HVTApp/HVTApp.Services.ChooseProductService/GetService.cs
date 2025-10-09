using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using Prism.Events;

namespace HVTApp.Services.GetProductService
{
    public class GetService : IGetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILastUpdateMomentService _lastUpdateMomentService;
        private readonly IEventAggregator _eventAggregator;

        private DateTime _lastUpdateMomentOfParameters;
        private IReadOnlyCollection<Parameter> _parametersAll;

        public List<ProductBlock> ProductBlocks { get; private set; }

        public GetService(
            IUnitOfWork unitOfWork, 
            ILastUpdateMomentService lastUpdateMomentService,
            IEventAggregator eventAggregator)
        {
            _unitOfWork = unitOfWork;
            _lastUpdateMomentService = lastUpdateMomentService;
            _eventAggregator = eventAggregator;
            ReloadProductBlocks();
        }

        private IEnumerable<ProductRelation> _productRelations;
        private IEnumerable<ProductRelation> GetProductRelations()
        {
            return _productRelations ?? 
                   (_productRelations = this._unitOfWork.Repository<ProductRelation>().GetAll());
        }

        public IEnumerable<Parameter> GetParameters(ProductBlock productBlock)
        {
            if (_parametersAll is null ||
                _lastUpdateMomentService.GetLastUpdateMomentOfParameters() > _lastUpdateMomentOfParameters)
            {
                _parametersAll = _unitOfWork.Repository<Parameter>()
                    .GetAll()
                    .Where(parameter => parameter.ParameterGroup.Id != GlobalAppProperties.Actual.ComplectsGroup.Id)
                    .Where(parameter => parameter.ParameterGroup.Id != GlobalAppProperties.Actual.ComplectDesignationGroup.Id)
                    .Where(parameter => parameter.Id != GlobalAppProperties.Actual.ComplectsParameter.Id)
                    .ToList();
                _lastUpdateMomentOfParameters = _lastUpdateMomentService.GetLastUpdateMomentOfParameters();
            }

            if (productBlock != null && productBlock.IsKit)
                return _parametersAll.Union(productBlock.Parameters);

            return _parametersAll;
        }

        private void ReloadProductBlocks()
        {
            ProductBlocks = _unitOfWork.Repository<ProductBlock>().GetAll();
        }

        public ProductBlock GetProductBlock(IEnumerable<Parameter> parameters)
        {
            var block = new ProductBlock { Parameters = parameters.ToList() };
            return this.ProductBlocks
                .SingleOrDefault(productBlock => productBlock.Equals(block));
        }

        public ProductBlock SaveProductBlock(ProductBlock productBlock)
        {
            var result = this.ProductBlocks.SingleOrDefault(block => block.Equals(productBlock));
            if (result != null)
                return result;

            //загрузка актуальных блоков продуктов
            this.ReloadProductBlocks();

            //если выбранного блока продукта нет в базе
            if (ProductBlocks.Contains(productBlock) == false)
            {
                productBlock = new ProductBlock
                {
                    Parameters = productBlock.Parameters.Select(x => _unitOfWork.Repository<Parameter>().GetById(x.Id)).ToList()
                };
                if (_unitOfWork.SaveEntity(productBlock).OperationCompletedSuccessfully)
                {
                    ProductBlocks.Add(productBlock);
                    _eventAggregator.GetEvent<AfterSaveProductBlockEvent>().Publish(productBlock);
                }
                else
                {
                    throw new Exception("ќшибка при сохранении нового блока продукта в базу данных.");
                }
            }

            return productBlock;
        }

        //private ProductBlockSelector _productBlockSelector;
        //public ProductBlockSelector GetProductBlockSelector(bool useSingleSelector,
        //    ProductBlock selectedProductBlock = null,
        //    IEnumerable<Parameter> required = null,
        //    IEnumerable<IParametersContainer> containers = null)
        //{
        //    ProductBlockSelector result = _productBlockSelector;

        //    if (useSingleSelector)
        //    {
        //        if (_productBlockSelector == null ||
        //            _lastUpdateMomentService.GetLastUpdateMomentOfParameters() > _lastUpdateMomentOfParameters)
        //        {
        //            result = _productBlockSelector = new ProductBlockSelector(GetParameters(selectedProductBlock), this);
        //            _lastUpdateMomentOfParameters = _lastUpdateMomentService.GetLastUpdateMomentOfParameters();
        //        }
        //    }
        //    else
        //    {
        //        result = new ProductBlockSelector(GetParameters(selectedProductBlock), this);
        //    }

        //    if (required != null)
        //        result.SetRequiredParameters(required);

        //    if (containers != null)
        //        result.SetRequiredParameters(containers);

        //    if (selectedProductBlock != null)
        //    {
        //        //ранее выбранный блок
        //        result.SelectedBlock = selectedProductBlock;
        //    }
        //    else
        //    {
        //        //первый выбранный параметр
        //        var originParameterSelector = result
        //            .ParameterSelectors
        //            .Single(selector => selector.ParametersFlaged.Any(p => p.Parameter.IsOrigin));
        //        originParameterSelector.SelectedParameterFlaged = originParameterSelector.ParametersFlaged.First(x => x.IsActual);
        //    }

        //    return result;
        //}


        /// <summary>
        /// јктуальные св€зи с дочерними продуктами.
        /// </summary>
        /// <param name="product">–одительский продукт.</param>
        /// <returns>—в€зи к дочерним продуктам.</returns>
        public IEnumerable<ProductRelation> GetActualRelationsToChildProducts(Product product)
        {
            return this.GetProductRelations()
                .Where(relation => relation.ParentProductParameters.AllContainsInById(product.ProductBlock.Parameters));
        }

    }
}