using System;

namespace HVTApp.Infrastructure.Services
{
    public interface ILastUpdateMomentService
    {
        DateTime GetLastUpdateMomentOfParameters();
        void SetLastUpdateMomentOfParameters();
    }
}