using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.Comparers;

namespace HVTApp.Model.POCOs
{
    [Designation("Продукт"), DesignationPlural("Продукты")]
    public partial class Product : BaseEntity//, IEquatable<Product>
    {
        private string _designation = null;

        #region NotMapped

        [Designation("Обозначение"), NotMapped, OrderStatus(8)]
        public string Designation => _designation ?? (_designation = DesignationSpecial ?? GlobalAppProperties.ProductDesignationService.GetDesignation(this));

        private ProductType _type;
        [Designation("Тип"), NotMapped, OrderStatus(10)]
        public ProductType ProductType => _type ?? (_type = GlobalAppProperties.ProductDesignationService.GetProductType(this));

        private ProductCategory _category;
        [Designation("Категория"), NotMapped, OrderStatus(9)]
        public ProductCategory Category => _category ?? (_category = GlobalAppProperties.ProductDesignationService.GetProductCategory(this));

        /// <summary>
        /// В продукте есть блоки с фиксированной ценой
        /// </summary>
        [Designation("В продукте есть блоки с фиксированной ценой"), NotMapped]
        public bool HasBlockWithFixedCost
        {
            get
            {
                if (ProductBlock.HasFixedPrice) return true;
                if (DependentProducts.Any(productDependent => productDependent.Product.HasBlockWithFixedCost)) return true;
                return false;
            }
        }

        #endregion

        [Designation("Специальное обозначение"), MaxLength(256), OrderStatus(6)]
        public string DesignationSpecial { get; set; }

        [Designation("Блок"), Required, OrderStatus(5)]
        public virtual ProductBlock ProductBlock { get; set; }

        [Designation("Продукты в составе")]
        public virtual List<ProductDependent> DependentProducts { get; set; } = new List<ProductDependent>();

        [Designation("Комментарий"), MaxLength(256)]
        public string Comment { get; set; }

        [Designation("КБ ремкомплектов"), OrderStatus(20)]
        public virtual List<DesignDepartment> DesignDepartmentsKits { get; set; } = new List<DesignDepartment>();

        /// <summary>
        /// Продукт является ремкомплектом
        /// </summary>
        [NotMapped]
        public bool IsKit => DesignDepartmentsKits.Any();

        public override bool Equals(object obj)
        {
            return base.Equals(obj) || 
                   Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = ProductBlock != null 
                    ? ProductBlock.GetHashCode() 
                    : 0;
                hashCode = (hashCode * 397) ^ (DependentProducts != null 
                    ? DependentProducts.GetHashSum() 
                    : 0);
                return hashCode;
            }
        }

        protected bool Equals(Product other)
        {
            if (other == null) 
                return false;

            //если составные части не совпадают
            if (this.ProductBlock.Equals(other.ProductBlock) == false) 
                return false;

            if (this.GetHashCode() != other.GetHashCode()) 
                return false;

            //если зависимые продукты не совпадают / совпадают
            return DependentProducts.MembersAreSame(other.DependentProducts, new ProductDependentComparer());
        }

        public override string ToString()
        {
            var type = ProductType == null ? string.Empty : $"{ProductType} ";
            if (!string.IsNullOrEmpty(DesignationSpecial)) return $"{type}{DesignationSpecial}";
            if (!string.IsNullOrEmpty(Designation)) return $"{type}{Designation}";
            return ProductBlock.ToString();
        }

        /// <summary>
        /// Возвращает все блоки оборудования
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductBlock> GetBlocks()
        {
            yield return this.ProductBlock;

            foreach (var dependentProduct in DependentProducts)
            {
                foreach (var productBlock in dependentProduct.Product.GetBlocks())
                {
                    yield return productBlock;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            yield return this;

            foreach (var dependentProduct in DependentProducts)
            {
                foreach (var product in dependentProduct.Product.GetProducts())
                {
                    yield return product;
                }
            }
        }



        public string GetFullDescription(int spaceCount = 0)
        {
            var sb = new StringBuilder();
            sb.Append($"{Designation} ");
            sb.Append($"{this} (параметры: {ProductBlock.ParametersToString().ToLower()})".AddSpacesBefore(spaceCount));
            if (DependentProducts.Any())
            {
                spaceCount++;
                sb.AppendLine("Составные части:".AddSpacesBefore(spaceCount));
                foreach (var dependentProduct in DependentProducts)
                {
                    sb.AppendLine($"{dependentProduct.Amount} шт. " + dependentProduct.Product.GetFullDescription(spaceCount).AddSpacesBefore(spaceCount));
                }
            }

            return sb.ToString();
        }
    }

    public static class StringExt
    {
        public static string AddSpacesBefore(this string targetString, int spaceCount)
        {
            var specesToAdd = string.Empty;
            for (int i = 0; i < spaceCount; i++)
            {
                specesToAdd += "::";
            }
            return specesToAdd + targetString;
        }
    }
}
