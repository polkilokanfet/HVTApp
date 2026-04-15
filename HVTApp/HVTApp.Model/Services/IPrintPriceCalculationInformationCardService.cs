using HVTApp.Model.POCOs;

namespace HVTApp.Model.Services
{
    public interface IPrintPriceCalculationInformationCardService
    {
        void Print(PriceCalculation calculation);
    }
}