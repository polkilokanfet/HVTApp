using System;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;

namespace HVTApp.DataAccess
{
    public class RemoveService : IRemoveService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public RemoveService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public bool? Remove(SalesUnit salesUnit)
        {
            using (var unitOfWork = _unitOfWorkFactory.GetUnitOfWork())
            {
                var targetSalesUnit = unitOfWork.Repository<SalesUnit>().GetById(salesUnit.Id);
                if (targetSalesUnit == null)
                    return true;

                if (targetSalesUnit.Order != null)
                    return false;

                try
                {
                    unitOfWork.Repository<SalesUnit>().Delete(targetSalesUnit);
                    unitOfWork.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    targetSalesUnit.IsRemoved = true;
                    unitOfWork.SaveChanges();
                    return null;
                }
            }
        }
    }
}