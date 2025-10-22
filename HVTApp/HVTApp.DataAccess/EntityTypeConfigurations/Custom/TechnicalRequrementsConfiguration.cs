namespace HVTApp.DataAccess
{
    public partial class TechnicalRequrementsConfiguration
    {
        public TechnicalRequrementsConfiguration()
        {
            HasMany(technicalRequrements => technicalRequrements.SalesUnits).WithMany(x => x.TechnicalRequirements);
            HasMany(technicalRequrements => technicalRequrements.Files).WithMany();
        }
    }
}