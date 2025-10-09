using System.Collections.Generic;
using HVTApp.DataAccess.Annotations;
using HVTApp.Model.POCOs;

namespace HVTApp.Services.GetProductService
{
    public interface IGetService
    {
        IEnumerable<Parameter> GetParameters(ProductBlock productBlock);
        [CanBeNull] ProductBlock GetProductBlock(IEnumerable<Parameter> parameters);
    }
}