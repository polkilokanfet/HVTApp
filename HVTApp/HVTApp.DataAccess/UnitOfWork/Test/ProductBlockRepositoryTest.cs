using System.Collections.Generic;
using HVTApp.Model.POCOs;
using HVTApp.TestDataGenerator;

namespace HVTApp.DataAccess
{
    public partial class ProductBlockRepositoryTest : TestBaseRepository<ProductBlock>, IProductBlockRepository
    {
        public ProductBlock GetByParameters(IEnumerable<Parameter> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}