using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;

namespace HVTApp.Services.GetProductService
{
    internal class GetParametersService : IProductBlocksContainer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILastUpdateMomentService _lastUpdateMomentService;
        private readonly IReadOnlyCollection<ProductBlock> _productBlocks;

        private DateTime _lastUpdateMomentOfParameters;
        private IReadOnlyCollection<Parameter> _parametersAll;

        public GetParametersService(IUnitOfWork unitOfWork, ILastUpdateMomentService lastUpdateMomentService)
        {
            _unitOfWork = unitOfWork;
            _lastUpdateMomentService = lastUpdateMomentService;
            _productBlocks = _unitOfWork.Repository<ProductBlock>().GetAll();
        }

        public IEnumerable<Parameter> GetParameters()
        {
            if (_parametersAll is null ||
                _lastUpdateMomentService.GetLastUpdateMomentOfParameters() > _lastUpdateMomentOfParameters)
            {
                _parametersAll = _unitOfWork.Repository<Parameter>().GetAll();
                _lastUpdateMomentOfParameters = _lastUpdateMomentService.GetLastUpdateMomentOfParameters();
            }
            return _parametersAll;
        }

        public ProductBlock GetProductBlock(IEnumerable<Parameter> parameters)
        {
            return this._productBlocks
                .SingleOrDefault(productBlock => productBlock.Equals(new ProductBlock { Parameters = parameters.ToList() }));
        }
    }
}