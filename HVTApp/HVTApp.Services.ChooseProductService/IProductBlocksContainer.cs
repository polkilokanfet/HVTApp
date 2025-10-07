using System.Collections.Generic;
using HVTApp.DataAccess.Annotations;
using HVTApp.Model.POCOs;

namespace HVTApp.Services.GetProductService
{
    public interface IProductBlocksContainer
    {
        [CanBeNull] ProductBlock GetProductBlock(IEnumerable<Parameter> parameters);
    }
}