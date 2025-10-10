using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;

namespace HVTApp.DataAccess
{
    public partial class ProductBlockRepository
    {
        protected override IQueryable<ProductBlock> GetQuery()
        {
            return Context.Set<ProductBlock>().AsQueryable()
                .Include(block => block.Prices)
                .Include(block => block.FixedCosts)
                .Include(block => block.Parameters);
        }

        public override UnitOfWorkOperationResult Add(ProductBlock productBlock)
        {
            var checkResult = Check(productBlock);
            if (checkResult.OperationCompletedSuccessfully == false)
            {
                return checkResult;
            }

            return base.Add(productBlock);
        }

        public override UnitOfWorkOperationResult AddRange(IEnumerable<ProductBlock> blocks)
        {
            var results = new List<UnitOfWorkOperationResult>();
            foreach (var block in blocks)
            {
                results.Add(this.Add(block));
            }

            if (results.All(x => x.OperationCompletedSuccessfully))
            {
                return new UnitOfWorkOperationResult();
            }

            return new UnitOfWorkOperationResult(new Exception("Не все продукты удалось добавить в репозиторий"));
        }

        public ProductBlock GetByParameters(IEnumerable<Parameter> parameters)
        {
            var ids = parameters.Select(parameter => parameter.Id).ToList();
            var result = Context.Set<ProductBlock>().AsQueryable()
                .Include(productBlock => productBlock.Parameters)
                .SingleOrDefault(productBlock =>
                    productBlock.Parameters.Count == ids.Count &&
                    productBlock.Parameters
                        .Select(parameter => parameter.Id)
                        .Except(ids)
                        .Any() == false);
            return result;
        }


        private UnitOfWorkOperationResult Check(ProductBlock productBlock)
        {
            if (this.GetById(productBlock.Id) != null)
            {
                return new UnitOfWorkOperationResult(new Exception("ProductBlock с таким Id уже присутствует в репозитории"));
            }

            if (this.FindAsNoTracking(x => x.Equals(productBlock)).Any())
            {
                return new UnitOfWorkOperationResult(new Exception("ProductBlock с таким набором параметров уже присутствует в репозитории"));
            }

            return new UnitOfWorkOperationResult();
        }

    }
}