using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;

namespace HVTApp.DataAccess
{
    public partial class ProductRepository
    {
        protected override IQueryable<Product> GetQuery()
        {
            return Context.Set<Product>().AsQueryable()
                .Include(product => product.ProductBlock)
                .Include(product => product.DependentProducts);
        }

        public override UnitOfWorkOperationResult Add(Product product)
        {
            var contains = CanAdd(product);
            return contains.OperationCompletedSuccessfully == false 
                ? contains 
                : base.Add(product);
        }

        public override UnitOfWorkOperationResult AddRange(IEnumerable<Product> products)
        {
            var results = new List<UnitOfWorkOperationResult>();
            foreach (var product in products)
            {
                results.Add(this.Add(product));
            }

            if (results.All(x => x.OperationCompletedSuccessfully))
            {
                return new UnitOfWorkOperationResult();
            }

            return new UnitOfWorkOperationResult(new Exception("Не все продукты удалось добавить в репозиторий"));
        }

        public UnitOfWorkOperationResult CanAdd(Product product)
        {
            if (this.GetById(product.Id) != null)
            {
                return new UnitOfWorkOperationResult(new Exception("Product с таким Id уже присутствует в репозитории"));
            }

            if (this.FindAsNoTracking(x => x.Equals(product)).Any())
            {
                return new UnitOfWorkOperationResult(new Exception("Product с таким набором (ProductBlock + DependentProducts) уже присутствует в репозитории"));
            }

            return new UnitOfWorkOperationResult();
        }

        public Product Get(Product product)
        {
            var result = this.GetById(product.Id);
            return result ?? this.Find(x => x.Equals(product)).SingleOrDefault();
        }

        private void SubstitutionProducts(Product product, ICollection<Product> uniqProducts)
        {
            foreach (var dependentProduct in product.DependentProducts)
            {
                if (uniqProducts.Contains(dependentProduct.Product))
                {
                    dependentProduct.Product = uniqProducts.Single(product1 => product1.Equals(dependentProduct.Product));
                }

                SubstitutionProducts(dependentProduct.Product, uniqProducts);
            }
        }

    }
}
