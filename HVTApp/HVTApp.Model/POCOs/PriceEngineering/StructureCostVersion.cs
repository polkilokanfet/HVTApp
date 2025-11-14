using System;
using System.ComponentModel.DataAnnotations;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;

namespace HVTApp.Model.POCOs
{
    [Designation("Технико-стоимостная проработка - версия стракчакоста")]
    [DesignationPlural("Технико-стоимостная проработка - версии стракчакоста")]
    public class StructureCostVersion : BaseEntity
    {
        public Guid? PriceEngineeringTaskId { get; set; }
        public Guid? PriceEngineeringTaskProductBlockAddedId { get; set; }
        
        /// <summary>
        /// Номер оригинального SCC (от ОГК)
        /// </summary>
        [Designation("Номер оригинального SCC"), MaxLength(50)]
        public string OriginalStructureCostNumber { get; set; }

        [Designation("Версия стракчакоста")]
        public int? Version { get; set; } = null;

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        [Designation("Коэффициент удорожания")]
        public double? PriceIncreaseFactor { get; set; }
    }
}