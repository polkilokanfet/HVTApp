using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.POCOs;

namespace LastUpdateMomentService
{
    public class Service : ILastUpdateMomentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DateTime GetLastUpdateMomentOfParameters()
        {
            return _unitOfWork.Repository<GlobalProperties>().GetAll().Single().Date;
        }

        public void SetLastUpdateMomentOfParameters()
        {
            _unitOfWork.Repository<GlobalProperties>().GetAll().Single().Date = DateTime.Now;
            _unitOfWork.SaveChanges();
        }
    }
}