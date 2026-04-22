namespace HVTApp.DataAccess
{
    public partial class SalesUnitConfiguration 
    {
        public SalesUnitConfiguration()
        {
            HasRequired(x => x.Project).WithMany(project => project.SalesUnits).HasForeignKey(x => x.ProjectId).WillCascadeOnDelete(false);
            HasRequired(x => x.Facility).WithMany().HasForeignKey(x => x.FacilityId).WillCascadeOnDelete(false);
            HasRequired(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
            HasRequired(x => x.PaymentConditionSet).WithMany().HasForeignKey(x => x.PaymentConditionSetId).WillCascadeOnDelete(false);

            HasMany(x => x.ProductsIncluded).WithMany();
            Property(x => x.ProductionTerm).IsOptional();
            Property(x => x.Cost).IsRequired();

            HasOptional(x => x.Producer).WithMany().WillCascadeOnDelete(false);

            HasMany(x => x.LosingReasons).WithMany();

            HasRequired(x => x.Product).WithMany().WillCascadeOnDelete(false);
            HasOptional(x => x.Order).WithMany().WillCascadeOnDelete(false);

            Property(x => x.SerialNumber).IsOptional();
            Property(x => x.OrderPosition).IsOptional();
            Property(x => x.ProductionTerm).IsOptional();
            Property(x => x.AssembleTerm).IsOptional();

            Property(x => x.StartProductionDate).IsOptional();
            Property(x => x.PickingDate).IsOptional();
            Property(x => x.EndProductionDate).IsOptional();

            HasOptional(x => x.Specification).WithMany(specification => specification.SalesUnits).WillCascadeOnDelete(false);

            Property(x => x.Cost).IsRequired();

            HasMany(x => x.PaymentsPlanned).WithRequired().WillCascadeOnDelete(true);
            HasMany(x => x.PaymentsActual).WithRequired(x => x.SalesUnit).HasForeignKey(x => x.SalesUnitId).WillCascadeOnDelete(true);
            Property(x => x.RealizationDate).IsOptional();

            HasOptional(x => x.AddressDelivery).WithMany();
            Property(x => x.ExpectedDeliveryPeriod).IsOptional();
            Property(x => x.ShipmentDate).IsOptional();
            Property(x => x.ShipmentPlanDate).IsOptional();
            Property(x => x.DeliveryDate).IsOptional();

            HasOptional(x => x.Penalty).WithRequired().WillCascadeOnDelete(true);
        }
    }
}