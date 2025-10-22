using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Attributes;
using HVTApp.Infrastructure.Extensions;

namespace HVTApp.Model.POCOs
{
    [Designation("Единица продаж")]
    public partial class SalesUnit : BaseEntity, IUnit, ICloneable
    {
        #region Model

        [Designation("Объект"), OrderStatus(1000), Required]
        public virtual Facility Facility { get; set; }

        [NotForDetailsView, NotForListView]
        public virtual Guid FacilityId { get; set; }

        [Designation("Продукт"), Required, OrderStatus(995)]
        public virtual Product Product { get; set; }

        [NotForDetailsView, NotForListView]
        public virtual Guid ProductId { get; set; }

        [Designation("Стоимость"), Required, OrderStatus(990)]
        public double Cost { get; set; }

        /// <summary>
        /// Стоимость для формирования бюджета (с запасом)
        /// </summary>
        [Designation("Стоимость для формирования бюджета"), OrderStatus(990)]
        public double? CostWithReserve { get; set; }

        [Designation("Себестоимость"), OrderStatus(985)]
        public double? Price { get; set; }

        [Designation("Нормо-часы"), OrderStatus(980)]
        public double? LaborHours { get; set; }

        [Designation("Включенные продукты")]
        public virtual List<ProductIncluded> ProductsIncluded { get; set; } = new List<ProductIncluded>();

        [Designation("Условия оплаты"), Required]
        public virtual PaymentConditionSet PaymentConditionSet { get; set; }

        [NotForDetailsView, NotForListView]
        public virtual Guid PaymentConditionSetId { get; set; }

        [Designation("Срок производства"), Required]
        public int ProductionTerm { get; set; } = GlobalAppProperties.Actual.StandartTermFromStartToEndProduction;

        [Designation("Комментарий"), MaxLength(150)]
        public string Comment { get; set; }

        #region Проект

        [Designation("Проект"), OrderStatus(1005)]
        public virtual Project Project { get; set; }

        [NotForDetailsView, NotForListView]
        public virtual Guid ProjectId { get; set; }

        /// <summary>
        /// Требуемая дата поставки
        /// </summary>
        [Designation("Требуемая дата поставки"), Required]
        public virtual DateTime DeliveryDateExpected { get; set; } =
            DateTime.Today.AddDays(GlobalAppProperties.Actual.StandartTermFromStartToEndProduction + 120).SkipWeekend();

        [Designation("Производитель")]
        public virtual Company Producer { get; set; }

        [Designation("Причины проигрыша")]
        public virtual List<LosingReason> LosingReasons { get; set; } = new List<LosingReason>();

        [Designation("Дата реализации")]
        public virtual DateTime? RealizationDate { get; set; }

        #endregion

        #region Информация о производстве

        [Designation("Заказ")]
        public virtual Order Order { get; set; }

        [Designation("Позиция"), MaxLength(4)]
        public string OrderPosition { get; set; }

        [Designation("Номер"), MaxLength(10)]
        public string SerialNumber { get; set; }

        [Designation("Срок сборки")]
        public int? AssembleTerm { get; set; }

        [Designation("Сигнал менеджера о производстве")]
        public DateTime? SignalToStartProduction { get; set; }

        [Designation("Дата размещения в производстве")]
        public DateTime? SignalToStartProductionDone { get; set; }

        [Designation("Дата начала производства")]
        public DateTime? StartProductionDate { get; set; }

        [Designation("Дата комплектации")]
        public DateTime? PickingDate { get; set; }

        [Designation("Плановая дата окончания производства")]
        public DateTime? EndProductionPlanDate { get; set; }

        [Designation("Дата окончания производства")]
        public DateTime? EndProductionDate { get; set; }

        #endregion

        #region Коммерческая информация

        [Designation("Спецификация")]
        public virtual Specification Specification { get; set; }

        [Designation("Совершённые платежи")]
        public virtual List<PaymentActual> PaymentsActual { get; set; } = new List<PaymentActual>();

        [Designation("Планируемые платежи")]
        public virtual List<PaymentPlanned> PaymentsPlanned { get; set; } = new List<PaymentPlanned>();

