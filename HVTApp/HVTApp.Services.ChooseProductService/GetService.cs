using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HVTApp.DataAccess;
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
                    .Where(parameter => parameter.ParameterGroup.Id != GlobalAppProperties.Actual.NewProductParameterGroup.Id)
                    .Where(parameter => parameter.Id != GlobalAppProperties.Actual.ComplectsParameter.Id)
                    .Where(parameter => parameter.Id != GlobalAppProperties.Actual.NewProductParameter.Id)
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
            //пойск в кэше
            var result = this.ProductBlocks.SingleOrDefault(block => block.Equals(productBlock));
            if (result != null)
                return result;

            //поиск в базе данных
            result = ((IProductBlockRepository)_unitOfWork.Repository<ProductBlock>()).GetByParameters(productBlock.Parameters);
            if (result != null)
            {
                ProductBlocks.Add(result);
                return result;
            }

            //если выбранного блока продукта нет в базе данных
            productBlock = new ProductBlock
            {
                Parameters = productBlock.Parameters
                    .Select(parameter => _unitOfWork.Repository<Parameter>().GetById(parameter.Id)).ToList()
            };
            if (_unitOfWork.SaveEntity(productBlock).OperationCompletedSuccessfully)
            {
                ProductBlocks.Add(productBlock);
                _eventAggregator.GetEvent<AfterSaveProductBlockEvent>().Publish(productBlock);
            }
            else
            {
                throw new Exception("Ошибка при сохранении нового блока продукта в базу данных.");
            }

            return productBlock;
        }

        /// <summary>
        /// Актуальные связи с дочерними продуктами.
        /// </summary>
        /// <param name="product">Родительский продукт.</param>
        /// <returns>Связи к дочерним продуктам.</returns>
        public IEnumerable<ProductRelation> GetActualRelationsToChildProducts(Product product)
        {
            return this.GetProductRelations()
                .Where(relation => relation.ParentProductParameters.AllContainsInById(product.ProductBlock.Parameters));
        }

    }
}