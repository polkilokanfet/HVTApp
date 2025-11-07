using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Extensions;

namespace HVTApp.Model.POCOs
{
    [Designation("Департамент ОГК")]
    [DesignationPlural("Департаменты ОГК")]
    public class DesignDepartment : BaseEntity
    {
        [Designation("Название"), Required, MaxLength(120), OrderStatus(110)]
        public string Name { get; set; }

        [Designation("Руководитель"), OrderStatus(100)]
        public virtual User Head { get; set; }

        [Designation("Сотрудники"), Required, OrderStatus(90)]
        public virtual List<User> Staff { get; set; } = new List<User>();

        [Designation("Наблюдатели"), OrderStatus(85)]
        public virtual List<User> Observers { get; set; } = new List<User>();

        [Designation("Наборы параметров основного оборудования"), Required, OrderStatus(50)]
        public virtual List<DesignDepartmentParameters> ParameterSets { get; set; } = new List<DesignDepartmentParameters>();

        [Designation("Наборы параметров дополнительного оборудования"), OrderStatus(40)]
        public virtual List<DesignDepartmentParametersAddedBlocks> ParameterSetsAddedBlocks { get; set; } = new List<DesignDepartmentParametersAddedBlocks>();

        [Designation("Наборы параметров оборудования для подзадач"), OrderStatus(30)]
        public virtual List<DesignDepartmentParametersSubTask> ParameterSetsSubTask { get; set; } = new List<DesignDepartmentParametersSubTask>();

        [Designation("Комплекты деталей"), OrderStatus(20), NotForWrapper]
        public virtual List<Product> Kits { get; set; } = new List<Product>();

        /// <summary>
        /// КБ ремкомплектов
        /// </summary>
        [Designation("КБ ремкомплектов"), OrderStatus(10)]
        public bool IsKitDepartment { get; set; }

        /// <summary>
        /// КБ с коэффициентом удорожания
        /// </summary>
        [Designation("КБ с коэффициентом удорожания"), OrderStatus(10)]
        public bool IsPriceIncreaseFactor { get; set; } = false;

        /// <summary>
        /// Блок продукта подходит этому департаменту
        /// </summary>
        /// <param name="productBlock"></param>
        /// <returns></returns>
        public bool ProductBlockIsSuitable(ProductBlock productBlock)
        {
            return ParameterSets.Any(designDepartmentParameters => designDepartmentParameters.Parameters.AllContainsInById(productBlock.Parameters));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}