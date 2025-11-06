using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;

namespace HVTApp.Model.POCOs
{
    [Designation("Стракчакост")]
    public class StructureCost : BaseEntity
    {
        public Guid PriceCalculationItemId { get; set; }

        [Designation("Номер"), Required, MaxLength(50)]
        public string Number { get; set; }

        /// <summary>
        /// Номер scc оригинального блока (блока при котором был создан данный стракчакост)
        /// </summary>
        [Designation("Номер scc оригинального блока"), MaxLength(50)]
        public string OriginalStructureCostNumber { get; set; }

        /// <summary>
        /// Оригинальный блок scc (блока при котором был создан данный стракчакост)
        /// </summary>
        [Designation("Оригинальный блок scc")]
        public virtual ProductBlock OriginalStructureCostProductBlock { get; set; }

        /// <summary>
        /// Количество (числитель)
        /// </summary>
        [Designation("Количество (числитель)"), Required]
        public double AmountNumerator { get; set; } = 1;

        /// <summary>
        /// Количество (знаменатель)
        /// </summary>
        [Designation("Количество (знаменатель)"), Required]
        public double AmountDenomerator { get; set; } = 1;

        [Designation("Количество на единицу"), NotMapped]
        public double Amount => AmountDenomerator > 0
            ? AmountNumerator / AmountDenomerator
            : 1;

        [Designation("Себестоимость единицы")]
        public double? UnitPrice { get; set; }

        public double? Total => UnitPrice * Amount;

        [Designation("Комментарий"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        [Designation("Коэффициент удорожания")]
        public double? PriceIncreaseFactor { get; set; }


        public override string ToString()
        {
            return $"{Comment} = {Amount:N2} шт. = {Number}";
        }
    }
}