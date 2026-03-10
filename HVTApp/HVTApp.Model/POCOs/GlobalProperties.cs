using System;
using System.ComponentModel.DataAnnotations;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;

namespace HVTApp.Model.POCOs
{
    [Designation("Общие настройки")]
    public class GlobalProperties : BaseEntity
    {
        [Designation("Дата настроек"), Required, OrderStatus(20)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Designation("Наша компания"), Required, OrderStatus(19)]
        public virtual Company OurCompany { get; set; }

        [Designation("Срок актуальности себестоимости"), Required]
        public int ActualPriceTerm { get; set; } = 90;

        [Designation("Стандартный срок производства"), Required]
        public int StandartTermFromStartToEndProduction { get; set; } = 120;

        [Designation("Стандартный срок сборки"), Required]
        public int StandartTermFromPickToEndProduction { get; set; } = 7;

        [Designation("Стандартные условия оплаты"), Required]
        public virtual PaymentConditionSet StandartPaymentsConditionSet { get; set; }

        [Designation("НДС"), Required]
        public double Vat { get; set; } = 22;

        [Designation("Родительский параметр новых параметров"), Required]
        public virtual Parameter NewProductParameter { get; set; }

        [Designation("Группа новых параметров"), Required]
        public virtual ParameterGroup NewProductParameterGroup { get; set; }


        [Designation("Признак услуги"), Required, OrderStatus(301)]
        public virtual Parameter ServiceParameter { get; set; }

        [Designation("Признак шеф-монтажа"), Required, OrderStatus(302)]
        public virtual Parameter SupervisionParameter { get; set; }

        [Designation("Группа параметров номинального напряжения"), Required, OrderStatus(303)]
        public virtual ParameterGroup VoltageGroup { get; set; }

        [Designation("Группа параметров материала изоляции"), OrderStatus(304)]
        public virtual ParameterGroup IsolationMaterialGroup { get; set; }

        [Designation("Группа параметров цвета изоляции"), OrderStatus(305)]
        public virtual ParameterGroup IsolationColorGroup { get; set; }

        [Designation("Группа параметров ДПУ изолятора"), OrderStatus(306)]
        public virtual ParameterGroup IsolationDpuGroup { get; set; }


        [Designation("Группа параметров обозначения комплекта или детали"), Required, OrderStatus(-50)]
        public virtual ParameterGroup ComplectDesignationGroup{ get; set; }

        [Designation("Параметр комплекты и детали"), Required, OrderStatus(-50)]
        public virtual Parameter ComplectsParameter { get; set; }

        [Designation("Группа типа комплекта или детали"), Required, OrderStatus(-50)]
        public virtual ParameterGroup ComplectsGroup { get; set; }


        [Designation("Тип проекта (по умолчанию)"), Required]
        public virtual ProjectType DefaultProjectType { get; set; }

        [Designation("Получатель писем по ШМ"), Required]
        public virtual Employee RecipientSupervisionLetterEmployee { get; set; }

        [Designation("Отправитель ТКП"), Required]
        public virtual Employee SenderOfferEmployee { get; set; }

        [Designation("Производитель ВВА"), Required]
        public virtual ActivityField HvtProducersActivityField { get; set; }

        [Designation("Стандартные условия оплаты"), Required]
        public virtual PaymentConditionSet PaymentConditionSet { get; set; }


        [Designation("Путь к папке с запросами"), Required, OrderStatus(500), MaxLength(500)]
        public string IncomingRequestsPath { get; set; }

        [Designation("Путь к папке с приложениями Directum"), Required, OrderStatus(501), MaxLength(500)]
        public string DirectumAttachmentsPath { get; set; }

        [Designation("Путь к папке с файлами ТЗ"), Required, OrderStatus(502), MaxLength(500)]
        public string TechnicalRequrementsFilesPath { get; set; }

        [Designation("Путь к папке с файлами ответов из ТСЕ"), Required, OrderStatus(503), MaxLength(500)]
        public string TechnicalRequrementsFilesAnswersPath { get; set; }

        [Designation("Путь к папке с расчетами транспортных затрат"), Required, OrderStatus(503), MaxLength(500)]
        public string ShippingCostFilesPath { get; set; }

        [Designation("Путь к папке с расчетами себестоимости"), Required, OrderStatus(504), MaxLength(500)]
        public string PriceCalculationsFilesPath { get; set; }

        [Designation("Путь к папке с логами"), OrderStatus(505), MaxLength(500)]
        public string LogsPath { get; set; }



        [Designation("Разработчик")]
        public virtual User Developer { get; set; }

        [Designation("Дата последнего визита разработчика")]
        public virtual DateTime? LastDeveloperVizit { get; set; }

        [Designation("Дополнительное оборудование")]
        public virtual Product ProductIncludedDefault { get; set; }

        /// <summary>
        /// Параметр пустого блока ТТ
        /// Используется для технико-стоимостной проработки
        /// </summary>
        [Designation("Параметр пустого блока ТТ"), OrderStatus(-100)]
        public virtual Parameter EmptyParameterCurrentTransformersSet { get; set; }

        [Designation("Параметр блока ТТ по заказу"), OrderStatus(-200)]
        public virtual Parameter ParameterCurrentTransformersSetCustom { get; set; }

        //[Designation("Путь к файлу с датами комплектации заказов")]
        //public string PickingDatesFilePath { get; set; }
    }
}