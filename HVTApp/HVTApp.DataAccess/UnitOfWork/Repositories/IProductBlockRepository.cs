using System.Collections.Generic;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;

namespace HVTApp.DataAccess
{
    public partial interface IProductBlockRepository : IRepository<ProductBlock>
    {
        ProductBlock GetByParameters(IEnumerable<Parameter> parameters);
    }
}