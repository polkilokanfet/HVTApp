using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;

namespace HVTApp.DataAccess
{
    public partial interface IProductRepository
    {
        UnitOfWorkOperationResult CanAdd(Product product);
        Product Get(Product product);
    }
}