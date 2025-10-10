using System.Collections.Generic;
using HVTApp.Model.POCOs;

namespace HVTApp.Services.GetProductService
{
    internal class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x != null && x.Equals(y);
        }

        public int GetHashCode(Product product)
        {
            return 0;
        }
    }
    internal class DependentProductComparer : IEqualityComparer<ProductDependent>
    {
        public bool Equals(Product x, Product y)
        {
            return x != null && x.Equals(y);
        }

        public bool Equals(ProductDependent x, ProductDependent y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Amount == y.Amount && x.Equals(y);
        }

        public int GetHashCode(ProductDependent obj)
        {
            return 0;
        }
    }
}