        [Designation("Штрафные санкции")]
        public virtual Penalty Penalty { get; set; }

        #endregion

        #region Отгрузочная информация


        [Designation("Стоимость доставки"), OrderStatus(980)]
        public double? CostDelivery { get; set; }

        [Designation("Стоимость доставки включена в основную стоимость")]
        public bool CostDeliveryIncluded { get; set; } = true;

        [Designation("Срок доставки")]
        public int? ExpectedDeliveryPeriod { get; set; }

        [Designation("Срок доставки расчетный"), NotMapped]
        public int? ExpectedDeliveryPeriodCalculated => GlobalAppProperties.ShippingService.DeliveryTerm(this);

        [Designation("Адрес доставки")]
        public virtual Address AddressDelivery { get; set; }

        [Designation("Дата отгрузки")]
        public virtual DateTime? ShipmentDate { get; set; }

        [Designation("Дата отгрузки (плановая)")]
        public virtual DateTime? ShipmentPlanDate { get; set; }

        [Designation("Дата поставки")]
        public virtual DateTime? DeliveryDate { get; set; }

        #endregion

        [Designation("Удален")]
        public bool IsRemoved { get; set; } = false;

        [NotForWrapper, NotForDetailsView]
        public virtual List<PriceCalculationItem> PriceCalculationItems { get; set; } = new List<PriceCalculationItem>();

        [NotForWrapper, NotForDetailsView, NotForListView]
        public virtual List<PriceEngineeringTask> PriceEngineeringTasks { get; set; } = new List<PriceEngineeringTask>();

        [NotForWrapper, NotForDetailsView, NotForListView]
        public virtual List<TechnicalRequrements> TechnicalRequirements { get; set; } = new List<TechnicalRequrements>();


        [NotMapped, Designation("Разрешение на редактирование стоимости")]
        public bool AllowEditCost => Specification == null;

        [NotMapped, Designation("Разрешение на редактирование техники")]
        public bool AllowEditProduct => SignalToStartProduction == null;

        [NotMapped, Designation("Проиграно")]
        public bool IsLoosen => Producer != null && Producer.Id != GlobalAppProperties.Actual.OurCompany.Id;

        [NotMapped, Designation("Выиграно")]
        public bool IsWon => Producer != null && Producer.Id == GlobalAppProperties.Actual.OurCompany.Id && OrderInTakeDate <= DateTime.Today;

        [NotMapped, Designation("Исполнено")]
        public bool IsDone
        {
            get
            {
                if (this.Product.ProductBlock.IsService)
                    return RealizationDateCalculated < DateTime.Today;

                return RealizationDateCalculated < DateTime.Today && ShipmentDateCalculated < DateTime.Today;
            }
        }

        [NotMapped, Designation("Id актуального расчета калькуляции")]
        public Guid ActualPriceCalculationItemId =>
            GlobalAppProperties.PriceService?.GetPriceCalculationItem(this)?.Id ?? default;




        /// <summary>
        /// Первый платеж по заказу
        /// </summary>
        [Designation("Дата первого платежа по заказу")]
        public DateTime? FirstPaymentDate { get; set; }

        /// <summary>
        /// Оплачено
        /// </summary>
        [Designation("Оплачено")]
        public double PaidSum { get; set; }




        public override string ToString()
        {
            if (Order != null)
                return $"{Product} для {Facility} (з/з {Order.Number}, поз.{OrderPosition})";

            return $"{Product} для {Facility}";
        }


        #endregion

        #region Func

        /// <summary>
        /// Заказ взят
        /// </summary>
        [Designation("Заказ взят")]
        public bool OrderIsTaken => !IsLoosen && StartProductionDateCalculated < DateTime.Today;

        /// <summary>
        /// Заказ реализован
        /// </summary>
        [Designation("Заказ реализован")]
        public bool OrderIsRealized => RealizationDateCalculated < DateTime.Today;


        /// <summary>
        /// Разрешено тотальное удаление юнита
        /// </summary>
        [Designation("Разрешено тотальное удаление")]
        public bool AllowTotalRemove
        {
            get
            {
                if (Order != null) return false;
                if (PriceEngineeringTasks.Any()) return false;
                if (TechnicalRequirements.Any()) return false;
                return true;
            }
        }

