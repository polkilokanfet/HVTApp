using System;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;

namespace HVTApp.Services.AllowStartService
{
    public class LastUpdateMomentService : ILastUpdateMomentService
    {
        private readonly IUnityContainer _container;

        public LastUpdateMomentService(IUnityContainer container)
        {
            _container = container;
        }

        public DateTime GetLastUpdateMomentOfParameters()
        {
            using (var unitOfWork = _container.Resolve<IUnitOfWork>())
            {
                return unitOfWork.Repository<GlobalProperties>().GetAll().Single().Date;
            }
        }

        public void SetLastUpdateMomentOfParameters()
        {
            using (var unitOfWork = _container.Resolve<IUnitOfWork>())
            {
                unitOfWork.Repository<GlobalProperties>().GetAll().Single().Date = DateTime.Now;
                unitOfWork.SaveChanges();
            }
        }
    }
}