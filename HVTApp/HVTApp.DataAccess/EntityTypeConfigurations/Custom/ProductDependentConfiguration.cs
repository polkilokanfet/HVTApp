namespace HVTApp.DataAccess
{
    public partial class ProductDependentConfiguration
    {
        public ProductDependentConfiguration()
        {
            HasRequired(productDependent => productDependent.Product).WithMany().WillCascadeOnDelete(false);
            Property(productDependent => productDependent.Amount).IsRequired();
        }
    }
}