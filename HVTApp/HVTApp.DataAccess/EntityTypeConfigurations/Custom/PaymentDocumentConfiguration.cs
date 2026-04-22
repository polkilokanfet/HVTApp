namespace HVTApp.DataAccess
{
    public partial class PaymentDocumentConfiguration
    {
        public PaymentDocumentConfiguration()
        {
            Property(paymentDocument => paymentDocument.Number).IsOptional();
            HasMany(paymentDocument => paymentDocument.Payments)
                .WithRequired(paymentActual => paymentActual.PaymentDocument)
                .HasForeignKey(paymentActual => paymentActual.PaymentDocumentId)
                .WillCascadeOnDelete(true);
        }
    }
}