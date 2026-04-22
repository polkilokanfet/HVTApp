using System;
using System.ComponentModel.DataAnnotations;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;

namespace HVTApp.Model.POCOs
{
    [Designation("Платеж совершённый")]
    public partial class PaymentActual : BaseEntity
    {
        public Guid SalesUnitId { get; set; }

        [NotForWrapper, NotForDetailsView, NotForListView]
        public virtual SalesUnit SalesUnit { get; set; }

        public Guid PaymentDocumentId { get; set; }

        [NotForWrapper, NotForDetailsView, NotForListView]
        public virtual PaymentDocument PaymentDocument { get; set; }

        [Designation("Дата"), Required]
        public DateTime Date { get; set; }

        [Designation("Сумма"), Required]
        public double Sum { get; set; }

        [Designation("Комментарий"), MaxLength(50)]
        public string Comment { get; set; }

        public override string ToString()
        {
            return $"сумма: {Sum:N} руб. без НДС, дата: {Date.ToShortDateString()} г.";
        }
    }
}