        [Designation("Адрес доставки (расчетный)")]
        public virtual Address AddressDeliveryCalculated => this.AddressDelivery ?? this.Facility.Address;


        /// <summary>
        /// Все платежи (совершенные + плановые).
        /// </summary>
        //public IEnumerable<IPayment> Payments => PaymentsActual.Cast<IPayment>().Union(PaymentsPlannedByConditions);

        #region Суммы
        [Designation("Оплачено?"), NotMapped]
        public bool IsPaid => Math.Abs(SumNotPaid) < 0.00001;

        /// <summary>
        /// Неоплаченная сумма без НДС
        /// </summary>
        [Designation("Неоплачено без НДС"), NotMapped]
        public double SumNotPaid => Cost - PaidSum;

        /// <summary>
        /// НДС
        /// </summary>
        [Designation("НДС"), NotMapped]
        public double Vat => Specification?.Vat ?? GlobalAppProperties.Actual.Vat;

        /// <summary>
        /// Неоплаченная сумма с НДС
        /// </summary>
        [Designation("Неоплачено с НДС"), NotMapped]
        public double SumNotPaidWithVat => SumNotPaid * (100.0 + Vat) / 100;


        /// <summary>
        /// Сумама, необходимая для начала производства
        /// </summary>
        [Designation("Сумма старта производства"), NotMapped]
        public double SumToStartProduction => PaymentConditionSet.PaymentConditions
            .Where(condition =>
                condition.PaymentConditionPoint.PaymentConditionPointEnum == PaymentConditionPointEnum.ProductionStart &&
                condition.DaysToPoint <= 0)
            .Sum(condition => Cost * condition.Part);

        /// <summary>
        /// Сумма, необходимая для отгрузки
        /// </summary>
        [Designation("Сумма отгрузки"), NotMapped]
        public double SumToShipping => PaymentConditionSet.PaymentConditions
            .Where(condition => 
                condition.PaymentConditionPoint.PaymentConditionPointEnum == PaymentConditionPointEnum.ProductionStart || 
                condition.PaymentConditionPoint.PaymentConditionPointEnum == PaymentConditionPointEnum.ProductionEnd || 
                condition.PaymentConditionPoint.PaymentConditionPointEnum == PaymentConditionPointEnum.Shipment && 
                condition.DaysToPoint <= 0).
            Sum(condition => Cost * condition.Part);

        #endregion

        #region Даты

        /// <summary>
        /// Дата ОИТ, внедренная извне (из отчета)
        /// </summary>
        [NotMapped]
        public DateTime? OrderInTakeDateInjected { get; set; }

        [Designation("ОИТ"), OrderStatus(990), NotMapped]
        public DateTime OrderInTakeDate
        {
            get
            {
                if (OrderInTakeDateInjected.HasValue)
                    return OrderInTakeDateInjected.Value.Date;

                //по дате подписания спецификации
                if (Specification?.SignDate != null)
                {
                    return Specification.SignDate.Value.Date;
                }

                //если для старта производства не требуется денег
                if (Specification != null)
                {
                    if (Cost > 0 && Math.Abs(SumToStartProduction) < 0.001)
                        return Specification.Date;
                }

                //первый платеж по заказу
                if (this.FirstPaymentDate.HasValue) return this.FirstPaymentDate.Value;
                
                //дата начала производства
                return StartProductionDateCalculated.Date;
            }
        }

        [Designation("Год ОИТ"), OrderStatus(985), NotMapped]
        public int OrderInTakeYear => OrderInTakeDate.Year;

        [Designation("Месяц ОИТ"), OrderStatus(980), NotMapped]
        public int OrderInTakeMonth => OrderInTakeDate.Month;

