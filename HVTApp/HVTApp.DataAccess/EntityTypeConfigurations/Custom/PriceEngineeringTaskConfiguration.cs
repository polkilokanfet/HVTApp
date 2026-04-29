namespace HVTApp.DataAccess
{
    public partial class PriceEngineeringTaskConfiguration
    {
        public PriceEngineeringTaskConfiguration()
        {
            HasOptional(task => task.UserPlanMaker).WithMany().WillCascadeOnDelete(false);
            HasOptional(task => task.UserConstructor).WithMany().WillCascadeOnDelete(false);
            HasOptional(task => task.UserConstructorInitiator).WithMany().WillCascadeOnDelete(false);
            HasOptional(task => task.UserConstructorInspector).WithMany().WillCascadeOnDelete(false);

            HasRequired(task => task.ProductBlockManager).WithMany().WillCascadeOnDelete(false);
            HasRequired(task => task.ProductBlockEngineer).WithMany().WillCascadeOnDelete(false);
            HasOptional(task => task.DesignDepartment).WithMany().WillCascadeOnDelete();
            HasMany(task => task.ProductBlocksAdded).WithRequired().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(true);

            HasMany(task => task.FilesTechnicalRequirements).WithMany();
            HasMany(task => task.FilesAnswers).WithRequired().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(true);

            HasMany(task => task.Messages).WithRequired().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(true);
            HasMany(task => task.ChildPriceEngineeringTasks).WithOptional().HasForeignKey(task => task.ParentPriceEngineeringTaskId).WillCascadeOnDelete(false);

            HasMany(task => task.Statuses).WithRequired().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(true);

            HasMany(task => task.SalesUnits).WithMany(salesUnit => salesUnit.PriceEngineeringTasks);

            HasMany(task => task.StructureCostVersions).WithOptional().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(true);

            HasMany(task => task.PriceCalculationItems).WithOptional().HasForeignKey(task => task.PriceEngineeringTaskId).WillCascadeOnDelete(false);
            HasMany(task => task.UpdateStructureCostNumberTasks).WithRequired().WillCascadeOnDelete(false);

            //HasMany(task => task.PriceEngineeringTasksToSplit)
            //    .WithOptional()
            //    .HasForeignKey(task => task.PriceEngineeringTaskToSplitFrontId)
            //    .WillCascadeOnDelete(false);
        }
    }
}