using HVTApp.Model.POCOs;

namespace HVTApp.Model.Services
{
    public interface IRemoveService
    {
        /// <summary>
        /// Удалить SalesUnit
        /// </summary>
        /// <param name="salesUnit"></param>
        /// <returns>true - удалено из БД, false - не удалено, null - назначен статус IsRemoved</returns>
        bool? Remove(SalesUnit salesUnit);
    }
}