        /// <summary>
        /// Дата достижения суммы
        /// </summary>
        /// <param name="sumToAchive"></param>
        /// <returns></returns>
        private DateTime? AchiveSumDate(double sumToAchive)
        {
            var accuracy = 0.001;
            double sum = 0;
            foreach (var payment in PaymentsActual.OrderBy(paymentActual => paymentActual.Date))
            {
                sum += payment.Sum;
                if (sumToAchive - sum <= accuracy) return payment.Date.Date;
            }

            var dic = PaymentConditionsDictionary;
            foreach (var payment in PaymentsPlannedActual.OrderBy(paymentPlanned => paymentPlanned.Date))
            {
                //если пропущены какие-то условия перед сохраненными - выйти
                if (!Equals(dic.First(x => x.Value < 1).Key, payment.Condition))
                {
                    return null;
                }

                sum += payment.Part * payment.Condition.Part * Cost;
                if (sumToAchive - sum <= accuracy) return payment.Date.Date;

                dic[payment.Condition] += payment.Part;
            }
            return null;
        }

        /// <summary>
        /// Дата исполнения условий для запуска производства
        /// </summary>
        [Designation("Дата исполнения условий для начала производства"), OrderStatus(870), NotMapped]
        public DateTime? StartProductionConditionsDoneDate
        {
            get
            {
                //если для старта производства не требуется денег
                if (Cost > 0 && Math.Abs(SumToStartProduction) < 0.001)
                {
                    if (Specification != null)
                        return Specification.Date.Date;
                }

                //если требуются деньги
                return AchiveSumDate(SumToStartProduction);
            }
        }

        /// <summary>
        /// Дата исполнения условий для осуществления отгрузки
        /// </summary>
        [Designation("Дата исполнения условий для отгрузки"), OrderStatus(865), NotMapped]
        public DateTime? ShippingConditionsDoneDate => AchiveSumDate(SumToShipping);

        /// <summary>
        /// Внедренная дата начала производства (для отчета)
        /// </summary>
        [NotMapped]
        public DateTime? StartProductionDateInjected { get; set; }

        /// <summary>
        /// Расчетная дата начала производства.
        /// </summary>
        [Designation("Начало производства (расч.)"), OrderStatus(860), NotMapped]
        public DateTime StartProductionDateCalculated
        {
            get
            {
                if (StartProductionDateInjected.HasValue) return StartProductionDateInjected.Value.Date;

                if (StartProductionDate.HasValue) return StartProductionDate.Value.Date;

                //по исполнению условий, необходимых для запуска производства
                var startProductionConditionsDoneDate = StartProductionConditionsDoneDate;
                if (startProductionConditionsDoneDate.HasValue) return startProductionConditionsDoneDate.Value.Date;

                ////по дате открытия з/з
                //if (this.Order != null) return this.Order.DateOpen;

                //по сигналу менеджера
                if (SignalToStartProduction.HasValue) return SignalToStartProduction.Value.Date;

                //по дате первого платежа
                if (FirstPaymentDate.HasValue) return FirstPaymentDate.Value;

                //по дате доставки оборудования на объект
                if (DeliveryDate.HasValue) return DeliveryDate.Value.AddDays(-ProductionTerm).AddDays(-DeliveryPeriodCalculated).SkipPastAndWeekend().Date;

                //по дате реализации
                if (RealizationDate.HasValue) return RealizationDate.Value.AddDays(-ProductionTerm).SkipPastAndWeekend().Date;

                //если проиграно
                if (IsLoosen) return DeliveryDateExpected.AddDays(-ProductionTerm).Date;

                //по необходимой дате поставки на объект
                return DeliveryDateExpected.AddDays(-ProductionTerm).AddDays(-DeliveryPeriodCalculated).SkipPastAndWeekend().Date;
            }
        }

        /// <summary>
        /// Расчетная дата окончания производства.
        /// </summary>
        [Designation("Окончание производства (расч.)"), OrderStatus(855), NotMapped]
        public DateTime EndProductionDateCalculated
        {
            get
            {
                //по дате производства
                if (EndProductionDate.HasValue) return EndProductionDate.Value.Date;

                //если проиграно
                if (IsLoosen)
                    return DeliveryDateExpected.AddDays(-DeliveryPeriodCalculated).Date;

                //по дате комплектации
                if (PickingDate.HasValue)
                {
                    var assembleTerm = this.AssembleTerm ?? GlobalAppProperties.Actual.StandartTermFromPickToEndProduction;
                    return PickingDate.Value.AddDays(assembleTerm).SkipPastAndWeekend().Date;
                }

                //по дате размещения в производстве (план)
                if (EndProductionPlanDate.HasValue) return EndProductionPlanDate.Value.Date.SkipPast();

                //по сроку производства
                return StartProductionDateCalculated.AddDays(ProductionTerm).SkipPastAndWeekend().Date;
            }
        }

