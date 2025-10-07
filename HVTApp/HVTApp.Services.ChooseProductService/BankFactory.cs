using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.DataAccess;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.POCOs;

namespace HVTApp.Services.GetProductService
{
    class BankFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILastUpdateMomentService _lastUpdateMomentService;

        public BankFactory(IUnitOfWork unitOfWork, ILastUpdateMomentService lastUpdateMomentService)
        {
            _unitOfWork = unitOfWork;
            _lastUpdateMomentService = lastUpdateMomentService;
        }

        private List<Parameter> _parameters;
        private List<ProductRelation> _productRelations;
        private DateTime _lastUpdateMomentOfParameters;
        private IEnumerable<Parameter> GetParameters()
        {
            if (_parameters is null || _lastUpdateMomentService.GetLastUpdateMomentOfParameters() > _lastUpdateMomentOfParameters)
            {
                _parameters = _unitOfWork.Repository<Parameter>().GetAll();
                _lastUpdateMomentOfParameters = _lastUpdateMomentService.GetLastUpdateMomentOfParameters();
            }
            return _parameters;
        }
        private IEnumerable<ProductRelation> GetProductRelations()
        {
            if (_productRelations is null || _lastUpdateMomentService.GetLastUpdateMomentOfParameters() > _lastUpdateMomentOfParameters)
            {
                _productRelations = _unitOfWork.Repository<ProductRelation>().GetAll();
                _lastUpdateMomentOfParameters = _lastUpdateMomentService.GetLastUpdateMomentOfParameters();
            }
            return _productRelations;
        }

        /// <summary>
        /// Формирование банка для выбора продукта.
        /// </summary>
        /// <param name="originProduct"></param>
        /// <returns></returns>
        public Bank CreateBank(Product originProduct = null)
        {
            return this.GetBank(GetParameters(originProduct));
        }

        /// <summary>
        /// Формирование банка для выбора блока продукта.
        /// </summary>
        /// <param name="requiredParameters">Обязательные параметры в селекторе</param>
        /// <returns></returns>
        public Bank CreateBank(IEnumerable<Parameter> requiredParameters)
        {
            var parameters = GetParameters();

            if (requiredParameters != null)
            {
                //находим максимальное количество пересечений путей параметров
                List<Parameter> requiredPathParameters = null;
                var requiredParametersArray = requiredParameters as Parameter[] ?? requiredParameters.ToArray();
                foreach (var requiredParameter in requiredParametersArray)
                {
                    var pathsParameters = requiredParameter.Paths()
                        .SelectMany(path => path.Parameters)
                        .Distinct()
                        .ToList();

                    requiredPathParameters = requiredPathParameters == null 
                        ? pathsParameters 
                        : pathsParameters.Intersect(requiredPathParameters).ToList();
                }

                //оставляем обязательные параметры "одинокими"
                foreach (var parameter in requiredPathParameters.Union(requiredParametersArray).Distinct())
                {
                    parameters = parameters.LeaveParameterAloneInGroup(parameter);
                }

                parameters = parameters.Union(requiredParametersArray).ToList();
            }

            return this.GetBank(parameters.RemoveUnreachable());
        }


        /// <summary>
        /// Формирование банка для выбора блока продукта.
        /// </summary>
        /// <returns></returns>
        public Bank CreateBankP(IEnumerable<Parameter> parameters)
        {
            return this.GetBank(parameters);
        }

        private Bank GetBank(IEnumerable<Parameter> parameters)
        {
            var relations = GetProductRelations();
            var blocks = _unitOfWork.Repository<ProductBlock>()
                .Find(block => block.DesignationSpecial != null);
            var specialDesignationsDictionary = blocks
                .ToDictionary(block => block.GetHashCode(), block => block.DesignationSpecial);

            return new Bank(parameters, specialDesignationsDictionary, relations);
        }

        private IEnumerable<Parameter> GetParameters(Product originProduct = null)
        {
            return this.GetParameters()
                .WithoutComplects(originProduct)
                .WithoutNew(originProduct);
        }
    }
}