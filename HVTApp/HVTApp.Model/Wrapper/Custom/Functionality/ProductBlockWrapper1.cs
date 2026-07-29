using System;
using System.Linq;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;

namespace HVTApp.Model.Wrapper
{
    public partial class ProductBlockWrapper1 : WrapperBase<ProductBlock>
    {
        public ProductBlockWrapper1(ProductBlock model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Специальное обозначение
        /// </summary>
        public string DesignationSpecial
        {
            get => Model.DesignationSpecial;
            set => SetValue(value);
        }
        public string DesignationSpecialOriginalValue => GetOriginalValue<string>(nameof(DesignationSpecial));
        public bool DesignationSpecialIsChanged => GetIsChanged(nameof(DesignationSpecial));

        /// <summary>
        /// Сралчахвост
        /// </summary>
        public System.String StructureCostNumber
        {
            get { return Model.StructureCostNumber; }
            set { SetValue(value); }
        }
        public System.String StructureCostNumberOriginalValue => GetOriginalValue<System.String>(nameof(StructureCostNumber));
        public bool StructureCostNumberIsChanged => GetIsChanged(nameof(StructureCostNumber));

        /// <summary>
        /// Сралчахвост требуется
        /// </summary>
        public System.Boolean StructureCostNumberIsRequired
        {
            get { return Model.StructureCostNumberIsRequired; }
            set { SetValue(value); }
        }
        public System.Boolean StructureCostNumberIsRequiredOriginalValue => GetOriginalValue<System.Boolean>(nameof(StructureCostNumberIsRequired));
        public bool StructureCostNumberIsRequiredIsChanged => GetIsChanged(nameof(StructureCostNumberIsRequired));

        /// <summary>
        /// Чертеж
        /// </summary>
        public System.String Design
        {
            get { return Model.Design; }
            set { SetValue(value); }
        }
        public System.String DesignOriginalValue => GetOriginalValue<System.String>(nameof(Design));
        public bool DesignIsChanged => GetIsChanged(nameof(Design));

        /// <summary>
        /// Вес
        /// </summary>
        public System.Double Weight
        {
            get { return Model.Weight; }
            set { SetValue(value); }
        }
        public System.Double WeightOriginalValue => GetOriginalValue<System.Double>(nameof(Weight));
        public bool WeightIsChanged => GetIsChanged(nameof(Weight));

        /// <summary>
        /// Трудозатраты (н/ч на ед.)
        /// </summary>
        public System.Nullable<System.Double> LaborCosts
        {
            get { return Model.LaborCosts; }
            set { SetValue(value); }
        }
        public System.Nullable<System.Double> LaborCostsOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(LaborCosts));
        public bool LaborCostsIsChanged => GetIsChanged(nameof(LaborCosts));

        /// <summary>
        /// Доставка
        /// </summary>
        public System.Boolean IsDelivery
        {
            get { return Model.IsDelivery; }
            set { SetValue(value); }
        }
        public System.Boolean IsDeliveryOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsDelivery));
        public bool IsDeliveryIsChanged => GetIsChanged(nameof(IsDelivery));

        /// <summary>
        /// Id
        /// </summary>
        public System.Guid Id
        {
            get { return Model.Id; }
            set { SetValue(value); }
        }
        public System.Guid IdOriginalValue => GetOriginalValue<System.Guid>(nameof(Id));
        public bool IdIsChanged => GetIsChanged(nameof(Id));

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Параметры
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterEmptyWrapper> Parameters { get; private set; }

        /// <summary>
        /// Себестоимости
        /// </summary>
        public IValidatableChangeTrackingCollection<SumOnDateEmptyWrapper> Prices { get; private set; }

        /// <summary>
        /// Фиксированные цены
        /// </summary>
        public IValidatableChangeTrackingCollection<SumOnDateEmptyWrapper> FixedCosts { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Обозначение
        /// </summary>
        public string Designation => Model.Designation;

        /// <summary>
        /// Есть прайс
        /// </summary>
        public bool HasPrice => Model.HasPrice;

        /// <summary>
        /// Дата последнего прайса
        /// </summary>
        public DateTime? LastPriceDate => Model.LastPriceDate;

        /// <summary>
        /// Есть фиксированный прайс
        /// </summary>
        public bool HasFixedPrice => Model.HasFixedPrice;

        /// <summary>
        /// Новый
        /// </summary>
        public bool IsNew => Model.IsNew;

        /// <summary>
        /// Услуга
        /// </summary>
        public bool IsService => Model.IsService;

        /// <summary>
        /// Шеф-монтаж
        /// </summary>
        public bool IsSupervision => Model.IsSupervision;

        /// <summary>
        /// Комплект
        /// </summary>
        public bool IsKit => Model.IsKit;

        /// <summary>
        /// Тип
        /// </summary>
        public ProductType ProductType => Model.ProductType;

        #endregion

        protected override void InitializeCollectionProperties()
        {
            if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
            Parameters = new ValidatableChangeTrackingCollection<ParameterEmptyWrapper>(Model.Parameters.Select(e => new ParameterEmptyWrapper(e)));
            RegisterCollection(Parameters, Model.Parameters);

            if (Model.Prices == null) throw new ArgumentException($"{nameof(Model.Prices)} cannot be null");
            Prices = new ValidatableChangeTrackingCollection<SumOnDateEmptyWrapper>(Model.Prices.Select(e => new SumOnDateEmptyWrapper(e)));
            RegisterCollection(Prices, Model.Prices);

            if (Model.FixedCosts == null) throw new ArgumentException($"{nameof(Model.FixedCosts)} cannot be null");
            FixedCosts = new ValidatableChangeTrackingCollection<SumOnDateEmptyWrapper>(Model.FixedCosts.Select(e => new SumOnDateEmptyWrapper(e)));
            RegisterCollection(FixedCosts, Model.FixedCosts);
        }

        public bool HasActualPriceOnDate(DateTime date)
        {
            var actualTerm = GlobalAppProperties.Actual.ActualPriceTerm;
            return Prices.Any(x => x.Model.Date >= date.AddDays(-actualTerm));
        }

        public double GetPrice(DateTime date)
        {
            //ближайшая актуальная цена
            var actualTerm = GlobalAppProperties.Actual.ActualPriceTerm;
            var price = Prices.Where(x => x.Model.Date >= date.AddDays(-actualTerm)).OrderBy(x => x.Model.Date).LastOrDefault();
            //if (price != null) return price.Cost;

            //ближайшая цена
            price = Prices.FirstOrDefault();
            foreach (var costOnDate in Prices)
            {
                if (Math.Abs(date.Ticks - costOnDate.Model.Date.Ticks) < Math.Abs(date.Ticks - price.Model.Date.Ticks))
                    price = costOnDate;
            }

            //return price?.Cost ?? 0;
            return 0;
        }
    }
}