        /// <summary>
        /// Расчетная дата окончания производства.
        /// </summary>
        [Designation("Окончание производства по договору"), OrderStatus(854), NotMapped]
        public DateTime EndProductionDateByContractCalculated => StartProductionDateCalculated.AddDays(ProductionTerm).Date;

        /// <summary>
        /// Расчетная дата реализации.
        /// </summary>
        [Designation("Расчетная дата реализации"), OrderStatus(850), NotMapped]
        public DateTime RealizationDateCalculated => RealizationDate?.Date ?? DeliveryDateCalculated.Date;

        /// <summary>
        /// Расчетная дата отгрузки.
        /// </summary>
        [Designation("Расчетная дата отгрузки"), OrderStatus(845), NotMapped]
        public DateTime ShipmentDateCalculated
        {
            get
            {
                //по реальной дате отгрузки
                if (ShipmentDate.HasValue)
                    return ShipmentDate.Value.Date;

                //если проиграно
                if (IsLoosen)
                    return EndProductionDateCalculated.Date;

                //по плановой дате отгрузки
                if (ShipmentPlanDate.HasValue)
                {
                    if (ShippingConditionsDoneDate.HasValue)
                    {
                        if (ShipmentPlanDate.Value >= ShippingConditionsDoneDate &&
                            ShipmentPlanDate.Value >= EndProductionDateCalculated)
                            return ShipmentPlanDate.Value.Date;
                    }
                    else
                    {
                        if (ShipmentPlanDate.Value >= EndProductionDateCalculated)
                            return ShipmentPlanDate.Value.Date;
                    }
                }

                //по дате исполнения условий для отгрузки
                if (ShippingConditionsDoneDate.HasValue &&
                    ShippingConditionsDoneDate >= EndProductionDateCalculated)
                    return ShippingConditionsDoneDate.Value.SkipPastAndWeekend().Date;

                //по дате окончания производства
                return EndProductionDateCalculated.SkipPastAndWeekend().Date;
            }
        }

        /// <summary>
        /// Расчетная дата доставки.
        /// </summary>
        [Designation("Расчетная дата доставки"), OrderStatus(840), NotMapped]
        public DateTime DeliveryDateCalculated
        {
            get
            {
                if (DeliveryDate.HasValue) return DeliveryDate.Value.Date;
                return ShipmentDateCalculated.AddDays(DeliveryPeriodCalculated).SkipWeekend().Date;
            }
        }

        /// <summary>
        /// Расчетный срок доставки.
        /// </summary>
        [Designation("Расчетный срок доставки"), NotMapped]
        public double DeliveryPeriodCalculated
        {
            get
            {
                //по ожидаемому сроку доставки
                if (ExpectedDeliveryPeriod.HasValue) return ExpectedDeliveryPeriod.Value;

                //по расчетному
                if (ExpectedDeliveryPeriodCalculated.HasValue)
                    return ExpectedDeliveryPeriodCalculated.Value;

                return 3;
            }
        }


        #endregion

        #region Платежи

        /// <summary>
        /// Дата по условию.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DateTime GetPaymentDate(PaymentCondition condition)
        {
            switch (condition.PaymentConditionPoint.PaymentConditionPointEnum)
            {
                case PaymentConditionPointEnum.ProductionStart:
                    return StartProductionDateCalculated.AddDays(condition.DaysToPoint);
                case PaymentConditionPointEnum.ProductionEnd:
                    return EndProductionDateCalculated.AddDays(condition.DaysToPoint);
                case PaymentConditionPointEnum.Shipment:
                    return ShipmentDateCalculated.AddDays(condition.DaysToPoint);
                case PaymentConditionPointEnum.Delivery:
                    return DeliveryDateCalculated.AddDays(condition.DaysToPoint);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Платежное условие и процент его исполнения
        /// </summary>
        private Dictionary<PaymentCondition, double> PaymentConditionsDictionary => GetConditionsDictionary(PaidSum);

        private Dictionary<PaymentCondition, double> GetConditionsDictionary(double sum)
        {
            var result = new Dictionary<PaymentCondition, double>();

            //если стоимость нулевая или нечего платить - выходим
            if (Cost < 0.00001) return result;

            //оплаченный остаток
            var paidRest = sum;

            //берем все условия и упорядочиваем их
            List<PaymentCondition> conditions = PaymentConditionSet.PaymentConditions.OrderBy(paymentCondition => paymentCondition).ToList();

            foreach (var condition in conditions)
            {
                double conditionSum = condition.Part * Cost;
                double paidConditionPart = 0;
                //если остатка хватает на покрытие
                if (paidRest >= conditionSum)
                {
                    paidConditionPart = 1;
                    paidRest -= conditionSum;
                }
                else
                {
                    paidConditionPart = paidRest / conditionSum;
                    paidRest = 0;
                }
                result.Add(condition, paidConditionPart);
            }
            return result;
        }

        /// <summary>
        /// Актуальные плановые платежи. 
        /// !!!Важно!!! Возвращет новые сущности!
        /// </summary>
        [NotMapped]
        public List<PaymentPlanned> PaymentsPlannedActual
        {
            get
            {
                var result = new List<PaymentPlanned>();

                //если проект не отчетный, то и на плановые платежи не нужно обращать внимание
                if (this.Project != null && this.Project.ForReport == false)
                {
                    return result;
                }

                //словарь условий и коэффицента их исполнений
                var dictionary = PaymentConditionsDictionary;

                foreach (var payment in PaymentsPlanned)
                {
                    //если связанное условие существует и еще не исполнено
                    if (payment.Condition != null &&
                        dictionary.ContainsKey(payment.Condition) &&
                        dictionary[payment.Condition] < 1)
                    {
                        double part = payment.Part;
                        //если остатка хватает
                        if (part + dictionary[payment.Condition] <= 1)
                        {
                            dictionary[payment.Condition] += part;
                        }
                        else
                        {
                            part = 1 - dictionary[payment.Condition];
                            dictionary[payment.Condition] = 1;
                        }

                        //добавляем актуальный плановый платеж
                        result.Add(new PaymentPlanned
                        {
                            Date = payment.Date.SkipPast(),
                            Part = part,

                            Id = payment.Id,
                            Condition = payment.Condition,
                            Comment = payment.Comment,
                            DateCalculated = payment.DateCalculated
                        });
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Расчетные плановые платежи (без сохраненных).
        /// </summary>
        [Designation("Расчетные плановые платежи"), NotMapped]
        public List<PaymentPlanned> PaymentsPlannedGenerated
        {
            get
            {
                var dictionary = PaymentConditionsDictionary;
                foreach (var paymentPlanned in PaymentsPlannedActual)
                {
                    dictionary[paymentPlanned.Condition] += paymentPlanned.Part;
                }

                var result = new List<PaymentPlanned>();
                foreach (var conditions in dictionary)
                {
                    if (conditions.Value >= 1)
                        continue;

                    result.Add(new PaymentPlanned
                    {
                        Condition = conditions.Key,
                        Date = GetPaymentDate(conditions.Key).SkipPast(),
                        Part = 1 - conditions.Value,
                        //Comment = "Сгенерированный платеж"
                    });
                }
                return result;
            }
        }


        /// <summary>
        /// Расчетные плановые платежи + сохраненные.
        /// </summary>
        [Designation("Расчетные плановые платежи + сохраненные"), NotMapped]
        public List<PaymentPlanned> PaymentsPlannedCalculated => PaymentsPlannedActual.Union(PaymentsPlannedGenerated).ToList();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        #endregion

        public int? GetOrderPosition()
        {
            if (int.TryParse(this.OrderPosition, out var result))
                return result;
            return null;
        }

    }
}