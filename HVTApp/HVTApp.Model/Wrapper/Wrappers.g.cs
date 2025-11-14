using System;
using System.Linq;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;

namespace HVTApp.Model.Wrapper
{
	
    public partial class NotificationUnitWrapper : WrapperBase<NotificationUnit>
	{
	    public NotificationUnitWrapper(NotificationUnit model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Moment
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// ActionType
        /// </summary>
        public HVTApp.Infrastructure.Enums.NotificationActionType ActionType
        {
          get { return Model.ActionType; }
          set { SetValue(value); }
        }
        public HVTApp.Infrastructure.Enums.NotificationActionType ActionTypeOriginalValue => GetOriginalValue<HVTApp.Infrastructure.Enums.NotificationActionType>(nameof(ActionType));
        public bool ActionTypeIsChanged => GetIsChanged(nameof(ActionType));

        /// <summary>
        /// TargetEntityId
        /// </summary>
        public System.Guid TargetEntityId
        {
          get { return Model.TargetEntityId; }
          set { SetValue(value); }
        }
        public System.Guid TargetEntityIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TargetEntityId));
        public bool TargetEntityIdIsChanged => GetIsChanged(nameof(TargetEntityId));

        /// <summary>
        /// SenderUserId
        /// </summary>
        public System.Guid SenderUserId
        {
          get { return Model.SenderUserId; }
          set { SetValue(value); }
        }
        public System.Guid SenderUserIdOriginalValue => GetOriginalValue<System.Guid>(nameof(SenderUserId));
        public bool SenderUserIdIsChanged => GetIsChanged(nameof(SenderUserId));

        /// <summary>
        /// Роль отправителя
        /// </summary>
        public HVTApp.Infrastructure.Role SenderRole
        {
          get { return Model.SenderRole; }
          set { SetValue(value); }
        }
        public HVTApp.Infrastructure.Role SenderRoleOriginalValue => GetOriginalValue<HVTApp.Infrastructure.Role>(nameof(SenderRole));
        public bool SenderRoleIsChanged => GetIsChanged(nameof(SenderRole));

        /// <summary>
        /// RecipientUserId
        /// </summary>
        public System.Guid RecipientUserId
        {
          get { return Model.RecipientUserId; }
          set { SetValue(value); }
        }
        public System.Guid RecipientUserIdOriginalValue => GetOriginalValue<System.Guid>(nameof(RecipientUserId));
        public bool RecipientUserIdIsChanged => GetIsChanged(nameof(RecipientUserId));

        /// <summary>
        /// Роль получателя
        /// </summary>
        public HVTApp.Infrastructure.Role RecipientRole
        {
          get { return Model.RecipientRole; }
          set { SetValue(value); }
        }
        public HVTApp.Infrastructure.Role RecipientRoleOriginalValue => GetOriginalValue<HVTApp.Infrastructure.Role>(nameof(RecipientRole));
        public bool RecipientRoleIsChanged => GetIsChanged(nameof(RecipientRole));

        /// <summary>
        /// Отправлено по почте
        /// </summary>
        public System.Boolean IsSentByEmail
        {
          get { return Model.IsSentByEmail; }
          set { SetValue(value); }
        }
        public System.Boolean IsSentByEmailOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsSentByEmail));
        public bool IsSentByEmailIsChanged => GetIsChanged(nameof(IsSentByEmail));

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

        #region ComplexProperties

        /// <summary>
        /// Отправитель
        /// </summary>
	    public UserWrapper SenderUser 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(SenderUser, value); }
        }

        /// <summary>
        /// Получатель
        /// </summary>
	    public UserWrapper RecipientUser 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(RecipientUser, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(SenderUser), Model.SenderUser == null ? null : new UserWrapper(Model.SenderUser));
            InitializeComplexProperty<UserWrapper>(nameof(RecipientUser), Model.RecipientUser == null ? null : new UserWrapper(Model.RecipientUser));
        }
	}

    public class NotificationUnitEmptyWrapper : WrapperBase<NotificationUnit>
	{
	    public NotificationUnitEmptyWrapper(NotificationUnit model) : base(model) { }
    }

		
    public partial class CountryUnionWrapper : WrapperBase<CountryUnion>
	{
	    public CountryUnionWrapper(CountryUnion model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        /// Страны объединения
        /// </summary>
        public IValidatableChangeTrackingCollection<CountryWrapper> Countries { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Countries == null) throw new ArgumentException($"{nameof(Model.Countries)} cannot be null");
          Countries = new ValidatableChangeTrackingCollection<CountryWrapper>(Model.Countries.Select(e => new CountryWrapper(e)));
          RegisterCollection(Countries, Model.Countries);
        }
	}

    public class CountryUnionEmptyWrapper : WrapperBase<CountryUnion>
	{
	    public CountryUnionEmptyWrapper(CountryUnion model) : base(model) { }
    }

		
    public partial class BudgetWrapper : WrapperBase<Budget>
	{
	    public BudgetWrapper(Budget model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Старт
        /// </summary>
        public System.DateTime DateStart
        {
          get { return Model.DateStart; }
          set { SetValue(value); }
        }
        public System.DateTime DateStartOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateStart));
        public bool DateStartIsChanged => GetIsChanged(nameof(DateStart));

        /// <summary>
        /// Финиш
        /// </summary>
        public System.DateTime DateFinish
        {
          get { return Model.DateFinish; }
          set { SetValue(value); }
        }
        public System.DateTime DateFinishOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateFinish));
        public bool DateFinishIsChanged => GetIsChanged(nameof(DateFinish));

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        /// Единицы бюджета
        /// </summary>
        public IValidatableChangeTrackingCollection<BudgetUnitWrapper> Units { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Units == null) throw new ArgumentException($"{nameof(Model.Units)} cannot be null");
          Units = new ValidatableChangeTrackingCollection<BudgetUnitWrapper>(Model.Units.Select(e => new BudgetUnitWrapper(e)));
          RegisterCollection(Units, Model.Units);
        }
	}

    public class BudgetEmptyWrapper : WrapperBase<Budget>
	{
	    public BudgetEmptyWrapper(Budget model) : base(model) { }
    }

		
    public partial class BudgetUnitWrapper : WrapperBase<BudgetUnit>
	{
	    public BudgetUnitWrapper(BudgetUnit model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата ОИТ
        /// </summary>
        public System.DateTime OrderInTakeDate
        {
          get { return Model.OrderInTakeDate; }
          set { SetValue(value); }
        }
        public System.DateTime OrderInTakeDateOriginalValue => GetOriginalValue<System.DateTime>(nameof(OrderInTakeDate));
        public bool OrderInTakeDateIsChanged => GetIsChanged(nameof(OrderInTakeDate));

        /// <summary>
        /// Дата реализации
        /// </summary>
        public System.DateTime RealizationDate
        {
          get { return Model.RealizationDate; }
          set { SetValue(value); }
        }
        public System.DateTime RealizationDateOriginalValue => GetOriginalValue<System.DateTime>(nameof(RealizationDate));
        public bool RealizationDateIsChanged => GetIsChanged(nameof(RealizationDate));

        /// <summary>
        /// Дата ОИТ (менеджер)
        /// </summary>
        public System.DateTime OrderInTakeDateByManager
        {
          get { return Model.OrderInTakeDateByManager; }
          set { SetValue(value); }
        }
        public System.DateTime OrderInTakeDateByManagerOriginalValue => GetOriginalValue<System.DateTime>(nameof(OrderInTakeDateByManager));
        public bool OrderInTakeDateByManagerIsChanged => GetIsChanged(nameof(OrderInTakeDateByManager));

        /// <summary>
        /// Дата реализации (менеджер)
        /// </summary>
        public System.DateTime RealizationDateByManager
        {
          get { return Model.RealizationDateByManager; }
          set { SetValue(value); }
        }
        public System.DateTime RealizationDateByManagerOriginalValue => GetOriginalValue<System.DateTime>(nameof(RealizationDateByManager));
        public bool RealizationDateByManagerIsChanged => GetIsChanged(nameof(RealizationDateByManager));

        /// <summary>
        /// Стоимость
        /// </summary>
        public System.Double Cost
        {
          get { return Model.Cost; }
          set { SetValue(value); }
        }
        public System.Double CostOriginalValue => GetOriginalValue<System.Double>(nameof(Cost));
        public bool CostIsChanged => GetIsChanged(nameof(Cost));

        /// <summary>
        /// Стоимость (менеджер)
        /// </summary>
        public System.Double CostByManager
        {
          get { return Model.CostByManager; }
          set { SetValue(value); }
        }
        public System.Double CostByManagerOriginalValue => GetOriginalValue<System.Double>(nameof(CostByManager));
        public bool CostByManagerIsChanged => GetIsChanged(nameof(CostByManager));

        /// <summary>
        /// Удален
        /// </summary>
        public System.Boolean IsRemoved
        {
          get { return Model.IsRemoved; }
          set { SetValue(value); }
        }
        public System.Boolean IsRemovedOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsRemoved));
        public bool IsRemovedIsChanged => GetIsChanged(nameof(IsRemoved));

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

        #region ComplexProperties

        /// <summary>
        /// Единица продаж
        /// </summary>
	    public SalesUnitWrapper SalesUnit 
        {
            get { return GetWrapper<SalesUnitWrapper>(); }
            set { SetComplexValue<SalesUnit, SalesUnitWrapper>(SalesUnit, value); }
        }

        /// <summary>
        /// Условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSet, value); }
        }

        /// <summary>
        /// Условия оплаты (менеджер)
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSetByManager 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSetByManager, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<SalesUnitWrapper>(nameof(SalesUnit), Model.SalesUnit == null ? null : new SalesUnitWrapper(Model.SalesUnit));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSet));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSetByManager), Model.PaymentConditionSetByManager == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSetByManager));
        }
	}

    public class BudgetUnitEmptyWrapper : WrapperBase<BudgetUnit>
	{
	    public BudgetUnitEmptyWrapper(BudgetUnit model) : base(model) { }
    }

		
    public partial class ConstructorParametersListWrapper : WrapperBase<ConstructorParametersList>
	{
	    public ConstructorParametersListWrapper(ConstructorParametersList model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class ConstructorParametersListEmptyWrapper : WrapperBase<ConstructorParametersList>
	{
	    public ConstructorParametersListEmptyWrapper(ConstructorParametersList model) : base(model) { }
    }

		
    public partial class ConstructorsParametersWrapper : WrapperBase<ConstructorsParameters>
	{
	    public ConstructorsParametersWrapper(ConstructorsParameters model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        /// Конструкторы
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> Constructors { get; private set; }

        /// <summary>
        /// Списки параметров
        /// </summary>
        public IValidatableChangeTrackingCollection<ConstructorParametersListWrapper> PatametersLists { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Constructors == null) throw new ArgumentException($"{nameof(Model.Constructors)} cannot be null");
          Constructors = new ValidatableChangeTrackingCollection<UserWrapper>(Model.Constructors.Select(e => new UserWrapper(e)));
          RegisterCollection(Constructors, Model.Constructors);
          if (Model.PatametersLists == null) throw new ArgumentException($"{nameof(Model.PatametersLists)} cannot be null");
          PatametersLists = new ValidatableChangeTrackingCollection<ConstructorParametersListWrapper>(Model.PatametersLists.Select(e => new ConstructorParametersListWrapper(e)));
          RegisterCollection(PatametersLists, Model.PatametersLists);
        }
	}

    public class ConstructorsParametersEmptyWrapper : WrapperBase<ConstructorsParameters>
	{
	    public ConstructorsParametersEmptyWrapper(ConstructorsParameters model) : base(model) { }
    }

		
    public partial class CostsPercentsWrapper : WrapperBase<CostsPercents>
	{
	    public CostsPercentsWrapper(CostsPercents model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Управленческие расходы (%)
        /// </summary>
        public System.Double ManagmentCosts
        {
          get { return Model.ManagmentCosts; }
          set { SetValue(value); }
        }
        public System.Double ManagmentCostsOriginalValue => GetOriginalValue<System.Double>(nameof(ManagmentCosts));
        public bool ManagmentCostsIsChanged => GetIsChanged(nameof(ManagmentCosts));

        /// <summary>
        /// Хозяйственные расходы (%)
        /// </summary>
        public System.Double EconomicCosts
        {
          get { return Model.EconomicCosts; }
          set { SetValue(value); }
        }
        public System.Double EconomicCostsOriginalValue => GetOriginalValue<System.Double>(nameof(EconomicCosts));
        public bool EconomicCostsIsChanged => GetIsChanged(nameof(EconomicCosts));

        /// <summary>
        /// Коммерческие расходы (%)
        /// </summary>
        public System.Double CommercialCosts
        {
          get { return Model.CommercialCosts; }
          set { SetValue(value); }
        }
        public System.Double CommercialCostsOriginalValue => GetOriginalValue<System.Double>(nameof(CommercialCosts));
        public bool CommercialCostsIsChanged => GetIsChanged(nameof(CommercialCosts));

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
	}

    public class CostsPercentsEmptyWrapper : WrapperBase<CostsPercents>
	{
	    public CostsPercentsEmptyWrapper(CostsPercents model) : base(model) { }
    }

		
    public partial class CreateNewProductTaskWrapper : WrapperBase<CreateNewProductTask>
	{
	    public CreateNewProductTaskWrapper(CreateNewProductTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Обозначение
        /// </summary>
        public System.String Designation
        {
          get { return Model.Designation; }
          set { SetValue(value); }
        }
        public System.String DesignationOriginalValue => GetOriginalValue<System.String>(nameof(Designation));
        public bool DesignationIsChanged => GetIsChanged(nameof(Designation));

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
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Продукт
        /// </summary>
	    public ProductWrapper Product 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(Product, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductWrapper>(nameof(Product), Model.Product == null ? null : new ProductWrapper(Model.Product));
        }
	}

    public class CreateNewProductTaskEmptyWrapper : WrapperBase<CreateNewProductTask>
	{
	    public CreateNewProductTaskEmptyWrapper(CreateNewProductTask model) : base(model) { }
    }

		
    public partial class DesignDepartmentWrapper : WrapperBase<DesignDepartment>
	{
	    public DesignDepartmentWrapper(DesignDepartment model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// КБ ремкомплектов
        /// </summary>
        public System.Boolean IsKitDepartment
        {
          get { return Model.IsKitDepartment; }
          set { SetValue(value); }
        }
        public System.Boolean IsKitDepartmentOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsKitDepartment));
        public bool IsKitDepartmentIsChanged => GetIsChanged(nameof(IsKitDepartment));

        /// <summary>
        /// КБ с коэффициентом удорожания
        /// </summary>
        public System.Boolean IsPriceIncreaseFactor
        {
          get { return Model.IsPriceIncreaseFactor; }
          set { SetValue(value); }
        }
        public System.Boolean IsPriceIncreaseFactorOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsPriceIncreaseFactor));
        public bool IsPriceIncreaseFactorIsChanged => GetIsChanged(nameof(IsPriceIncreaseFactor));

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

        #region ComplexProperties

        /// <summary>
        /// Руководитель
        /// </summary>
	    public UserWrapper Head 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Head, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Сотрудники
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> Staff { get; private set; }

        /// <summary>
        /// Наблюдатели
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> Observers { get; private set; }

        /// <summary>
        /// Наборы параметров основного оборудования
        /// </summary>
        public IValidatableChangeTrackingCollection<DesignDepartmentParametersWrapper> ParameterSets { get; private set; }

        /// <summary>
        /// Наборы параметров дополнительного оборудования
        /// </summary>
        public IValidatableChangeTrackingCollection<DesignDepartmentParametersAddedBlocksWrapper> ParameterSetsAddedBlocks { get; private set; }

        /// <summary>
        /// Наборы параметров оборудования для подзадач
        /// </summary>
        public IValidatableChangeTrackingCollection<DesignDepartmentParametersSubTaskWrapper> ParameterSetsSubTask { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Head), Model.Head == null ? null : new UserWrapper(Model.Head));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Staff == null) throw new ArgumentException($"{nameof(Model.Staff)} cannot be null");
          Staff = new ValidatableChangeTrackingCollection<UserWrapper>(Model.Staff.Select(e => new UserWrapper(e)));
          RegisterCollection(Staff, Model.Staff);
          if (Model.Observers == null) throw new ArgumentException($"{nameof(Model.Observers)} cannot be null");
          Observers = new ValidatableChangeTrackingCollection<UserWrapper>(Model.Observers.Select(e => new UserWrapper(e)));
          RegisterCollection(Observers, Model.Observers);
          if (Model.ParameterSets == null) throw new ArgumentException($"{nameof(Model.ParameterSets)} cannot be null");
          ParameterSets = new ValidatableChangeTrackingCollection<DesignDepartmentParametersWrapper>(Model.ParameterSets.Select(e => new DesignDepartmentParametersWrapper(e)));
          RegisterCollection(ParameterSets, Model.ParameterSets);
          if (Model.ParameterSetsAddedBlocks == null) throw new ArgumentException($"{nameof(Model.ParameterSetsAddedBlocks)} cannot be null");
          ParameterSetsAddedBlocks = new ValidatableChangeTrackingCollection<DesignDepartmentParametersAddedBlocksWrapper>(Model.ParameterSetsAddedBlocks.Select(e => new DesignDepartmentParametersAddedBlocksWrapper(e)));
          RegisterCollection(ParameterSetsAddedBlocks, Model.ParameterSetsAddedBlocks);
          if (Model.ParameterSetsSubTask == null) throw new ArgumentException($"{nameof(Model.ParameterSetsSubTask)} cannot be null");
          ParameterSetsSubTask = new ValidatableChangeTrackingCollection<DesignDepartmentParametersSubTaskWrapper>(Model.ParameterSetsSubTask.Select(e => new DesignDepartmentParametersSubTaskWrapper(e)));
          RegisterCollection(ParameterSetsSubTask, Model.ParameterSetsSubTask);
        }
	}

    public class DesignDepartmentEmptyWrapper : WrapperBase<DesignDepartment>
	{
	    public DesignDepartmentEmptyWrapper(DesignDepartment model) : base(model) { }
    }

		
    public partial class DirectumTaskWrapper : WrapperBase<DirectumTask>
	{
	    public DirectumTaskWrapper(DirectumTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Приём
        /// </summary>
        public System.Nullable<System.DateTime> StartPerformer
        {
          get { return Model.StartPerformer; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> StartPerformerOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(StartPerformer));
        public bool StartPerformerIsChanged => GetIsChanged(nameof(StartPerformer));

        /// <summary>
        /// Срок
        /// </summary>
        public System.DateTime FinishPlan
        {
          get { return Model.FinishPlan; }
          set { SetValue(value); }
        }
        public System.DateTime FinishPlanOriginalValue => GetOriginalValue<System.DateTime>(nameof(FinishPlan));
        public bool FinishPlanIsChanged => GetIsChanged(nameof(FinishPlan));

        /// <summary>
        /// Финиш исполнителем
        /// </summary>
        public System.Nullable<System.DateTime> FinishPerformer
        {
          get { return Model.FinishPerformer; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> FinishPerformerOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(FinishPerformer));
        public bool FinishPerformerIsChanged => GetIsChanged(nameof(FinishPerformer));

        /// <summary>
        /// Финиш
        /// </summary>
        public System.Nullable<System.DateTime> FinishAuthor
        {
          get { return Model.FinishAuthor; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> FinishAuthorOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(FinishAuthor));
        public bool FinishAuthorIsChanged => GetIsChanged(nameof(FinishAuthor));

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

        #region ComplexProperties

        /// <summary>
        /// Группа задач
        /// </summary>
	    public DirectumTaskGroupWrapper Group 
        {
            get { return GetWrapper<DirectumTaskGroupWrapper>(); }
            set { SetComplexValue<DirectumTaskGroup, DirectumTaskGroupWrapper>(Group, value); }
        }

        /// <summary>
        /// Исполнитель
        /// </summary>
	    public UserWrapper Performer 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Performer, value); }
        }

        /// <summary>
        /// Родительская задача
        /// </summary>
	    public DirectumTaskWrapper ParentTask 
        {
            get { return GetWrapper<DirectumTaskWrapper>(); }
            set { SetComplexValue<DirectumTask, DirectumTaskWrapper>(ParentTask, value); }
        }

        /// <summary>
        /// Предыдущая задача
        /// </summary>
	    public DirectumTaskWrapper PreviousTask 
        {
            get { return GetWrapper<DirectumTaskWrapper>(); }
            set { SetComplexValue<DirectumTask, DirectumTaskWrapper>(PreviousTask, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Переписка
        /// </summary>
        public IValidatableChangeTrackingCollection<DirectumTaskMessageWrapper> Messages { get; private set; }

        /// <summary>
        /// Childs
        /// </summary>
        public IValidatableChangeTrackingCollection<DirectumTaskWrapper> Childs { get; private set; }

        /// <summary>
        /// Parallel
        /// </summary>
        public IValidatableChangeTrackingCollection<DirectumTaskWrapper> Parallel { get; private set; }

        /// <summary>
        /// Next
        /// </summary>
        public IValidatableChangeTrackingCollection<DirectumTaskWrapper> Next { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// StartResult
        /// </summary>
        public System.Nullable<System.DateTime> StartResult => Model.StartResult; 

        /// <summary>
        /// Статус
        /// </summary>
        public System.String Status => Model.Status; 

        /// <summary>
        /// Актуальность
        /// </summary>
        public System.Boolean IsActual => Model.IsActual; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<DirectumTaskGroupWrapper>(nameof(Group), Model.Group == null ? null : new DirectumTaskGroupWrapper(Model.Group));
            InitializeComplexProperty<UserWrapper>(nameof(Performer), Model.Performer == null ? null : new UserWrapper(Model.Performer));
            InitializeComplexProperty<DirectumTaskWrapper>(nameof(ParentTask), Model.ParentTask == null ? null : new DirectumTaskWrapper(Model.ParentTask));
            InitializeComplexProperty<DirectumTaskWrapper>(nameof(PreviousTask), Model.PreviousTask == null ? null : new DirectumTaskWrapper(Model.PreviousTask));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Messages == null) throw new ArgumentException($"{nameof(Model.Messages)} cannot be null");
          Messages = new ValidatableChangeTrackingCollection<DirectumTaskMessageWrapper>(Model.Messages.Select(e => new DirectumTaskMessageWrapper(e)));
          RegisterCollection(Messages, Model.Messages);
          if (Model.Childs == null) throw new ArgumentException($"{nameof(Model.Childs)} cannot be null");
          Childs = new ValidatableChangeTrackingCollection<DirectumTaskWrapper>(Model.Childs.Select(e => new DirectumTaskWrapper(e)));
          RegisterCollection(Childs, Model.Childs);
          if (Model.Parallel == null) throw new ArgumentException($"{nameof(Model.Parallel)} cannot be null");
          Parallel = new ValidatableChangeTrackingCollection<DirectumTaskWrapper>(Model.Parallel.Select(e => new DirectumTaskWrapper(e)));
          RegisterCollection(Parallel, Model.Parallel);
          if (Model.Next == null) throw new ArgumentException($"{nameof(Model.Next)} cannot be null");
          Next = new ValidatableChangeTrackingCollection<DirectumTaskWrapper>(Model.Next.Select(e => new DirectumTaskWrapper(e)));
          RegisterCollection(Next, Model.Next);
        }
	}

    public class DirectumTaskEmptyWrapper : WrapperBase<DirectumTask>
	{
	    public DirectumTaskEmptyWrapper(DirectumTask model) : base(model) { }
    }

		
    public partial class DirectumTaskGroupWrapper : WrapperBase<DirectumTaskGroup>
	{
	    public DirectumTaskGroupWrapper(DirectumTaskGroup model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Тема
        /// </summary>
        public System.String Title
        {
          get { return Model.Title; }
          set { SetValue(value); }
        }
        public System.String TitleOriginalValue => GetOriginalValue<System.String>(nameof(Title));
        public bool TitleIsChanged => GetIsChanged(nameof(Title));

        /// <summary>
        /// Старт
        /// </summary>
        public System.DateTime StartAuthor
        {
          get { return Model.StartAuthor; }
          set { SetValue(value); }
        }
        public System.DateTime StartAuthorOriginalValue => GetOriginalValue<System.DateTime>(nameof(StartAuthor));
        public bool StartAuthorIsChanged => GetIsChanged(nameof(StartAuthor));

        /// <summary>
        /// Прекращена инициатором
        /// </summary>
        public System.Boolean IsStoped
        {
          get { return Model.IsStoped; }
          set { SetValue(value); }
        }
        public System.Boolean IsStopedOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsStoped));
        public bool IsStopedIsChanged => GetIsChanged(nameof(IsStoped));

        /// <summary>
        /// Приоритет
        /// </summary>
        public HVTApp.Model.POCOs.DirectumTaskPriority Priority
        {
          get { return Model.Priority; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.DirectumTaskPriority PriorityOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.DirectumTaskPriority>(nameof(Priority));
        public bool PriorityIsChanged => GetIsChanged(nameof(Priority));

        /// <summary>
        /// Сообщение автора
        /// </summary>
        public System.String Message
        {
          get { return Model.Message; }
          set { SetValue(value); }
        }
        public System.String MessageOriginalValue => GetOriginalValue<System.String>(nameof(Message));
        public bool MessageIsChanged => GetIsChanged(nameof(Message));

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

        #region ComplexProperties

        /// <summary>
        /// Инициатор
        /// </summary>
	    public UserWrapper Author 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Author, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Наблюдатели
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> Observers { get; private set; }

        /// <summary>
        /// Приложения
        /// </summary>
        public IValidatableChangeTrackingCollection<DirectumTaskGroupFileWrapper> Files { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Author), Model.Author == null ? null : new UserWrapper(Model.Author));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Observers == null) throw new ArgumentException($"{nameof(Model.Observers)} cannot be null");
          Observers = new ValidatableChangeTrackingCollection<UserWrapper>(Model.Observers.Select(e => new UserWrapper(e)));
          RegisterCollection(Observers, Model.Observers);
          if (Model.Files == null) throw new ArgumentException($"{nameof(Model.Files)} cannot be null");
          Files = new ValidatableChangeTrackingCollection<DirectumTaskGroupFileWrapper>(Model.Files.Select(e => new DirectumTaskGroupFileWrapper(e)));
          RegisterCollection(Files, Model.Files);
        }
	}

    public class DirectumTaskGroupEmptyWrapper : WrapperBase<DirectumTaskGroup>
	{
	    public DirectumTaskGroupEmptyWrapper(DirectumTaskGroup model) : base(model) { }
    }

		
    public partial class DirectumTaskGroupFileWrapper : WrapperBase<DirectumTaskGroupFile>
	{
	    public DirectumTaskGroupFileWrapper(DirectumTaskGroupFile model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Имя
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Создан
        /// </summary>
        public System.DateTime LoadMoment
        {
          get { return Model.LoadMoment; }
          set { SetValue(value); }
        }
        public System.DateTime LoadMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(LoadMoment));
        public bool LoadMomentIsChanged => GetIsChanged(nameof(LoadMoment));

        /// <summary>
        /// Ссылка на группу задач
        /// </summary>
        public System.Guid DirectumTaskGroupId
        {
          get { return Model.DirectumTaskGroupId; }
          set { SetValue(value); }
        }
        public System.Guid DirectumTaskGroupIdOriginalValue => GetOriginalValue<System.Guid>(nameof(DirectumTaskGroupId));
        public bool DirectumTaskGroupIdIsChanged => GetIsChanged(nameof(DirectumTaskGroupId));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper Author 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Author, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Author), Model.Author == null ? null : new UserWrapper(Model.Author));
        }
	}

    public class DirectumTaskGroupFileEmptyWrapper : WrapperBase<DirectumTaskGroupFile>
	{
	    public DirectumTaskGroupFileEmptyWrapper(DirectumTaskGroupFile model) : base(model) { }
    }

		
    public partial class DirectumTaskMessageWrapper : WrapperBase<DirectumTaskMessage>
	{
	    public DirectumTaskMessageWrapper(DirectumTaskMessage model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Сообщение
        /// </summary>
        public System.String Message
        {
          get { return Model.Message; }
          set { SetValue(value); }
        }
        public System.String MessageOriginalValue => GetOriginalValue<System.String>(nameof(Message));
        public bool MessageIsChanged => GetIsChanged(nameof(Message));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper Author 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Author, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Author), Model.Author == null ? null : new UserWrapper(Model.Author));
        }
	}

    public class DirectumTaskMessageEmptyWrapper : WrapperBase<DirectumTaskMessage>
	{
	    public DirectumTaskMessageEmptyWrapper(DirectumTaskMessage model) : base(model) { }
    }

		
    public partial class DocumentNumberWrapper : WrapperBase<DocumentNumber>
	{
	    public DocumentNumberWrapper(DocumentNumber model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Number
        /// </summary>
        public System.Int32 Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.Int32 NumberOriginalValue => GetOriginalValue<System.Int32>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

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
	}

    public class DocumentNumberEmptyWrapper : WrapperBase<DocumentNumber>
	{
	    public DocumentNumberEmptyWrapper(DocumentNumber model) : base(model) { }
    }

		
    public partial class IncomingRequestWrapper : WrapperBase<IncomingRequest>
	{
	    public IncomingRequestWrapper(IncomingRequest model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Актуален
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

        /// <summary>
        /// Дата поручения
        /// </summary>
        public System.Nullable<System.DateTime> InstructionDate
        {
          get { return Model.InstructionDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> InstructionDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(InstructionDate));
        public bool InstructionDateIsChanged => GetIsChanged(nameof(InstructionDate));

        /// <summary>
        /// Дата исполнения поручения
        /// </summary>
        public System.Nullable<System.DateTime> DoneDate
        {
          get { return Model.DoneDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DoneDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DoneDate));
        public bool DoneDateIsChanged => GetIsChanged(nameof(DoneDate));

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

        #region ComplexProperties

        /// <summary>
        /// Запрос
        /// </summary>
	    public DocumentWrapper Document 
        {
            get { return GetWrapper<DocumentWrapper>(); }
            set { SetComplexValue<Document, DocumentWrapper>(Document, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Исполнители
        /// </summary>
        public IValidatableChangeTrackingCollection<EmployeeWrapper> Performers { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Исполнен
        /// </summary>
        public System.Boolean IsDone => Model.IsDone; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<DocumentWrapper>(nameof(Document), Model.Document == null ? null : new DocumentWrapper(Model.Document));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Performers == null) throw new ArgumentException($"{nameof(Model.Performers)} cannot be null");
          Performers = new ValidatableChangeTrackingCollection<EmployeeWrapper>(Model.Performers.Select(e => new EmployeeWrapper(e)));
          RegisterCollection(Performers, Model.Performers);
        }
	}

    public class IncomingRequestEmptyWrapper : WrapperBase<IncomingRequest>
	{
	    public IncomingRequestEmptyWrapper(IncomingRequest model) : base(model) { }
    }

		
    public partial class LaborHourCostWrapper : WrapperBase<LaborHourCost>
	{
	    public LaborHourCostWrapper(LaborHourCost model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Сумма
        /// </summary>
        public System.Double Sum
        {
          get { return Model.Sum; }
          set { SetValue(value); }
        }
        public System.Double SumOriginalValue => GetOriginalValue<System.Double>(nameof(Sum));
        public bool SumIsChanged => GetIsChanged(nameof(Sum));

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
	}

    public class LaborHourCostEmptyWrapper : WrapperBase<LaborHourCost>
	{
	    public LaborHourCostEmptyWrapper(LaborHourCost model) : base(model) { }
    }

		
    public partial class LaborHoursWrapper : WrapperBase<LaborHours>
	{
	    public LaborHoursWrapper(LaborHours model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Количество
        /// </summary>
        public System.Double Amount
        {
          get { return Model.Amount; }
          set { SetValue(value); }
        }
        public System.Double AmountOriginalValue => GetOriginalValue<System.Double>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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
        /// Параметры блока
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class LaborHoursEmptyWrapper : WrapperBase<LaborHours>
	{
	    public LaborHoursEmptyWrapper(LaborHours model) : base(model) { }
    }

		
    public partial class LogUnitWrapper : WrapperBase<LogUnit>
	{
	    public LogUnitWrapper(LogUnit model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Заголовок
        /// </summary>
        public System.String Head
        {
          get { return Model.Head; }
          set { SetValue(value); }
        }
        public System.String HeadOriginalValue => GetOriginalValue<System.String>(nameof(Head));
        public bool HeadIsChanged => GetIsChanged(nameof(Head));

        /// <summary>
        /// Сообщение
        /// </summary>
        public System.String Message
        {
          get { return Model.Message; }
          set { SetValue(value); }
        }
        public System.String MessageOriginalValue => GetOriginalValue<System.String>(nameof(Message));
        public bool MessageIsChanged => GetIsChanged(nameof(Message));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper Author 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Author, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Author), Model.Author == null ? null : new UserWrapper(Model.Author));
        }
	}

    public class LogUnitEmptyWrapper : WrapperBase<LogUnit>
	{
	    public LogUnitEmptyWrapper(LogUnit model) : base(model) { }
    }

		
    public partial class LosingReasonWrapper : WrapperBase<LosingReason>
	{
	    public LosingReasonWrapper(LosingReason model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
	}

    public class LosingReasonEmptyWrapper : WrapperBase<LosingReason>
	{
	    public LosingReasonEmptyWrapper(LosingReason model) : base(model) { }
    }

		
    public partial class MarketFieldWrapper : WrapperBase<MarketField>
	{
	    public MarketFieldWrapper(MarketField model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        /// Сферы деятельноси
        /// </summary>
        public IValidatableChangeTrackingCollection<ActivityFieldWrapper> ActivityFields { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.ActivityFields == null) throw new ArgumentException($"{nameof(Model.ActivityFields)} cannot be null");
          ActivityFields = new ValidatableChangeTrackingCollection<ActivityFieldWrapper>(Model.ActivityFields.Select(e => new ActivityFieldWrapper(e)));
          RegisterCollection(ActivityFields, Model.ActivityFields);
        }
	}

    public class MarketFieldEmptyWrapper : WrapperBase<MarketField>
	{
	    public MarketFieldEmptyWrapper(MarketField model) : base(model) { }
    }

		
    public partial class PaymentActualWrapper : WrapperBase<PaymentActual>
	{
	    public PaymentActualWrapper(PaymentActual model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// SalesUnitId
        /// </summary>
        public System.Guid SalesUnitId
        {
          get { return Model.SalesUnitId; }
          set { SetValue(value); }
        }
        public System.Guid SalesUnitIdOriginalValue => GetOriginalValue<System.Guid>(nameof(SalesUnitId));
        public bool SalesUnitIdIsChanged => GetIsChanged(nameof(SalesUnitId));

        /// <summary>
        /// PaymentDocumentId
        /// </summary>
        public System.Guid PaymentDocumentId
        {
          get { return Model.PaymentDocumentId; }
          set { SetValue(value); }
        }
        public System.Guid PaymentDocumentIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PaymentDocumentId));
        public bool PaymentDocumentIdIsChanged => GetIsChanged(nameof(PaymentDocumentId));

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Сумма
        /// </summary>
        public System.Double Sum
        {
          get { return Model.Sum; }
          set { SetValue(value); }
        }
        public System.Double SumOriginalValue => GetOriginalValue<System.Double>(nameof(Sum));
        public bool SumIsChanged => GetIsChanged(nameof(Sum));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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
	}

    public class PaymentActualEmptyWrapper : WrapperBase<PaymentActual>
	{
	    public PaymentActualEmptyWrapper(PaymentActual model) : base(model) { }
    }

		
    public partial class PaymentConditionPointWrapper : WrapperBase<PaymentConditionPoint>
	{
	    public PaymentConditionPointWrapper(PaymentConditionPoint model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// PaymentConditionPointEnum
        /// </summary>
        public HVTApp.Model.POCOs.PaymentConditionPointEnum PaymentConditionPointEnum
        {
          get { return Model.PaymentConditionPointEnum; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.PaymentConditionPointEnum PaymentConditionPointEnumOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.PaymentConditionPointEnum>(nameof(PaymentConditionPointEnum));
        public bool PaymentConditionPointEnumIsChanged => GetIsChanged(nameof(PaymentConditionPointEnum));

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
	}

    public class PaymentConditionPointEmptyWrapper : WrapperBase<PaymentConditionPoint>
	{
	    public PaymentConditionPointEmptyWrapper(PaymentConditionPoint model) : base(model) { }
    }

		
    public partial class PaymentPlannedWrapper : WrapperBase<PaymentPlanned>
	{
	    public PaymentPlannedWrapper(PaymentPlanned model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Дата расчетная
        /// </summary>
        public System.DateTime DateCalculated
        {
          get { return Model.DateCalculated; }
          set { SetValue(value); }
        }
        public System.DateTime DateCalculatedOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateCalculated));
        public bool DateCalculatedIsChanged => GetIsChanged(nameof(DateCalculated));

        /// <summary>
        /// Часть
        /// </summary>
        public System.Double Part
        {
          get { return Model.Part; }
          set { SetValue(value); }
        }
        public System.Double PartOriginalValue => GetOriginalValue<System.Double>(nameof(Part));
        public bool PartIsChanged => GetIsChanged(nameof(Part));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Связанное условие
        /// </summary>
	    public PaymentConditionWrapper Condition 
        {
            get { return GetWrapper<PaymentConditionWrapper>(); }
            set { SetComplexValue<PaymentCondition, PaymentConditionWrapper>(Condition, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<PaymentConditionWrapper>(nameof(Condition), Model.Condition == null ? null : new PaymentConditionWrapper(Model.Condition));
        }
	}

    public class PaymentPlannedEmptyWrapper : WrapperBase<PaymentPlanned>
	{
	    public PaymentPlannedEmptyWrapper(PaymentPlanned model) : base(model) { }
    }

		
    public partial class PenaltyWrapper : WrapperBase<Penalty>
	{
	    public PenaltyWrapper(Penalty model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// % за день просрочки
        /// </summary>
        public System.Double PercentPerDay
        {
          get { return Model.PercentPerDay; }
          set { SetValue(value); }
        }
        public System.Double PercentPerDayOriginalValue => GetOriginalValue<System.Double>(nameof(PercentPerDay));
        public bool PercentPerDayIsChanged => GetIsChanged(nameof(PercentPerDay));

        /// <summary>
        /// Ограничение штрафа
        /// </summary>
        public System.Double PercentLimit
        {
          get { return Model.PercentLimit; }
          set { SetValue(value); }
        }
        public System.Double PercentLimitOriginalValue => GetOriginalValue<System.Double>(nameof(PercentLimit));
        public bool PercentLimitIsChanged => GetIsChanged(nameof(PercentLimit));

        /// <summary>
        /// Фактически уплаченные штрафы
        /// </summary>
        public System.Double PenaltyPaid
        {
          get { return Model.PenaltyPaid; }
          set { SetValue(value); }
        }
        public System.Double PenaltyPaidOriginalValue => GetOriginalValue<System.Double>(nameof(PenaltyPaid));
        public bool PenaltyPaidIsChanged => GetIsChanged(nameof(PenaltyPaid));

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
	}

    public class PenaltyEmptyWrapper : WrapperBase<Penalty>
	{
	    public PenaltyEmptyWrapper(Penalty model) : base(model) { }
    }

		
    public partial class PriceCalculationWrapper : WrapperBase<PriceCalculation>
	{
	    public PriceCalculationWrapper(PriceCalculation model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Требуется расчетный файл
        /// </summary>
        public System.Boolean IsNeedExcelFile
        {
          get { return Model.IsNeedExcelFile; }
          set { SetValue(value); }
        }
        public System.Boolean IsNeedExcelFileOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsNeedExcelFile));
        public bool IsNeedExcelFileIsChanged => GetIsChanged(nameof(IsNeedExcelFile));

        /// <summary>
        /// Id технико-стоимостных проработок (группы)
        /// </summary>
        public System.Nullable<System.Guid> PriceEngineeringTasksId
        {
          get { return Model.PriceEngineeringTasksId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> PriceEngineeringTasksIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(PriceEngineeringTasksId));
        public bool PriceEngineeringTasksIdIsChanged => GetIsChanged(nameof(PriceEngineeringTasksId));

        /// <summary>
        /// Связано с ТСЕ
        /// </summary>
        public System.Boolean IsTceConnected
        {
          get { return Model.IsTceConnected; }
          set { SetValue(value); }
        }
        public System.Boolean IsTceConnectedOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsTceConnected));
        public bool IsTceConnectedIsChanged => GetIsChanged(nameof(IsTceConnected));

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

        #region ComplexProperties

        /// <summary>
        /// Инициатор
        /// </summary>
	    public UserWrapper Initiator 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Initiator, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Единицы расчета
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationItemWrapper> PriceCalculationItems { get; private set; }

        /// <summary>
        /// История
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationHistoryItemWrapper> History { get; private set; }

        /// <summary>
        /// Файлы расчета
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationFileWrapper> Files { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// IsStarted
        /// </summary>
        public System.Boolean IsStarted => Model.IsStarted; 

        /// <summary>
        /// IsFinished
        /// </summary>
        public System.Boolean IsFinished => Model.IsFinished; 

        /// <summary>
        /// Старт задачи
        /// </summary>
        public System.Nullable<System.DateTime> TaskOpenMoment => Model.TaskOpenMoment; 

        /// <summary>
        /// Финиш задачи
        /// </summary>
        public System.Nullable<System.DateTime> TaskCloseMoment => Model.TaskCloseMoment; 

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name => Model.Name; 

        /// <summary>
        /// Элемент истории расчета ПЗ
        /// </summary>
        public HVTApp.Model.POCOs.PriceCalculationHistoryItem LastHistoryItem => Model.LastHistoryItem; 

        /// <summary>
        /// Пользователь
        /// </summary>
        public HVTApp.Model.POCOs.User FrontManager => Model.FrontManager; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Initiator), Model.Initiator == null ? null : new UserWrapper(Model.Initiator));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.PriceCalculationItems == null) throw new ArgumentException($"{nameof(Model.PriceCalculationItems)} cannot be null");
          PriceCalculationItems = new ValidatableChangeTrackingCollection<PriceCalculationItemWrapper>(Model.PriceCalculationItems.Select(e => new PriceCalculationItemWrapper(e)));
          RegisterCollection(PriceCalculationItems, Model.PriceCalculationItems);
          if (Model.History == null) throw new ArgumentException($"{nameof(Model.History)} cannot be null");
          History = new ValidatableChangeTrackingCollection<PriceCalculationHistoryItemWrapper>(Model.History.Select(e => new PriceCalculationHistoryItemWrapper(e)));
          RegisterCollection(History, Model.History);
          if (Model.Files == null) throw new ArgumentException($"{nameof(Model.Files)} cannot be null");
          Files = new ValidatableChangeTrackingCollection<PriceCalculationFileWrapper>(Model.Files.Select(e => new PriceCalculationFileWrapper(e)));
          RegisterCollection(Files, Model.Files);
        }
	}

    public class PriceCalculationEmptyWrapper : WrapperBase<PriceCalculation>
	{
	    public PriceCalculationEmptyWrapper(PriceCalculation model) : base(model) { }
    }

		
    public partial class PriceCalculationFileWrapper : WrapperBase<PriceCalculationFile>
	{
	    public PriceCalculationFileWrapper(PriceCalculationFile model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Момент создания
        /// </summary>
        public System.DateTime CreationMoment
        {
          get { return Model.CreationMoment; }
          set { SetValue(value); }
        }
        public System.DateTime CreationMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(CreationMoment));
        public bool CreationMomentIsChanged => GetIsChanged(nameof(CreationMoment));

        /// <summary>
        /// CalculationId
        /// </summary>
        public System.Guid CalculationId
        {
          get { return Model.CalculationId; }
          set { SetValue(value); }
        }
        public System.Guid CalculationIdOriginalValue => GetOriginalValue<System.Guid>(nameof(CalculationId));
        public bool CalculationIdIsChanged => GetIsChanged(nameof(CalculationId));

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
	}

    public class PriceCalculationFileEmptyWrapper : WrapperBase<PriceCalculationFile>
	{
	    public PriceCalculationFileEmptyWrapper(PriceCalculationFile model) : base(model) { }
    }

		
    public partial class PriceCalculationHistoryItemWrapper : WrapperBase<PriceCalculationHistoryItem>
	{
	    public PriceCalculationHistoryItemWrapper(PriceCalculationHistoryItem model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id расчета ПЗ
        /// </summary>
        public System.Guid PriceCalculationId
        {
          get { return Model.PriceCalculationId; }
          set { SetValue(value); }
        }
        public System.Guid PriceCalculationIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceCalculationId));
        public bool PriceCalculationIdIsChanged => GetIsChanged(nameof(PriceCalculationId));

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Тип элемента истории
        /// </summary>
        public HVTApp.Model.POCOs.PriceCalculationHistoryItemType Type
        {
          get { return Model.Type; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.PriceCalculationHistoryItemType TypeOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.PriceCalculationHistoryItemType>(nameof(Type));
        public bool TypeIsChanged => GetIsChanged(nameof(Type));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper User 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(User, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(User), Model.User == null ? null : new UserWrapper(Model.User));
        }
	}

    public class PriceCalculationHistoryItemEmptyWrapper : WrapperBase<PriceCalculationHistoryItem>
	{
	    public PriceCalculationHistoryItemEmptyWrapper(PriceCalculationHistoryItem model) : base(model) { }
    }

		
    public partial class PriceCalculationItemWrapper : WrapperBase<PriceCalculationItem>
	{
	    public PriceCalculationItemWrapper(PriceCalculationItem model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// PriceCalculationId
        /// </summary>
        public System.Guid PriceCalculationId
        {
          get { return Model.PriceCalculationId; }
          set { SetValue(value); }
        }
        public System.Guid PriceCalculationIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceCalculationId));
        public bool PriceCalculationIdIsChanged => GetIsChanged(nameof(PriceCalculationId));

        /// <summary>
        /// PriceEngineeringTaskId
        /// </summary>
        public System.Nullable<System.Guid> PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// Дата ОИТ
        /// </summary>
        public System.DateTime OrderInTakeDate
        {
          get { return Model.OrderInTakeDate; }
          set { SetValue(value); }
        }
        public System.DateTime OrderInTakeDateOriginalValue => GetOriginalValue<System.DateTime>(nameof(OrderInTakeDate));
        public bool OrderInTakeDateIsChanged => GetIsChanged(nameof(OrderInTakeDate));

        /// <summary>
        /// Дата реализации
        /// </summary>
        public System.DateTime RealizationDate
        {
          get { return Model.RealizationDate; }
          set { SetValue(value); }
        }
        public System.DateTime RealizationDateOriginalValue => GetOriginalValue<System.DateTime>(nameof(RealizationDate));
        public bool RealizationDateIsChanged => GetIsChanged(nameof(RealizationDate));

        /// <summary>
        /// Позиция в TeamCenter
        /// </summary>
        public System.Nullable<System.Int32> PositionInTeamCenter
        {
          get { return Model.PositionInTeamCenter; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int32> PositionInTeamCenterOriginalValue => GetOriginalValue<System.Nullable<System.Int32>>(nameof(PositionInTeamCenter));
        public bool PositionInTeamCenterIsChanged => GetIsChanged(nameof(PositionInTeamCenter));

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

        #region ComplexProperties

        /// <summary>
        /// Условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSet, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Единицы продаж
        /// </summary>
        public IValidatableChangeTrackingCollection<SalesUnitWrapper> SalesUnits { get; private set; }

        /// <summary>
        /// Сралчахвосты
        /// </summary>
        public IValidatableChangeTrackingCollection<StructureCostWrapper> StructureCosts { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// FinishDate
        /// </summary>
        public System.Nullable<System.DateTime> FinishDate => Model.FinishDate; 

        /// <summary>
        /// HasPrice
        /// </summary>
        public System.Boolean HasPrice => Model.HasPrice; 

        /// <summary>
        /// Price
        /// </summary>
        public System.Nullable<System.Double> Price => Model.Price; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSet));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.SalesUnits == null) throw new ArgumentException($"{nameof(Model.SalesUnits)} cannot be null");
          SalesUnits = new ValidatableChangeTrackingCollection<SalesUnitWrapper>(Model.SalesUnits.Select(e => new SalesUnitWrapper(e)));
          RegisterCollection(SalesUnits, Model.SalesUnits);
          if (Model.StructureCosts == null) throw new ArgumentException($"{nameof(Model.StructureCosts)} cannot be null");
          StructureCosts = new ValidatableChangeTrackingCollection<StructureCostWrapper>(Model.StructureCosts.Select(e => new StructureCostWrapper(e)));
          RegisterCollection(StructureCosts, Model.StructureCosts);
        }
	}

    public class PriceCalculationItemEmptyWrapper : WrapperBase<PriceCalculationItem>
	{
	    public PriceCalculationItemEmptyWrapper(PriceCalculationItem model) : base(model) { }
    }

		
    public partial class DesignDepartmentParametersWrapper : WrapperBase<DesignDepartmentParameters>
	{
	    public DesignDepartmentParametersWrapper(DesignDepartmentParameters model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id департамента
        /// </summary>
        public System.Guid DesignDepartmentId
        {
          get { return Model.DesignDepartmentId; }
          set { SetValue(value); }
        }
        public System.Guid DesignDepartmentIdOriginalValue => GetOriginalValue<System.Guid>(nameof(DesignDepartmentId));
        public bool DesignDepartmentIdIsChanged => GetIsChanged(nameof(DesignDepartmentId));

        /// <summary>
        /// Название набора параметров
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class DesignDepartmentParametersEmptyWrapper : WrapperBase<DesignDepartmentParameters>
	{
	    public DesignDepartmentParametersEmptyWrapper(DesignDepartmentParameters model) : base(model) { }
    }

		
    public partial class DesignDepartmentParametersAddedBlocksWrapper : WrapperBase<DesignDepartmentParametersAddedBlocks>
	{
	    public DesignDepartmentParametersAddedBlocksWrapper(DesignDepartmentParametersAddedBlocks model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id департамента
        /// </summary>
        public System.Guid DesignDepartmentId
        {
          get { return Model.DesignDepartmentId; }
          set { SetValue(value); }
        }
        public System.Guid DesignDepartmentIdOriginalValue => GetOriginalValue<System.Guid>(nameof(DesignDepartmentId));
        public bool DesignDepartmentIdIsChanged => GetIsChanged(nameof(DesignDepartmentId));

        /// <summary>
        /// Название набора параметров
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class DesignDepartmentParametersAddedBlocksEmptyWrapper : WrapperBase<DesignDepartmentParametersAddedBlocks>
	{
	    public DesignDepartmentParametersAddedBlocksEmptyWrapper(DesignDepartmentParametersAddedBlocks model) : base(model) { }
    }

		
    public partial class DesignDepartmentParametersSubTaskWrapper : WrapperBase<DesignDepartmentParametersSubTask>
	{
	    public DesignDepartmentParametersSubTaskWrapper(DesignDepartmentParametersSubTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id департамента
        /// </summary>
        public System.Guid DesignDepartmentId
        {
          get { return Model.DesignDepartmentId; }
          set { SetValue(value); }
        }
        public System.Guid DesignDepartmentIdOriginalValue => GetOriginalValue<System.Guid>(nameof(DesignDepartmentId));
        public bool DesignDepartmentIdIsChanged => GetIsChanged(nameof(DesignDepartmentId));

        /// <summary>
        /// Название набора параметров
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class DesignDepartmentParametersSubTaskEmptyWrapper : WrapperBase<DesignDepartmentParametersSubTask>
	{
	    public DesignDepartmentParametersSubTaskEmptyWrapper(DesignDepartmentParametersSubTask model) : base(model) { }
    }

		
    public partial class NotificationsReportsSettingsWrapper : WrapperBase<NotificationsReportsSettings>
	{
	    public NotificationsReportsSettingsWrapper(NotificationsReportsSettings model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Когда отправлен последний отчёт ГК ВВА
        /// </summary>
        public System.DateTime ChiefEngineerReportMoment
        {
          get { return Model.ChiefEngineerReportMoment; }
          set { SetValue(value); }
        }
        public System.DateTime ChiefEngineerReportMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(ChiefEngineerReportMoment));
        public bool ChiefEngineerReportMomentIsChanged => GetIsChanged(nameof(ChiefEngineerReportMoment));

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
        /// Список рассылки отчёта ГК ВВА
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> ChiefEngineerReportDistributionList { get; private set; }

        /// <summary>
        /// Список рассылки уведомлений о платежах
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> SavePaymentDocumentDistributionList { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.ChiefEngineerReportDistributionList == null) throw new ArgumentException($"{nameof(Model.ChiefEngineerReportDistributionList)} cannot be null");
          ChiefEngineerReportDistributionList = new ValidatableChangeTrackingCollection<UserWrapper>(Model.ChiefEngineerReportDistributionList.Select(e => new UserWrapper(e)));
          RegisterCollection(ChiefEngineerReportDistributionList, Model.ChiefEngineerReportDistributionList);
          if (Model.SavePaymentDocumentDistributionList == null) throw new ArgumentException($"{nameof(Model.SavePaymentDocumentDistributionList)} cannot be null");
          SavePaymentDocumentDistributionList = new ValidatableChangeTrackingCollection<UserWrapper>(Model.SavePaymentDocumentDistributionList.Select(e => new UserWrapper(e)));
          RegisterCollection(SavePaymentDocumentDistributionList, Model.SavePaymentDocumentDistributionList);
        }
	}

    public class NotificationsReportsSettingsEmptyWrapper : WrapperBase<NotificationsReportsSettings>
	{
	    public NotificationsReportsSettingsEmptyWrapper(NotificationsReportsSettings model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskWrapper : WrapperBase<PriceEngineeringTask>
	{
	    public PriceEngineeringTaskWrapper(PriceEngineeringTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// №
        /// </summary>
        public System.Int32 Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.Int32 NumberOriginalValue => GetOriginalValue<System.Int32>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Id группы
        /// </summary>
        public System.Nullable<System.Guid> ParentPriceEngineeringTasksId
        {
          get { return Model.ParentPriceEngineeringTasksId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> ParentPriceEngineeringTasksIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(ParentPriceEngineeringTasksId));
        public bool ParentPriceEngineeringTasksIdIsChanged => GetIsChanged(nameof(ParentPriceEngineeringTasksId));

        /// <summary>
        /// Количество блоков продукта
        /// </summary>
        public System.Int32 Amount
        {
          get { return Model.Amount; }
          set { SetValue(value); }
        }
        public System.Int32 AmountOriginalValue => GetOriginalValue<System.Int32>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

        /// <summary>
        /// Id материнской задачи
        /// </summary>
        public System.Nullable<System.Guid> ParentPriceEngineeringTaskId
        {
          get { return Model.ParentPriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> ParentPriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(ParentPriceEngineeringTaskId));
        public bool ParentPriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(ParentPriceEngineeringTaskId));

        /// <summary>
        /// Приоритет проработки задачи
        /// </summary>
        public System.Nullable<System.DateTime> TermPriority
        {
          get { return Model.TermPriority; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> TermPriorityOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(TermPriority));
        public bool TermPriorityIsChanged => GetIsChanged(nameof(TermPriority));

        /// <summary>
        /// Запрос на проверку от руководителя
        /// </summary>
        public System.Boolean RequestForVerificationFromHead
        {
          get { return Model.RequestForVerificationFromHead; }
          set { SetValue(value); }
        }
        public System.Boolean RequestForVerificationFromHeadOriginalValue => GetOriginalValue<System.Boolean>(nameof(RequestForVerificationFromHead));
        public bool RequestForVerificationFromHeadIsChanged => GetIsChanged(nameof(RequestForVerificationFromHead));

        /// <summary>
        /// Запрос на проверку от исполнителя
        /// </summary>
        public System.Boolean RequestForVerificationFromConstructor
        {
          get { return Model.RequestForVerificationFromConstructor; }
          set { SetValue(value); }
        }
        public System.Boolean RequestForVerificationFromConstructorOriginalValue => GetOriginalValue<System.Boolean>(nameof(RequestForVerificationFromConstructor));
        public bool RequestForVerificationFromConstructorIsChanged => GetIsChanged(nameof(RequestForVerificationFromConstructor));

        /// <summary>
        /// ТЗ валидно для производства
        /// </summary>
        public System.Boolean IsValidForProduction
        {
          get { return Model.IsValidForProduction; }
          set { SetValue(value); }
        }
        public System.Boolean IsValidForProductionOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsValidForProduction));
        public bool IsValidForProductionIsChanged => GetIsChanged(nameof(IsValidForProduction));

        /// <summary>
        /// Позиция в ТСЕ
        /// </summary>
        public System.String TcePosition
        {
          get { return Model.TcePosition; }
          set { SetValue(value); }
        }
        public System.String TcePositionOriginalValue => GetOriginalValue<System.String>(nameof(TcePosition));
        public bool TcePositionIsChanged => GetIsChanged(nameof(TcePosition));

        /// <summary>
        /// Требуется разработка КД
        /// </summary>
        public System.Boolean NeedDesignDocumentationDevelopment
        {
          get { return Model.NeedDesignDocumentationDevelopment; }
          set { SetValue(value); }
        }
        public System.Boolean NeedDesignDocumentationDevelopmentOriginalValue => GetOriginalValue<System.Boolean>(nameof(NeedDesignDocumentationDevelopment));
        public bool NeedDesignDocumentationDevelopmentIsChanged => GetIsChanged(nameof(NeedDesignDocumentationDevelopment));

        /// <summary>
        /// Дней на разработку КД
        /// </summary>
        public System.Nullable<System.Int16> DaysToDesignDocumentationDevelopment
        {
          get { return Model.DaysToDesignDocumentationDevelopment; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int16> DaysToDesignDocumentationDevelopmentOriginalValue => GetOriginalValue<System.Nullable<System.Int16>>(nameof(DaysToDesignDocumentationDevelopment));
        public bool DaysToDesignDocumentationDevelopmentIsChanged => GetIsChanged(nameof(DaysToDesignDocumentationDevelopment));

        /// <summary>
        /// Комментарий по разработке КД
        /// </summary>
        public System.String DesignDocumentationAvailabilityComment
        {
          get { return Model.DesignDocumentationAvailabilityComment; }
          set { SetValue(value); }
        }
        public System.String DesignDocumentationAvailabilityCommentOriginalValue => GetOriginalValue<System.String>(nameof(DesignDocumentationAvailabilityComment));
        public bool DesignDocumentationAvailabilityCommentIsChanged => GetIsChanged(nameof(DesignDocumentationAvailabilityComment));

        /// <summary>
        /// Требуется оснастка
        /// </summary>
        public System.Boolean NeedEquipment
        {
          get { return Model.NeedEquipment; }
          set { SetValue(value); }
        }
        public System.Boolean NeedEquipmentOriginalValue => GetOriginalValue<System.Boolean>(nameof(NeedEquipment));
        public bool NeedEquipmentIsChanged => GetIsChanged(nameof(NeedEquipment));

        /// <summary>
        /// Документация загружена в TeamCenter
        /// </summary>
        public System.Boolean IsUploadedDocumentationToTeamCenter
        {
          get { return Model.IsUploadedDocumentationToTeamCenter; }
          set { SetValue(value); }
        }
        public System.Boolean IsUploadedDocumentationToTeamCenterOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsUploadedDocumentationToTeamCenter));
        public bool IsUploadedDocumentationToTeamCenterIsChanged => GetIsChanged(nameof(IsUploadedDocumentationToTeamCenter));

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        public System.Nullable<System.Double> PriceIncreaseFactor
        {
          get { return Model.PriceIncreaseFactor; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> PriceIncreaseFactorOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(PriceIncreaseFactor));
        public bool PriceIncreaseFactorIsChanged => GetIsChanged(nameof(PriceIncreaseFactor));

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

        #region ComplexProperties

        /// <summary>
        /// Бюро конструкторов
        /// </summary>
	    public DesignDepartmentWrapper DesignDepartment 
        {
            get { return GetWrapper<DesignDepartmentWrapper>(); }
            set { SetComplexValue<DesignDepartment, DesignDepartmentWrapper>(DesignDepartment, value); }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
	    public UserWrapper UserConstructor 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(UserConstructor, value); }
        }

        /// <summary>
        /// Плановик
        /// </summary>
	    public UserWrapper UserPlanMaker 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(UserPlanMaker, value); }
        }

        /// <summary>
        /// Проверяющий конструктор
        /// </summary>
	    public UserWrapper UserConstructorInspector 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(UserConstructorInspector, value); }
        }

        /// <summary>
        /// Инициатор подзадачи
        /// </summary>
	    public UserWrapper UserConstructorInitiator 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(UserConstructorInitiator, value); }
        }

        /// <summary>
        /// Блок продукта от менеджера
        /// </summary>
	    public ProductBlockWrapper ProductBlockManager 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(ProductBlockManager, value); }
        }

        /// <summary>
        /// Блок продукта от инженера-конструктора
        /// </summary>
	    public ProductBlockWrapper ProductBlockEngineer 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(ProductBlockEngineer, value); }
        }

        /// <summary>
        /// Спецификация
        /// </summary>
	    public SpecificationWrapper Specification 
        {
            get { return GetWrapper<SpecificationWrapper>(); }
            set { SetComplexValue<Specification, SpecificationWrapper>(Specification, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Добавленные блоки продукта от инженера-конструктора
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskProductBlockAddedWrapper> ProductBlocksAdded { get; private set; }

        /// <summary>
        /// ProductBlocksAddedActual
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskProductBlockAddedWrapper> ProductBlocksAddedActual { get; private set; }

        /// <summary>
        /// Файлы технических требований
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskFileTechnicalRequirementsWrapper> FilesTechnicalRequirements { get; private set; }

        /// <summary>
        /// Файлы ответов ОГК
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskFileAnswerWrapper> FilesAnswers { get; private set; }

        /// <summary>
        /// Переписка
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskMessageWrapper> Messages { get; private set; }

        /// <summary>
        /// Дочерние задачи
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskWrapper> ChildPriceEngineeringTasks { get; private set; }

        /// <summary>
        /// Версии SCC
        /// </summary>
        public IValidatableChangeTrackingCollection<StructureCostVersionWrapper> StructureCostVersions { get; private set; }

        /// <summary>
        /// Строки расчётов ПЗ
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationItemWrapper> PriceCalculationItems { get; private set; }

        /// <summary>
        /// Статусы проработки
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskStatusWrapper> Statuses { get; private set; }

        /// <summary>
        /// SalesUnits
        /// </summary>
        public IValidatableChangeTrackingCollection<SalesUnitWrapper> SalesUnits { get; private set; }

        /// <summary>
        /// Задачи на изменение номера стракчакоста блока
        /// </summary>
        public IValidatableChangeTrackingCollection<UpdateStructureCostNumberTaskWrapper> UpdateStructureCostNumberTasks { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// VerificationIsRequested
        /// </summary>
        public System.Boolean VerificationIsRequested => Model.VerificationIsRequested; 

        /// <summary>
        /// HasAnyUpdateStructureCostNumberTaskNotFinished
        /// </summary>
        public System.Boolean HasAnyUpdateStructureCostNumberTaskNotFinished => Model.HasAnyUpdateStructureCostNumberTaskNotFinished; 

        /// <summary>
        /// IsInProcessByConstructor
        /// </summary>
        public System.Boolean IsInProcessByConstructor => Model.IsInProcessByConstructor; 

        /// <summary>
        /// IsFinishedByConstructor
        /// </summary>
        public System.Boolean IsFinishedByConstructor => Model.IsFinishedByConstructor; 

        /// <summary>
        /// IsAccepted
        /// </summary>
        public System.Boolean IsAccepted => Model.IsAccepted; 

        /// <summary>
        /// IsAcceptedTotal
        /// </summary>
        public System.Boolean IsAcceptedTotal => Model.IsAcceptedTotal; 

        /// <summary>
        /// IsStoppedTotal
        /// </summary>
        public System.Boolean IsStoppedTotal => Model.IsStoppedTotal; 

        /// <summary>
        /// Старт
        /// </summary>
        public System.Nullable<System.DateTime> StartMoment => Model.StartMoment; 

        /// <summary>
        /// IsStarted
        /// </summary>
        public System.Boolean IsStarted => Model.IsStarted; 

        /// <summary>
        /// AllProductBlocksHasSccNumbersInTce
        /// </summary>
        public System.Boolean AllProductBlocksHasSccNumbersInTce => Model.AllProductBlocksHasSccNumbersInTce; 

        /// <summary>
        /// HasDesignDocumentationInfo
        /// </summary>
        public System.Boolean HasDesignDocumentationInfo => Model.HasDesignDocumentationInfo; 

        /// <summary>
        /// IsFinishedByDesignDepartment
        /// </summary>
        public System.Boolean IsFinishedByDesignDepartment => Model.IsFinishedByDesignDepartment; 

        /// <summary>
        /// MomentFinishByDesignDepartment
        /// </summary>
        public System.Nullable<System.DateTime> MomentFinishByDesignDepartment => Model.MomentFinishByDesignDepartment; 

        /// <summary>
        /// IsTop
        /// </summary>
        public System.Boolean IsTop => Model.IsTop; 

        /// <summary>
        /// Статус
        /// </summary>
        public HVTApp.Model.POCOs.ScriptStep Status => Model.Status; 

        /// <summary>
        /// Статусы этой задачи и всех вложенных
        /// </summary>
        public System.Collections.Generic.IEnumerable<HVTApp.Model.POCOs.ScriptStep> StatusesAll => Model.StatusesAll; 

        /// <summary>
        /// Блок
        /// </summary>
        public HVTApp.Model.POCOs.ProductBlock ProductBlock => Model.ProductBlock; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<DesignDepartmentWrapper>(nameof(DesignDepartment), Model.DesignDepartment == null ? null : new DesignDepartmentWrapper(Model.DesignDepartment));
            InitializeComplexProperty<UserWrapper>(nameof(UserConstructor), Model.UserConstructor == null ? null : new UserWrapper(Model.UserConstructor));
            InitializeComplexProperty<UserWrapper>(nameof(UserPlanMaker), Model.UserPlanMaker == null ? null : new UserWrapper(Model.UserPlanMaker));
            InitializeComplexProperty<UserWrapper>(nameof(UserConstructorInspector), Model.UserConstructorInspector == null ? null : new UserWrapper(Model.UserConstructorInspector));
            InitializeComplexProperty<UserWrapper>(nameof(UserConstructorInitiator), Model.UserConstructorInitiator == null ? null : new UserWrapper(Model.UserConstructorInitiator));
            InitializeComplexProperty<ProductBlockWrapper>(nameof(ProductBlockManager), Model.ProductBlockManager == null ? null : new ProductBlockWrapper(Model.ProductBlockManager));
            InitializeComplexProperty<ProductBlockWrapper>(nameof(ProductBlockEngineer), Model.ProductBlockEngineer == null ? null : new ProductBlockWrapper(Model.ProductBlockEngineer));
            InitializeComplexProperty<SpecificationWrapper>(nameof(Specification), Model.Specification == null ? null : new SpecificationWrapper(Model.Specification));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.ProductBlocksAdded == null) throw new ArgumentException($"{nameof(Model.ProductBlocksAdded)} cannot be null");
          ProductBlocksAdded = new ValidatableChangeTrackingCollection<PriceEngineeringTaskProductBlockAddedWrapper>(Model.ProductBlocksAdded.Select(e => new PriceEngineeringTaskProductBlockAddedWrapper(e)));
          RegisterCollection(ProductBlocksAdded, Model.ProductBlocksAdded);
          if (Model.ProductBlocksAddedActual == null) throw new ArgumentException($"{nameof(Model.ProductBlocksAddedActual)} cannot be null");
          ProductBlocksAddedActual = new ValidatableChangeTrackingCollection<PriceEngineeringTaskProductBlockAddedWrapper>(Model.ProductBlocksAddedActual.Select(e => new PriceEngineeringTaskProductBlockAddedWrapper(e)));
          RegisterCollection(ProductBlocksAddedActual, Model.ProductBlocksAddedActual);
          if (Model.FilesTechnicalRequirements == null) throw new ArgumentException($"{nameof(Model.FilesTechnicalRequirements)} cannot be null");
          FilesTechnicalRequirements = new ValidatableChangeTrackingCollection<PriceEngineeringTaskFileTechnicalRequirementsWrapper>(Model.FilesTechnicalRequirements.Select(e => new PriceEngineeringTaskFileTechnicalRequirementsWrapper(e)));
          RegisterCollection(FilesTechnicalRequirements, Model.FilesTechnicalRequirements);
          if (Model.FilesAnswers == null) throw new ArgumentException($"{nameof(Model.FilesAnswers)} cannot be null");
          FilesAnswers = new ValidatableChangeTrackingCollection<PriceEngineeringTaskFileAnswerWrapper>(Model.FilesAnswers.Select(e => new PriceEngineeringTaskFileAnswerWrapper(e)));
          RegisterCollection(FilesAnswers, Model.FilesAnswers);
          if (Model.Messages == null) throw new ArgumentException($"{nameof(Model.Messages)} cannot be null");
          Messages = new ValidatableChangeTrackingCollection<PriceEngineeringTaskMessageWrapper>(Model.Messages.Select(e => new PriceEngineeringTaskMessageWrapper(e)));
          RegisterCollection(Messages, Model.Messages);
          if (Model.ChildPriceEngineeringTasks == null) throw new ArgumentException($"{nameof(Model.ChildPriceEngineeringTasks)} cannot be null");
          ChildPriceEngineeringTasks = new ValidatableChangeTrackingCollection<PriceEngineeringTaskWrapper>(Model.ChildPriceEngineeringTasks.Select(e => new PriceEngineeringTaskWrapper(e)));
          RegisterCollection(ChildPriceEngineeringTasks, Model.ChildPriceEngineeringTasks);
          if (Model.StructureCostVersions == null) throw new ArgumentException($"{nameof(Model.StructureCostVersions)} cannot be null");
          StructureCostVersions = new ValidatableChangeTrackingCollection<StructureCostVersionWrapper>(Model.StructureCostVersions.Select(e => new StructureCostVersionWrapper(e)));
          RegisterCollection(StructureCostVersions, Model.StructureCostVersions);
          if (Model.PriceCalculationItems == null) throw new ArgumentException($"{nameof(Model.PriceCalculationItems)} cannot be null");
          PriceCalculationItems = new ValidatableChangeTrackingCollection<PriceCalculationItemWrapper>(Model.PriceCalculationItems.Select(e => new PriceCalculationItemWrapper(e)));
          RegisterCollection(PriceCalculationItems, Model.PriceCalculationItems);
          if (Model.Statuses == null) throw new ArgumentException($"{nameof(Model.Statuses)} cannot be null");
          Statuses = new ValidatableChangeTrackingCollection<PriceEngineeringTaskStatusWrapper>(Model.Statuses.Select(e => new PriceEngineeringTaskStatusWrapper(e)));
          RegisterCollection(Statuses, Model.Statuses);
          if (Model.SalesUnits == null) throw new ArgumentException($"{nameof(Model.SalesUnits)} cannot be null");
          SalesUnits = new ValidatableChangeTrackingCollection<SalesUnitWrapper>(Model.SalesUnits.Select(e => new SalesUnitWrapper(e)));
          RegisterCollection(SalesUnits, Model.SalesUnits);
          if (Model.UpdateStructureCostNumberTasks == null) throw new ArgumentException($"{nameof(Model.UpdateStructureCostNumberTasks)} cannot be null");
          UpdateStructureCostNumberTasks = new ValidatableChangeTrackingCollection<UpdateStructureCostNumberTaskWrapper>(Model.UpdateStructureCostNumberTasks.Select(e => new UpdateStructureCostNumberTaskWrapper(e)));
          RegisterCollection(UpdateStructureCostNumberTasks, Model.UpdateStructureCostNumberTasks);
        }
	}

    public class PriceEngineeringTaskEmptyWrapper : WrapperBase<PriceEngineeringTask>
	{
	    public PriceEngineeringTaskEmptyWrapper(PriceEngineeringTask model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskFileAnswerWrapper : WrapperBase<PriceEngineeringTaskFileAnswer>
	{
	    public PriceEngineeringTaskFileAnswerWrapper(PriceEngineeringTaskFileAnswer model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id технико-стоимостной проработки
        /// </summary>
        public System.Guid PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Guid PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// Актуален
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

        /// <summary>
        /// Момент создания
        /// </summary>
        public System.DateTime CreationMoment
        {
          get { return Model.CreationMoment; }
          set { SetValue(value); }
        }
        public System.DateTime CreationMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(CreationMoment));
        public bool CreationMomentIsChanged => GetIsChanged(nameof(CreationMoment));

        /// <summary>
        /// Имя файла
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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
	}

    public class PriceEngineeringTaskFileAnswerEmptyWrapper : WrapperBase<PriceEngineeringTaskFileAnswer>
	{
	    public PriceEngineeringTaskFileAnswerEmptyWrapper(PriceEngineeringTaskFileAnswer model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskFileTechnicalRequirementsWrapper : WrapperBase<PriceEngineeringTaskFileTechnicalRequirements>
	{
	    public PriceEngineeringTaskFileTechnicalRequirementsWrapper(PriceEngineeringTaskFileTechnicalRequirements model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Актуален
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

        /// <summary>
        /// Момент создания
        /// </summary>
        public System.DateTime CreationMoment
        {
          get { return Model.CreationMoment; }
          set { SetValue(value); }
        }
        public System.DateTime CreationMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(CreationMoment));
        public bool CreationMomentIsChanged => GetIsChanged(nameof(CreationMoment));

        /// <summary>
        /// Имя файла
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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
	}

    public class PriceEngineeringTaskFileTechnicalRequirementsEmptyWrapper : WrapperBase<PriceEngineeringTaskFileTechnicalRequirements>
	{
	    public PriceEngineeringTaskFileTechnicalRequirementsEmptyWrapper(PriceEngineeringTaskFileTechnicalRequirements model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskMessageWrapper : WrapperBase<PriceEngineeringTaskMessage>
	{
	    public PriceEngineeringTaskMessageWrapper(PriceEngineeringTaskMessage model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id технико-стоимостной проработки
        /// </summary>
        public System.Guid PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Guid PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Сообщение
        /// </summary>
        public System.String Message
        {
          get { return Model.Message; }
          set { SetValue(value); }
        }
        public System.String MessageOriginalValue => GetOriginalValue<System.String>(nameof(Message));
        public bool MessageIsChanged => GetIsChanged(nameof(Message));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper Author 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Author, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(Author), Model.Author == null ? null : new UserWrapper(Model.Author));
        }
	}

    public class PriceEngineeringTaskMessageEmptyWrapper : WrapperBase<PriceEngineeringTaskMessage>
	{
	    public PriceEngineeringTaskMessageEmptyWrapper(PriceEngineeringTaskMessage model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskProductBlockAddedWrapper : WrapperBase<PriceEngineeringTaskProductBlockAdded>
	{
	    public PriceEngineeringTaskProductBlockAddedWrapper(PriceEngineeringTaskProductBlockAdded model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id технико-стоимостной проработки
        /// </summary>
        public System.Guid PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Guid PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// Количество
        /// </summary>
        public System.Int32 Amount
        {
          get { return Model.Amount; }
          set { SetValue(value); }
        }
        public System.Int32 AmountOriginalValue => GetOriginalValue<System.Int32>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

        /// <summary>
        /// На каждый блок
        /// </summary>
        public System.Boolean IsOnBlock
        {
          get { return Model.IsOnBlock; }
          set { SetValue(value); }
        }
        public System.Boolean IsOnBlockOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsOnBlock));
        public bool IsOnBlockIsChanged => GetIsChanged(nameof(IsOnBlock));

        /// <summary>
        /// Удалено
        /// </summary>
        public System.Boolean IsRemoved
        {
          get { return Model.IsRemoved; }
          set { SetValue(value); }
        }
        public System.Boolean IsRemovedOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsRemoved));
        public bool IsRemovedIsChanged => GetIsChanged(nameof(IsRemoved));

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

        #region ComplexProperties

        /// <summary>
        /// Блок продукта
        /// </summary>
	    public ProductBlockWrapper ProductBlock 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(ProductBlock, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Версии SCC
        /// </summary>
        public IValidatableChangeTrackingCollection<StructureCostVersionWrapper> StructureCostVersions { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// HasSccNumberInTce
        /// </summary>
        public System.Boolean HasSccNumberInTce => Model.HasSccNumberInTce; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductBlockWrapper>(nameof(ProductBlock), Model.ProductBlock == null ? null : new ProductBlockWrapper(Model.ProductBlock));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.StructureCostVersions == null) throw new ArgumentException($"{nameof(Model.StructureCostVersions)} cannot be null");
          StructureCostVersions = new ValidatableChangeTrackingCollection<StructureCostVersionWrapper>(Model.StructureCostVersions.Select(e => new StructureCostVersionWrapper(e)));
          RegisterCollection(StructureCostVersions, Model.StructureCostVersions);
        }
	}

    public class PriceEngineeringTaskProductBlockAddedEmptyWrapper : WrapperBase<PriceEngineeringTaskProductBlockAdded>
	{
	    public PriceEngineeringTaskProductBlockAddedEmptyWrapper(PriceEngineeringTaskProductBlockAdded model) : base(model) { }
    }

		
    public partial class PriceEngineeringTasksWrapper : WrapperBase<PriceEngineeringTasks>
	{
	    public PriceEngineeringTasksWrapper(PriceEngineeringTasks model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// №
        /// </summary>
        public System.Int32 Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.Int32 NumberOriginalValue => GetOriginalValue<System.Int32>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Номер ТСЕ
        /// </summary>
        public System.String TceNumber
        {
          get { return Model.TceNumber; }
          set { SetValue(value); }
        }
        public System.String TceNumberOriginalValue => GetOriginalValue<System.String>(nameof(TceNumber));
        public bool TceNumberIsChanged => GetIsChanged(nameof(TceNumber));

        /// <summary>
        /// Проработать до
        /// </summary>
        public System.DateTime WorkUpTo
        {
          get { return Model.WorkUpTo; }
          set { SetValue(value); }
        }
        public System.DateTime WorkUpToOriginalValue => GetOriginalValue<System.DateTime>(nameof(WorkUpTo));
        public bool WorkUpToIsChanged => GetIsChanged(nameof(WorkUpTo));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Комментарий руководителя бэкофиса
        /// </summary>
        public System.String CommentBackOfficeBoss
        {
          get { return Model.CommentBackOfficeBoss; }
          set { SetValue(value); }
        }
        public System.String CommentBackOfficeBossOriginalValue => GetOriginalValue<System.String>(nameof(CommentBackOfficeBoss));
        public bool CommentBackOfficeBossIsChanged => GetIsChanged(nameof(CommentBackOfficeBoss));

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

        #region ComplexProperties

        /// <summary>
        /// Менеджер
        /// </summary>
	    public UserWrapper UserManager 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(UserManager, value); }
        }

        /// <summary>
        /// BackManager
        /// </summary>
	    public UserWrapper BackManager 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(BackManager, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Файлы технических требований (общие)
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTasksFileTechnicalRequirementsWrapper> FilesTechnicalRequirements { get; private set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceEngineeringTaskWrapper> ChildPriceEngineeringTasks { get; private set; }

        /// <summary>
        /// Расчеты переменных затрат
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationWrapper> PriceCalculations { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// № полный
        /// </summary>
        public System.String NumberFull => Model.NumberFull; 

        /// <summary>
        /// Всё принято?
        /// </summary>
        public System.Boolean IsAccepted => Model.IsAccepted; 

        /// <summary>
        /// Старт
        /// </summary>
        public System.Nullable<System.DateTime> StartMoment => Model.StartMoment; 

        /// <summary>
        /// Статусы задач
        /// </summary>
        public System.Collections.Generic.IEnumerable<HVTApp.Model.POCOs.ScriptStep> StatusesAll => Model.StatusesAll; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(UserManager), Model.UserManager == null ? null : new UserWrapper(Model.UserManager));
            InitializeComplexProperty<UserWrapper>(nameof(BackManager), Model.BackManager == null ? null : new UserWrapper(Model.BackManager));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.FilesTechnicalRequirements == null) throw new ArgumentException($"{nameof(Model.FilesTechnicalRequirements)} cannot be null");
          FilesTechnicalRequirements = new ValidatableChangeTrackingCollection<PriceEngineeringTasksFileTechnicalRequirementsWrapper>(Model.FilesTechnicalRequirements.Select(e => new PriceEngineeringTasksFileTechnicalRequirementsWrapper(e)));
          RegisterCollection(FilesTechnicalRequirements, Model.FilesTechnicalRequirements);
          if (Model.ChildPriceEngineeringTasks == null) throw new ArgumentException($"{nameof(Model.ChildPriceEngineeringTasks)} cannot be null");
          ChildPriceEngineeringTasks = new ValidatableChangeTrackingCollection<PriceEngineeringTaskWrapper>(Model.ChildPriceEngineeringTasks.Select(e => new PriceEngineeringTaskWrapper(e)));
          RegisterCollection(ChildPriceEngineeringTasks, Model.ChildPriceEngineeringTasks);
          if (Model.PriceCalculations == null) throw new ArgumentException($"{nameof(Model.PriceCalculations)} cannot be null");
          PriceCalculations = new ValidatableChangeTrackingCollection<PriceCalculationWrapper>(Model.PriceCalculations.Select(e => new PriceCalculationWrapper(e)));
          RegisterCollection(PriceCalculations, Model.PriceCalculations);
        }
	}

    public class PriceEngineeringTasksEmptyWrapper : WrapperBase<PriceEngineeringTasks>
	{
	    public PriceEngineeringTasksEmptyWrapper(PriceEngineeringTasks model) : base(model) { }
    }

		
    public partial class PriceEngineeringTasksFileTechnicalRequirementsWrapper : WrapperBase<PriceEngineeringTasksFileTechnicalRequirements>
	{
	    public PriceEngineeringTasksFileTechnicalRequirementsWrapper(PriceEngineeringTasksFileTechnicalRequirements model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id технико-стоимостной проработки
        /// </summary>
        public System.Guid PrEngTasksId
        {
          get { return Model.PrEngTasksId; }
          set { SetValue(value); }
        }
        public System.Guid PrEngTasksIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PrEngTasksId));
        public bool PrEngTasksIdIsChanged => GetIsChanged(nameof(PrEngTasksId));

        /// <summary>
        /// Актуален
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

        /// <summary>
        /// Момент создания
        /// </summary>
        public System.DateTime CreationMoment
        {
          get { return Model.CreationMoment; }
          set { SetValue(value); }
        }
        public System.DateTime CreationMomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(CreationMoment));
        public bool CreationMomentIsChanged => GetIsChanged(nameof(CreationMoment));

        /// <summary>
        /// Имя файла
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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
	}

    public class PriceEngineeringTasksFileTechnicalRequirementsEmptyWrapper : WrapperBase<PriceEngineeringTasksFileTechnicalRequirements>
	{
	    public PriceEngineeringTasksFileTechnicalRequirementsEmptyWrapper(PriceEngineeringTasksFileTechnicalRequirements model) : base(model) { }
    }

		
    public partial class PriceEngineeringTaskStatusWrapper : WrapperBase<PriceEngineeringTaskStatus>
	{
	    public PriceEngineeringTaskStatusWrapper(PriceEngineeringTaskStatus model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id технико-стоимостной проработки
        /// </summary>
        public System.Guid PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Guid PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// StatusEnum
        /// </summary>
        public System.Int32 StatusEnum
        {
          get { return Model.StatusEnum; }
          set { SetValue(value); }
        }
        public System.Int32 StatusEnumOriginalValue => GetOriginalValue<System.Int32>(nameof(StatusEnum));
        public bool StatusEnumIsChanged => GetIsChanged(nameof(StatusEnum));

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
	}

    public class PriceEngineeringTaskStatusEmptyWrapper : WrapperBase<PriceEngineeringTaskStatus>
	{
	    public PriceEngineeringTaskStatusEmptyWrapper(PriceEngineeringTaskStatus model) : base(model) { }
    }

		
    public partial class StructureCostVersionWrapper : WrapperBase<StructureCostVersion>
	{
	    public StructureCostVersionWrapper(StructureCostVersion model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// PriceEngineeringTaskId
        /// </summary>
        public System.Nullable<System.Guid> PriceEngineeringTaskId
        {
          get { return Model.PriceEngineeringTaskId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> PriceEngineeringTaskIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(PriceEngineeringTaskId));
        public bool PriceEngineeringTaskIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskId));

        /// <summary>
        /// PriceEngineeringTaskProductBlockAddedId
        /// </summary>
        public System.Nullable<System.Guid> PriceEngineeringTaskProductBlockAddedId
        {
          get { return Model.PriceEngineeringTaskProductBlockAddedId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> PriceEngineeringTaskProductBlockAddedIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(PriceEngineeringTaskProductBlockAddedId));
        public bool PriceEngineeringTaskProductBlockAddedIdIsChanged => GetIsChanged(nameof(PriceEngineeringTaskProductBlockAddedId));

        /// <summary>
        /// Номер оригинального SCC
        /// </summary>
        public System.String OriginalStructureCostNumber
        {
          get { return Model.OriginalStructureCostNumber; }
          set { SetValue(value); }
        }
        public System.String OriginalStructureCostNumberOriginalValue => GetOriginalValue<System.String>(nameof(OriginalStructureCostNumber));
        public bool OriginalStructureCostNumberIsChanged => GetIsChanged(nameof(OriginalStructureCostNumber));

        /// <summary>
        /// Версия стракчакоста
        /// </summary>
        public System.Nullable<System.Int32> Version
        {
          get { return Model.Version; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int32> VersionOriginalValue => GetOriginalValue<System.Nullable<System.Int32>>(nameof(Version));
        public bool VersionIsChanged => GetIsChanged(nameof(Version));

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        public System.Nullable<System.Double> PriceIncreaseFactor
        {
          get { return Model.PriceIncreaseFactor; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> PriceIncreaseFactorOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(PriceIncreaseFactor));
        public bool PriceIncreaseFactorIsChanged => GetIsChanged(nameof(PriceIncreaseFactor));

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
	}

    public class StructureCostVersionEmptyWrapper : WrapperBase<StructureCostVersion>
	{
	    public StructureCostVersionEmptyWrapper(StructureCostVersion model) : base(model) { }
    }

		
    public partial class UpdateStructureCostNumberTaskWrapper : WrapperBase<UpdateStructureCostNumberTask>
	{
	    public UpdateStructureCostNumberTaskWrapper(UpdateStructureCostNumberTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// MomentStart
        /// </summary>
        public System.DateTime MomentStart
        {
          get { return Model.MomentStart; }
          set { SetValue(value); }
        }
        public System.DateTime MomentStartOriginalValue => GetOriginalValue<System.DateTime>(nameof(MomentStart));
        public bool MomentStartIsChanged => GetIsChanged(nameof(MomentStart));

        /// <summary>
        /// MomentFinish
        /// </summary>
        public System.Nullable<System.DateTime> MomentFinish
        {
          get { return Model.MomentFinish; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> MomentFinishOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(MomentFinish));
        public bool MomentFinishIsChanged => GetIsChanged(nameof(MomentFinish));

        /// <summary>
        /// StructureCostNumberOriginal
        /// </summary>
        public System.String StructureCostNumberOriginal
        {
          get { return Model.StructureCostNumberOriginal; }
          set { SetValue(value); }
        }
        public System.String StructureCostNumberOriginalOriginalValue => GetOriginalValue<System.String>(nameof(StructureCostNumberOriginal));
        public bool StructureCostNumberOriginalIsChanged => GetIsChanged(nameof(StructureCostNumberOriginal));

        /// <summary>
        /// StructureCostNumber
        /// </summary>
        public System.String StructureCostNumber
        {
          get { return Model.StructureCostNumber; }
          set { SetValue(value); }
        }
        public System.String StructureCostNumberOriginalValue => GetOriginalValue<System.String>(nameof(StructureCostNumber));
        public bool StructureCostNumberIsChanged => GetIsChanged(nameof(StructureCostNumber));

        /// <summary>
        /// IsAccepted
        /// </summary>
        public System.Nullable<System.Boolean> IsAccepted
        {
          get { return Model.IsAccepted; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Boolean> IsAcceptedOriginalValue => GetOriginalValue<System.Nullable<System.Boolean>>(nameof(IsAccepted));
        public bool IsAcceptedIsChanged => GetIsChanged(nameof(IsAccepted));

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

        #region ComplexProperties

        /// <summary>
        /// Блок
        /// </summary>
	    public ProductBlockWrapper ProductBlock 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(ProductBlock, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductBlockWrapper>(nameof(ProductBlock), Model.ProductBlock == null ? null : new ProductBlockWrapper(Model.ProductBlock));
        }
	}

    public class UpdateStructureCostNumberTaskEmptyWrapper : WrapperBase<UpdateStructureCostNumberTask>
	{
	    public UpdateStructureCostNumberTaskEmptyWrapper(UpdateStructureCostNumberTask model) : base(model) { }
    }

		
    public partial class ProductCategoryWrapper : WrapperBase<ProductCategory>
	{
	    public ProductCategoryWrapper(ProductCategory model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название полное
        /// </summary>
        public System.String NameFull
        {
          get { return Model.NameFull; }
          set { SetValue(value); }
        }
        public System.String NameFullOriginalValue => GetOriginalValue<System.String>(nameof(NameFull));
        public bool NameFullIsChanged => GetIsChanged(nameof(NameFull));

        /// <summary>
        /// Название сокращенное
        /// </summary>
        public System.String NameShort
        {
          get { return Model.NameShort; }
          set { SetValue(value); }
        }
        public System.String NameShortOriginalValue => GetOriginalValue<System.String>(nameof(NameShort));
        public bool NameShortIsChanged => GetIsChanged(nameof(NameShort));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class ProductCategoryEmptyWrapper : WrapperBase<ProductCategory>
	{
	    public ProductCategoryEmptyWrapper(ProductCategory model) : base(model) { }
    }

		
    public partial class ProductCategoryPriceAndCostWrapper : WrapperBase<ProductCategoryPriceAndCost>
	{
	    public ProductCategoryPriceAndCostWrapper(ProductCategoryPriceAndCost model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Стоимость
        /// </summary>
        public System.Double Cost
        {
          get { return Model.Cost; }
          set { SetValue(value); }
        }
        public System.Double CostOriginalValue => GetOriginalValue<System.Double>(nameof(Cost));
        public bool CostIsChanged => GetIsChanged(nameof(Cost));

        /// <summary>
        /// Себестоимость
        /// </summary>
        public System.Double Price
        {
          get { return Model.Price; }
          set { SetValue(value); }
        }
        public System.Double PriceOriginalValue => GetOriginalValue<System.Double>(nameof(Price));
        public bool PriceIsChanged => GetIsChanged(nameof(Price));

        /// <summary>
        /// StructureCost
        /// </summary>
        public System.String StructureCost
        {
          get { return Model.StructureCost; }
          set { SetValue(value); }
        }
        public System.String StructureCostOriginalValue => GetOriginalValue<System.String>(nameof(StructureCost));
        public bool StructureCostIsChanged => GetIsChanged(nameof(StructureCost));

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

        #region ComplexProperties

        /// <summary>
        /// Категория
        /// </summary>
	    public ProductCategoryWrapper Category 
        {
            get { return GetWrapper<ProductCategoryWrapper>(); }
            set { SetComplexValue<ProductCategory, ProductCategoryWrapper>(Category, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductCategoryWrapper>(nameof(Category), Model.Category == null ? null : new ProductCategoryWrapper(Model.Category));
        }
	}

    public class ProductCategoryPriceAndCostEmptyWrapper : WrapperBase<ProductCategoryPriceAndCost>
	{
	    public ProductCategoryPriceAndCostEmptyWrapper(ProductCategoryPriceAndCost model) : base(model) { }
    }

		
    public partial class ProductIncludedWrapper : WrapperBase<ProductIncluded>
	{
	    public ProductIncludedWrapper(ProductIncluded model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// ProductId
        /// </summary>
        public System.Guid ProductId
        {
          get { return Model.ProductId; }
          set { SetValue(value); }
        }
        public System.Guid ProductIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProductId));
        public bool ProductIdIsChanged => GetIsChanged(nameof(ProductId));

        /// <summary>
        /// Количество
        /// </summary>
        public System.Int32 Amount
        {
          get { return Model.Amount; }
          set { SetValue(value); }
        }
        public System.Int32 AmountOriginalValue => GetOriginalValue<System.Int32>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

        /// <summary>
        /// Прайс на единицу
        /// </summary>
        public System.Nullable<System.Double> CustomFixedPrice
        {
          get { return Model.CustomFixedPrice; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> CustomFixedPriceOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(CustomFixedPrice));
        public bool CustomFixedPriceIsChanged => GetIsChanged(nameof(CustomFixedPrice));

        /// <summary>
        /// ParentsCount
        /// </summary>
        public System.Int32 ParentsCount
        {
          get { return Model.ParentsCount; }
          set { SetValue(value); }
        }
        public System.Int32 ParentsCountOriginalValue => GetOriginalValue<System.Int32>(nameof(ParentsCount));
        public bool ParentsCountIsChanged => GetIsChanged(nameof(ParentsCount));

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

        #region ComplexProperties

        /// <summary>
        /// Продукт
        /// </summary>
	    public ProductWrapper Product 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(Product, value); }
        }

        #endregion

        #region GetProperties

        /// <summary>
        /// AmountOnUnit
        /// </summary>
        public System.Double AmountOnUnit => Model.AmountOnUnit; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductWrapper>(nameof(Product), Model.Product == null ? null : new ProductWrapper(Model.Product));
        }
	}

    public class ProductIncludedEmptyWrapper : WrapperBase<ProductIncluded>
	{
	    public ProductIncludedEmptyWrapper(ProductIncluded model) : base(model) { }
    }

		
    public partial class ProductDesignationWrapper : WrapperBase<ProductDesignation>
	{
	    public ProductDesignationWrapper(ProductDesignation model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Обозначение
        /// </summary>
        public System.String Designation
        {
          get { return Model.Designation; }
          set { SetValue(value); }
        }
        public System.String DesignationOriginalValue => GetOriginalValue<System.String>(nameof(Designation));
        public bool DesignationIsChanged => GetIsChanged(nameof(Designation));

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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        /// <summary>
        /// Родители
        /// </summary>
        public IValidatableChangeTrackingCollection<ProductDesignationWrapper> Parents { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
          if (Model.Parents == null) throw new ArgumentException($"{nameof(Model.Parents)} cannot be null");
          Parents = new ValidatableChangeTrackingCollection<ProductDesignationWrapper>(Model.Parents.Select(e => new ProductDesignationWrapper(e)));
          RegisterCollection(Parents, Model.Parents);
        }
	}

    public class ProductDesignationEmptyWrapper : WrapperBase<ProductDesignation>
	{
	    public ProductDesignationEmptyWrapper(ProductDesignation model) : base(model) { }
    }

		
    public partial class ProductTypeWrapper : WrapperBase<ProductType>
	{
	    public ProductTypeWrapper(ProductType model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
	}

    public class ProductTypeEmptyWrapper : WrapperBase<ProductType>
	{
	    public ProductTypeEmptyWrapper(ProductType model) : base(model) { }
    }

		
    public partial class ProductTypeDesignationWrapper : WrapperBase<ProductTypeDesignation>
	{
	    public ProductTypeDesignationWrapper(ProductTypeDesignation model) : base(model) { }

        #region SimpleProperties

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

        #region ComplexProperties

        /// <summary>
        /// Тип
        /// </summary>
	    public ProductTypeWrapper ProductType 
        {
            get { return GetWrapper<ProductTypeWrapper>(); }
            set { SetComplexValue<ProductType, ProductTypeWrapper>(ProductType, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Параметры
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductTypeWrapper>(nameof(ProductType), Model.ProductType == null ? null : new ProductTypeWrapper(Model.ProductType));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class ProductTypeDesignationEmptyWrapper : WrapperBase<ProductTypeDesignation>
	{
	    public ProductTypeDesignationEmptyWrapper(ProductTypeDesignation model) : base(model) { }
    }

		
    public partial class ProjectTypeWrapper : WrapperBase<ProjectType>
	{
	    public ProjectTypeWrapper(ProjectType model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
	}

    public class ProjectTypeEmptyWrapper : WrapperBase<ProjectType>
	{
	    public ProjectTypeEmptyWrapper(ProjectType model) : base(model) { }
    }

		
    public partial class StandartMarginalIncomeWrapper : WrapperBase<StandartMarginalIncome>
	{
	    public StandartMarginalIncomeWrapper(StandartMarginalIncome model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// МД
        /// </summary>
        public System.Double MarginalIncome
        {
          get { return Model.MarginalIncome; }
          set { SetValue(value); }
        }
        public System.Double MarginalIncomeOriginalValue => GetOriginalValue<System.Double>(nameof(MarginalIncome));
        public bool MarginalIncomeIsChanged => GetIsChanged(nameof(MarginalIncome));

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
        /// Параметры оборудования
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class StandartMarginalIncomeEmptyWrapper : WrapperBase<StandartMarginalIncome>
	{
	    public StandartMarginalIncomeEmptyWrapper(StandartMarginalIncome model) : base(model) { }
    }

		
    public partial class StandartProductionTermWrapper : WrapperBase<StandartProductionTerm>
	{
	    public StandartProductionTermWrapper(StandartProductionTerm model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Срок производства
        /// </summary>
        public System.Int32 ProductionTerm
        {
          get { return Model.ProductionTerm; }
          set { SetValue(value); }
        }
        public System.Int32 ProductionTermOriginalValue => GetOriginalValue<System.Int32>(nameof(ProductionTerm));
        public bool ProductionTermIsChanged => GetIsChanged(nameof(ProductionTerm));

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
        /// Параметры оборудования
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
        }
	}

    public class StandartProductionTermEmptyWrapper : WrapperBase<StandartProductionTerm>
	{
	    public StandartProductionTermEmptyWrapper(StandartProductionTerm model) : base(model) { }
    }

		
    public partial class StructureCostWrapper : WrapperBase<StructureCost>
	{
	    public StructureCostWrapper(StructureCost model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// PriceCalculationItemId
        /// </summary>
        public System.Guid PriceCalculationItemId
        {
          get { return Model.PriceCalculationItemId; }
          set { SetValue(value); }
        }
        public System.Guid PriceCalculationItemIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PriceCalculationItemId));
        public bool PriceCalculationItemIdIsChanged => GetIsChanged(nameof(PriceCalculationItemId));

        /// <summary>
        /// Номер
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Номер scc оригинального блока
        /// </summary>
        public System.String OriginalStructureCostNumber
        {
          get { return Model.OriginalStructureCostNumber; }
          set { SetValue(value); }
        }
        public System.String OriginalStructureCostNumberOriginalValue => GetOriginalValue<System.String>(nameof(OriginalStructureCostNumber));
        public bool OriginalStructureCostNumberIsChanged => GetIsChanged(nameof(OriginalStructureCostNumber));

        /// <summary>
        /// Количество (числитель)
        /// </summary>
        public System.Double AmountNumerator
        {
          get { return Model.AmountNumerator; }
          set { SetValue(value); }
        }
        public System.Double AmountNumeratorOriginalValue => GetOriginalValue<System.Double>(nameof(AmountNumerator));
        public bool AmountNumeratorIsChanged => GetIsChanged(nameof(AmountNumerator));

        /// <summary>
        /// Количество (знаменатель)
        /// </summary>
        public System.Double AmountDenomerator
        {
          get { return Model.AmountDenomerator; }
          set { SetValue(value); }
        }
        public System.Double AmountDenomeratorOriginalValue => GetOriginalValue<System.Double>(nameof(AmountDenomerator));
        public bool AmountDenomeratorIsChanged => GetIsChanged(nameof(AmountDenomerator));

        /// <summary>
        /// Себестоимость единицы
        /// </summary>
        public System.Nullable<System.Double> UnitPrice
        {
          get { return Model.UnitPrice; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> UnitPriceOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(UnitPrice));
        public bool UnitPriceIsChanged => GetIsChanged(nameof(UnitPrice));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        public System.Nullable<System.Double> PriceIncreaseFactor
        {
          get { return Model.PriceIncreaseFactor; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> PriceIncreaseFactorOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(PriceIncreaseFactor));
        public bool PriceIncreaseFactorIsChanged => GetIsChanged(nameof(PriceIncreaseFactor));

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

        #region ComplexProperties

        /// <summary>
        /// Оригинальный блок scc
        /// </summary>
	    public ProductBlockWrapper OriginalStructureCostProductBlock 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(OriginalStructureCostProductBlock, value); }
        }

        #endregion

        #region GetProperties

        /// <summary>
        /// Количество на единицу
        /// </summary>
        public System.Double Amount => Model.Amount; 

        /// <summary>
        /// Total
        /// </summary>
        public System.Nullable<System.Double> Total => Model.Total; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductBlockWrapper>(nameof(OriginalStructureCostProductBlock), Model.OriginalStructureCostProductBlock == null ? null : new ProductBlockWrapper(Model.OriginalStructureCostProductBlock));
        }
	}

    public class StructureCostEmptyWrapper : WrapperBase<StructureCost>
	{
	    public StructureCostEmptyWrapper(StructureCost model) : base(model) { }
    }

		
    public partial class SupervisionWrapper : WrapperBase<Supervision>
	{
	    public SupervisionWrapper(Supervision model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата (факт.)
        /// </summary>
        public System.Nullable<System.DateTime> DateFinish
        {
          get { return Model.DateFinish; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DateFinishOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DateFinish));
        public bool DateFinishIsChanged => GetIsChanged(nameof(DateFinish));

        /// <summary>
        /// Дата (треб.)
        /// </summary>
        public System.Nullable<System.DateTime> DateRequired
        {
          get { return Model.DateRequired; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DateRequiredOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DateRequired));
        public bool DateRequiredIsChanged => GetIsChanged(nameof(DateRequired));

        /// <summary>
        /// Заказ клиента
        /// </summary>
        public System.String ClientOrderNumber
        {
          get { return Model.ClientOrderNumber; }
          set { SetValue(value); }
        }
        public System.String ClientOrderNumberOriginalValue => GetOriginalValue<System.String>(nameof(ClientOrderNumber));
        public bool ClientOrderNumberIsChanged => GetIsChanged(nameof(ClientOrderNumber));

        /// <summary>
        /// Сервисный заказ
        /// </summary>
        public System.String ServiceOrderNumber
        {
          get { return Model.ServiceOrderNumber; }
          set { SetValue(value); }
        }
        public System.String ServiceOrderNumberOriginalValue => GetOriginalValue<System.String>(nameof(ServiceOrderNumber));
        public bool ServiceOrderNumberIsChanged => GetIsChanged(nameof(ServiceOrderNumber));

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

        #region ComplexProperties

        /// <summary>
        /// Оборудование
        /// </summary>
	    public SalesUnitWrapper SalesUnit 
        {
            get { return GetWrapper<SalesUnitWrapper>(); }
            set { SetComplexValue<SalesUnit, SalesUnitWrapper>(SalesUnit, value); }
        }

        /// <summary>
        /// Единица шеф-монтажа
        /// </summary>
	    public SalesUnitWrapper SupervisionUnit 
        {
            get { return GetWrapper<SalesUnitWrapper>(); }
            set { SetComplexValue<SalesUnit, SalesUnitWrapper>(SupervisionUnit, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<SalesUnitWrapper>(nameof(SalesUnit), Model.SalesUnit == null ? null : new SalesUnitWrapper(Model.SalesUnit));
            InitializeComplexProperty<SalesUnitWrapper>(nameof(SupervisionUnit), Model.SupervisionUnit == null ? null : new SalesUnitWrapper(Model.SupervisionUnit));
        }
	}

    public class SupervisionEmptyWrapper : WrapperBase<Supervision>
	{
	    public SupervisionEmptyWrapper(Supervision model) : base(model) { }
    }

		
    public partial class TaskInvoiceForPaymentWrapper : WrapperBase<TaskInvoiceForPayment>
	{
	    public TaskInvoiceForPaymentWrapper(TaskInvoiceForPayment model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Старт задачи
        /// </summary>
        public System.Nullable<System.DateTime> MomentStart
        {
          get { return Model.MomentStart; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> MomentStartOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(MomentStart));
        public bool MomentStartIsChanged => GetIsChanged(nameof(MomentStart));

        /// <summary>
        /// Финиш (экономиста)
        /// </summary>
        public System.Nullable<System.DateTime> MomentFinish
        {
          get { return Model.MomentFinish; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> MomentFinishOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(MomentFinish));
        public bool MomentFinishIsChanged => GetIsChanged(nameof(MomentFinish));

        /// <summary>
        /// Финиш (плановика)
        /// </summary>
        public System.Nullable<System.DateTime> MomentFinishByPlanMaker
        {
          get { return Model.MomentFinishByPlanMaker; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> MomentFinishByPlanMakerOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(MomentFinishByPlanMaker));
        public bool MomentFinishByPlanMakerIsChanged => GetIsChanged(nameof(MomentFinishByPlanMaker));

        /// <summary>
        /// Требуется оригинал счёта
        /// </summary>
        public System.Boolean OriginalIsRequired
        {
          get { return Model.OriginalIsRequired; }
          set { SetValue(value); }
        }
        public System.Boolean OriginalIsRequiredOriginalValue => GetOriginalValue<System.Boolean>(nameof(OriginalIsRequired));
        public bool OriginalIsRequiredIsChanged => GetIsChanged(nameof(OriginalIsRequired));

        /// <summary>
        /// Комментарий менеджера
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Экономист
        /// </summary>
	    public UserWrapper BackManager 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(BackManager, value); }
        }

        /// <summary>
        /// Плановик
        /// </summary>
	    public UserWrapper PlanMaker 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(PlanMaker, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Строки счёта
        /// </summary>
        public IValidatableChangeTrackingCollection<TaskInvoiceForPaymentItemWrapper> Items { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// PlanMakerIsRequired
        /// </summary>
        public System.Boolean PlanMakerIsRequired => Model.PlanMakerIsRequired; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(BackManager), Model.BackManager == null ? null : new UserWrapper(Model.BackManager));
            InitializeComplexProperty<UserWrapper>(nameof(PlanMaker), Model.PlanMaker == null ? null : new UserWrapper(Model.PlanMaker));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Items == null) throw new ArgumentException($"{nameof(Model.Items)} cannot be null");
          Items = new ValidatableChangeTrackingCollection<TaskInvoiceForPaymentItemWrapper>(Model.Items.Select(e => new TaskInvoiceForPaymentItemWrapper(e)));
          RegisterCollection(Items, Model.Items);
        }
	}

    public class TaskInvoiceForPaymentEmptyWrapper : WrapperBase<TaskInvoiceForPayment>
	{
	    public TaskInvoiceForPaymentEmptyWrapper(TaskInvoiceForPayment model) : base(model) { }
    }

		
    public partial class TaskInvoiceForPaymentItemWrapper : WrapperBase<TaskInvoiceForPaymentItem>
	{
	    public TaskInvoiceForPaymentItemWrapper(TaskInvoiceForPaymentItem model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// TaskId
        /// </summary>
        public System.Guid TaskId
        {
          get { return Model.TaskId; }
          set { SetValue(value); }
        }
        public System.Guid TaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TaskId));
        public bool TaskIdIsChanged => GetIsChanged(nameof(TaskId));

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

        #region ComplexProperties

        /// <summary>
        /// Задача ТСП
        /// </summary>
	    public PriceEngineeringTaskWrapper PriceEngineeringTask 
        {
            get { return GetWrapper<PriceEngineeringTaskWrapper>(); }
            set { SetComplexValue<PriceEngineeringTask, PriceEngineeringTaskWrapper>(PriceEngineeringTask, value); }
        }

        /// <summary>
        /// Задача ТСЕ
        /// </summary>
	    public TechnicalRequrementsWrapper TechnicalRequrements 
        {
            get { return GetWrapper<TechnicalRequrementsWrapper>(); }
            set { SetComplexValue<TechnicalRequrements, TechnicalRequrementsWrapper>(TechnicalRequrements, value); }
        }

        /// <summary>
        /// Связанное условие платежа
        /// </summary>
	    public PaymentConditionWrapper PaymentCondition 
        {
            get { return GetWrapper<PaymentConditionWrapper>(); }
            set { SetComplexValue<PaymentCondition, PaymentConditionWrapper>(PaymentCondition, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<PriceEngineeringTaskWrapper>(nameof(PriceEngineeringTask), Model.PriceEngineeringTask == null ? null : new PriceEngineeringTaskWrapper(Model.PriceEngineeringTask));
            InitializeComplexProperty<TechnicalRequrementsWrapper>(nameof(TechnicalRequrements), Model.TechnicalRequrements == null ? null : new TechnicalRequrementsWrapper(Model.TechnicalRequrements));
            InitializeComplexProperty<PaymentConditionWrapper>(nameof(PaymentCondition), Model.PaymentCondition == null ? null : new PaymentConditionWrapper(Model.PaymentCondition));
        }
	}

    public class TaskInvoiceForPaymentItemEmptyWrapper : WrapperBase<TaskInvoiceForPaymentItem>
	{
	    public TaskInvoiceForPaymentItemEmptyWrapper(TaskInvoiceForPaymentItem model) : base(model) { }
    }

		
    public partial class AnswerFileTceWrapper : WrapperBase<AnswerFileTce>
	{
	    public AnswerFileTceWrapper(AnswerFileTce model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// TechnicalRequrementsTaskId
        /// </summary>
        public System.Guid TechnicalRequrementsTaskId
        {
          get { return Model.TechnicalRequrementsTaskId; }
          set { SetValue(value); }
        }
        public System.Guid TechnicalRequrementsTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TechnicalRequrementsTaskId));
        public bool TechnicalRequrementsTaskIdIsChanged => GetIsChanged(nameof(TechnicalRequrementsTaskId));

        /// <summary>
        /// Имя
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Актуально
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

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
	}

    public class AnswerFileTceEmptyWrapper : WrapperBase<AnswerFileTce>
	{
	    public AnswerFileTceEmptyWrapper(AnswerFileTce model) : base(model) { }
    }

		
    public partial class ShippingCostFileWrapper : WrapperBase<ShippingCostFile>
	{
	    public ShippingCostFileWrapper(ShippingCostFile model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// TechnicalRequrementsTaskId
        /// </summary>
        public System.Guid TechnicalRequrementsTaskId
        {
          get { return Model.TechnicalRequrementsTaskId; }
          set { SetValue(value); }
        }
        public System.Guid TechnicalRequrementsTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TechnicalRequrementsTaskId));
        public bool TechnicalRequrementsTaskIdIsChanged => GetIsChanged(nameof(TechnicalRequrementsTaskId));

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

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
	}

    public class ShippingCostFileEmptyWrapper : WrapperBase<ShippingCostFile>
	{
	    public ShippingCostFileEmptyWrapper(ShippingCostFile model) : base(model) { }
    }

		
    public partial class TechnicalRequrementsWrapper : WrapperBase<TechnicalRequrements>
	{
	    public TechnicalRequrementsWrapper(TechnicalRequrements model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// TaskId
        /// </summary>
        public System.Guid TaskId
        {
          get { return Model.TaskId; }
          set { SetValue(value); }
        }
        public System.Guid TaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TaskId));
        public bool TaskIdIsChanged => GetIsChanged(nameof(TaskId));

        /// <summary>
        /// ОИТ
        /// </summary>
        public System.Nullable<System.DateTime> OrderInTakeDate
        {
          get { return Model.OrderInTakeDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> OrderInTakeDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(OrderInTakeDate));
        public bool OrderInTakeDateIsChanged => GetIsChanged(nameof(OrderInTakeDate));

        /// <summary>
        /// Дата реализации
        /// </summary>
        public System.Nullable<System.DateTime> RealizationDate
        {
          get { return Model.RealizationDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> RealizationDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(RealizationDate));
        public bool RealizationDateIsChanged => GetIsChanged(nameof(RealizationDate));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Актуально
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

        /// <summary>
        /// Позиция в TeamCenter
        /// </summary>
        public System.Nullable<System.Int32> PositionInTeamCenter
        {
          get { return Model.PositionInTeamCenter; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int32> PositionInTeamCenterOriginalValue => GetOriginalValue<System.Nullable<System.Int32>>(nameof(PositionInTeamCenter));
        public bool PositionInTeamCenterIsChanged => GetIsChanged(nameof(PositionInTeamCenter));

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

        #region ComplexProperties

        /// <summary>
        /// Спецификация
        /// </summary>
	    public SpecificationWrapper Specification 
        {
            get { return GetWrapper<SpecificationWrapper>(); }
            set { SetComplexValue<Specification, SpecificationWrapper>(Specification, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Юниты
        /// </summary>
        public IValidatableChangeTrackingCollection<SalesUnitWrapper> SalesUnits { get; private set; }

        /// <summary>
        /// Файлы
        /// </summary>
        public IValidatableChangeTrackingCollection<TechnicalRequrementsFileWrapper> Files { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<SpecificationWrapper>(nameof(Specification), Model.Specification == null ? null : new SpecificationWrapper(Model.Specification));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.SalesUnits == null) throw new ArgumentException($"{nameof(Model.SalesUnits)} cannot be null");
          SalesUnits = new ValidatableChangeTrackingCollection<SalesUnitWrapper>(Model.SalesUnits.Select(e => new SalesUnitWrapper(e)));
          RegisterCollection(SalesUnits, Model.SalesUnits);
          if (Model.Files == null) throw new ArgumentException($"{nameof(Model.Files)} cannot be null");
          Files = new ValidatableChangeTrackingCollection<TechnicalRequrementsFileWrapper>(Model.Files.Select(e => new TechnicalRequrementsFileWrapper(e)));
          RegisterCollection(Files, Model.Files);
        }
	}

    public class TechnicalRequrementsEmptyWrapper : WrapperBase<TechnicalRequrements>
	{
	    public TechnicalRequrementsEmptyWrapper(TechnicalRequrements model) : base(model) { }
    }

		
    public partial class TechnicalRequrementsFileWrapper : WrapperBase<TechnicalRequrementsFile>
	{
	    public TechnicalRequrementsFileWrapper(TechnicalRequrementsFile model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Имя
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Актуально
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

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
	}

    public class TechnicalRequrementsFileEmptyWrapper : WrapperBase<TechnicalRequrementsFile>
	{
	    public TechnicalRequrementsFileEmptyWrapper(TechnicalRequrementsFile model) : base(model) { }
    }

		
    public partial class TechnicalRequrementsTaskWrapper : WrapperBase<TechnicalRequrementsTask>
	{
	    public TechnicalRequrementsTaskWrapper(TechnicalRequrementsTask model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Номер в ТСЕ
        /// </summary>
        public System.String TceNumber
        {
          get { return Model.TceNumber; }
          set { SetValue(value); }
        }
        public System.String TceNumberOriginalValue => GetOriginalValue<System.String>(nameof(TceNumber));
        public bool TceNumberIsChanged => GetIsChanged(nameof(TceNumber));

        /// <summary>
        /// Последний просмотр back-менеджером
        /// </summary>
        public System.Nullable<System.DateTime> LastOpenBackManagerMoment
        {
          get { return Model.LastOpenBackManagerMoment; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> LastOpenBackManagerMomentOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(LastOpenBackManagerMoment));
        public bool LastOpenBackManagerMomentIsChanged => GetIsChanged(nameof(LastOpenBackManagerMoment));

        /// <summary>
        /// Последний просмотр front-менеджером
        /// </summary>
        public System.Nullable<System.DateTime> LastOpenFrontManagerMoment
        {
          get { return Model.LastOpenFrontManagerMoment; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> LastOpenFrontManagerMomentOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(LastOpenFrontManagerMoment));
        public bool LastOpenFrontManagerMomentIsChanged => GetIsChanged(nameof(LastOpenFrontManagerMoment));

        /// <summary>
        /// Необходимость РТЗ
        /// </summary>
        public System.Boolean LogisticsCalculationRequired
        {
          get { return Model.LogisticsCalculationRequired; }
          set { SetValue(value); }
        }
        public System.Boolean LogisticsCalculationRequiredOriginalValue => GetOriginalValue<System.Boolean>(nameof(LogisticsCalculationRequired));
        public bool LogisticsCalculationRequiredIsChanged => GetIsChanged(nameof(LogisticsCalculationRequired));

        /// <summary>
        /// Необходимость файла-расчета ПЗ
        /// </summary>
        public System.Boolean ExcelFileIsRequired
        {
          get { return Model.ExcelFileIsRequired; }
          set { SetValue(value); }
        }
        public System.Boolean ExcelFileIsRequiredOriginalValue => GetOriginalValue<System.Boolean>(nameof(ExcelFileIsRequired));
        public bool ExcelFileIsRequiredIsChanged => GetIsChanged(nameof(ExcelFileIsRequired));

        /// <summary>
        /// Проработать до
        /// </summary>
        public System.Nullable<System.DateTime> DesiredFinishDate
        {
          get { return Model.DesiredFinishDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DesiredFinishDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DesiredFinishDate));
        public bool DesiredFinishDateIsChanged => GetIsChanged(nameof(DesiredFinishDate));

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

        #region ComplexProperties

        /// <summary>
        /// Back manager
        /// </summary>
	    public UserWrapper BackManager 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(BackManager, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Список требований
        /// </summary>
        public IValidatableChangeTrackingCollection<TechnicalRequrementsWrapper> Requrements { get; private set; }

        /// <summary>
        /// Расчеты себестоимости
        /// </summary>
        public IValidatableChangeTrackingCollection<PriceCalculationWrapper> PriceCalculations { get; private set; }

        /// <summary>
        /// Файлы-ответы ОГК
        /// </summary>
        public IValidatableChangeTrackingCollection<AnswerFileTceWrapper> AnswerFiles { get; private set; }

        /// <summary>
        /// Файлы РТЗ
        /// </summary>
        public IValidatableChangeTrackingCollection<ShippingCostFileWrapper> ShippingCostFiles { get; private set; }

        /// <summary>
        /// История проработки
        /// </summary>
        public IValidatableChangeTrackingCollection<TechnicalRequrementsTaskHistoryElementWrapper> HistoryElements { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Старт
        /// </summary>
        public System.Nullable<System.DateTime> Start => Model.Start; 

        /// <summary>
        /// Финиш
        /// </summary>
        public System.Nullable<System.DateTime> Finish => Model.Finish; 

        /// <summary>
        /// Стартовано?
        /// </summary>
        public System.Boolean IsStarted => Model.IsStarted; 

        /// <summary>
        /// Завершено?
        /// </summary>
        public System.Boolean IsFinished => Model.IsFinished; 

        /// <summary>
        /// Отклонено?
        /// </summary>
        public System.Boolean IsRejected => Model.IsRejected; 

        /// <summary>
        /// Остановлено?
        /// </summary>
        public System.Boolean IsStopped => Model.IsStopped; 

        /// <summary>
        /// Принято?
        /// </summary>
        public System.Boolean IsAccepted => Model.IsAccepted; 

        /// <summary>
        /// Products
        /// </summary>
        public System.String Products => Model.Products; 

        /// <summary>
        /// Front manager
        /// </summary>
        public HVTApp.Model.POCOs.User FrontManager => Model.FrontManager; 

        /// <summary>
        /// Статус тех.задания (задача)
        /// </summary>
        public HVTApp.Model.POCOs.TechnicalRequrementsTaskHistoryElement LastHistoryElement => Model.LastHistoryElement; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(BackManager), Model.BackManager == null ? null : new UserWrapper(Model.BackManager));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Requrements == null) throw new ArgumentException($"{nameof(Model.Requrements)} cannot be null");
          Requrements = new ValidatableChangeTrackingCollection<TechnicalRequrementsWrapper>(Model.Requrements.Select(e => new TechnicalRequrementsWrapper(e)));
          RegisterCollection(Requrements, Model.Requrements);
          if (Model.PriceCalculations == null) throw new ArgumentException($"{nameof(Model.PriceCalculations)} cannot be null");
          PriceCalculations = new ValidatableChangeTrackingCollection<PriceCalculationWrapper>(Model.PriceCalculations.Select(e => new PriceCalculationWrapper(e)));
          RegisterCollection(PriceCalculations, Model.PriceCalculations);
          if (Model.AnswerFiles == null) throw new ArgumentException($"{nameof(Model.AnswerFiles)} cannot be null");
          AnswerFiles = new ValidatableChangeTrackingCollection<AnswerFileTceWrapper>(Model.AnswerFiles.Select(e => new AnswerFileTceWrapper(e)));
          RegisterCollection(AnswerFiles, Model.AnswerFiles);
          if (Model.ShippingCostFiles == null) throw new ArgumentException($"{nameof(Model.ShippingCostFiles)} cannot be null");
          ShippingCostFiles = new ValidatableChangeTrackingCollection<ShippingCostFileWrapper>(Model.ShippingCostFiles.Select(e => new ShippingCostFileWrapper(e)));
          RegisterCollection(ShippingCostFiles, Model.ShippingCostFiles);
          if (Model.HistoryElements == null) throw new ArgumentException($"{nameof(Model.HistoryElements)} cannot be null");
          HistoryElements = new ValidatableChangeTrackingCollection<TechnicalRequrementsTaskHistoryElementWrapper>(Model.HistoryElements.Select(e => new TechnicalRequrementsTaskHistoryElementWrapper(e)));
          RegisterCollection(HistoryElements, Model.HistoryElements);
        }
	}

    public class TechnicalRequrementsTaskEmptyWrapper : WrapperBase<TechnicalRequrementsTask>
	{
	    public TechnicalRequrementsTaskEmptyWrapper(TechnicalRequrementsTask model) : base(model) { }
    }

		
    public partial class TechnicalRequrementsTaskHistoryElementWrapper : WrapperBase<TechnicalRequrementsTaskHistoryElement>
	{
	    public TechnicalRequrementsTaskHistoryElementWrapper(TechnicalRequrementsTaskHistoryElement model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// TechnicalRequrementsTaskId
        /// </summary>
        public System.Guid TechnicalRequrementsTaskId
        {
          get { return Model.TechnicalRequrementsTaskId; }
          set { SetValue(value); }
        }
        public System.Guid TechnicalRequrementsTaskIdOriginalValue => GetOriginalValue<System.Guid>(nameof(TechnicalRequrementsTaskId));
        public bool TechnicalRequrementsTaskIdIsChanged => GetIsChanged(nameof(TechnicalRequrementsTaskId));

        /// <summary>
        /// Момент
        /// </summary>
        public System.DateTime Moment
        {
          get { return Model.Moment; }
          set { SetValue(value); }
        }
        public System.DateTime MomentOriginalValue => GetOriginalValue<System.DateTime>(nameof(Moment));
        public bool MomentIsChanged => GetIsChanged(nameof(Moment));

        /// <summary>
        /// Тип
        /// </summary>
        public HVTApp.Model.POCOs.TechnicalRequrementsTaskHistoryElementType Type
        {
          get { return Model.Type; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.TechnicalRequrementsTaskHistoryElementType TypeOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.TechnicalRequrementsTaskHistoryElementType>(nameof(Type));
        public bool TypeIsChanged => GetIsChanged(nameof(Type));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Автор
        /// </summary>
	    public UserWrapper User 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(User, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<UserWrapper>(nameof(User), Model.User == null ? null : new UserWrapper(Model.User));
        }
	}

    public class TechnicalRequrementsTaskHistoryElementEmptyWrapper : WrapperBase<TechnicalRequrementsTaskHistoryElement>
	{
	    public TechnicalRequrementsTaskHistoryElementEmptyWrapper(TechnicalRequrementsTaskHistoryElement model) : base(model) { }
    }

		
    public partial class UserGroupWrapper : WrapperBase<UserGroup>
	{
	    public UserGroupWrapper(UserGroup model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Имя группы
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
        /// Пользователи
        /// </summary>
        public IValidatableChangeTrackingCollection<UserWrapper> Users { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Users == null) throw new ArgumentException($"{nameof(Model.Users)} cannot be null");
          Users = new ValidatableChangeTrackingCollection<UserWrapper>(Model.Users.Select(e => new UserWrapper(e)));
          RegisterCollection(Users, Model.Users);
        }
	}

    public class UserGroupEmptyWrapper : WrapperBase<UserGroup>
	{
	    public UserGroupEmptyWrapper(UserGroup model) : base(model) { }
    }

		
    public partial class GlobalPropertiesWrapper : WrapperBase<GlobalProperties>
	{
	    public GlobalPropertiesWrapper(GlobalProperties model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата настроек
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Срок актуальности себестоимости
        /// </summary>
        public System.Int32 ActualPriceTerm
        {
          get { return Model.ActualPriceTerm; }
          set { SetValue(value); }
        }
        public System.Int32 ActualPriceTermOriginalValue => GetOriginalValue<System.Int32>(nameof(ActualPriceTerm));
        public bool ActualPriceTermIsChanged => GetIsChanged(nameof(ActualPriceTerm));

        /// <summary>
        /// Стандартный срок производства
        /// </summary>
        public System.Int32 StandartTermFromStartToEndProduction
        {
          get { return Model.StandartTermFromStartToEndProduction; }
          set { SetValue(value); }
        }
        public System.Int32 StandartTermFromStartToEndProductionOriginalValue => GetOriginalValue<System.Int32>(nameof(StandartTermFromStartToEndProduction));
        public bool StandartTermFromStartToEndProductionIsChanged => GetIsChanged(nameof(StandartTermFromStartToEndProduction));

        /// <summary>
        /// Стандартный срок сборки
        /// </summary>
        public System.Int32 StandartTermFromPickToEndProduction
        {
          get { return Model.StandartTermFromPickToEndProduction; }
          set { SetValue(value); }
        }
        public System.Int32 StandartTermFromPickToEndProductionOriginalValue => GetOriginalValue<System.Int32>(nameof(StandartTermFromPickToEndProduction));
        public bool StandartTermFromPickToEndProductionIsChanged => GetIsChanged(nameof(StandartTermFromPickToEndProduction));

        /// <summary>
        /// НДС
        /// </summary>
        public System.Double Vat
        {
          get { return Model.Vat; }
          set { SetValue(value); }
        }
        public System.Double VatOriginalValue => GetOriginalValue<System.Double>(nameof(Vat));
        public bool VatIsChanged => GetIsChanged(nameof(Vat));

        /// <summary>
        /// Путь к папке с запросами
        /// </summary>
        public System.String IncomingRequestsPath
        {
          get { return Model.IncomingRequestsPath; }
          set { SetValue(value); }
        }
        public System.String IncomingRequestsPathOriginalValue => GetOriginalValue<System.String>(nameof(IncomingRequestsPath));
        public bool IncomingRequestsPathIsChanged => GetIsChanged(nameof(IncomingRequestsPath));

        /// <summary>
        /// Путь к папке с приложениями Directum
        /// </summary>
        public System.String DirectumAttachmentsPath
        {
          get { return Model.DirectumAttachmentsPath; }
          set { SetValue(value); }
        }
        public System.String DirectumAttachmentsPathOriginalValue => GetOriginalValue<System.String>(nameof(DirectumAttachmentsPath));
        public bool DirectumAttachmentsPathIsChanged => GetIsChanged(nameof(DirectumAttachmentsPath));

        /// <summary>
        /// Путь к папке с файлами ТЗ
        /// </summary>
        public System.String TechnicalRequrementsFilesPath
        {
          get { return Model.TechnicalRequrementsFilesPath; }
          set { SetValue(value); }
        }
        public System.String TechnicalRequrementsFilesPathOriginalValue => GetOriginalValue<System.String>(nameof(TechnicalRequrementsFilesPath));
        public bool TechnicalRequrementsFilesPathIsChanged => GetIsChanged(nameof(TechnicalRequrementsFilesPath));

        /// <summary>
        /// Путь к папке с файлами ответов из ТСЕ
        /// </summary>
        public System.String TechnicalRequrementsFilesAnswersPath
        {
          get { return Model.TechnicalRequrementsFilesAnswersPath; }
          set { SetValue(value); }
        }
        public System.String TechnicalRequrementsFilesAnswersPathOriginalValue => GetOriginalValue<System.String>(nameof(TechnicalRequrementsFilesAnswersPath));
        public bool TechnicalRequrementsFilesAnswersPathIsChanged => GetIsChanged(nameof(TechnicalRequrementsFilesAnswersPath));

        /// <summary>
        /// Путь к папке с расчетами транспортных затрат
        /// </summary>
        public System.String ShippingCostFilesPath
        {
          get { return Model.ShippingCostFilesPath; }
          set { SetValue(value); }
        }
        public System.String ShippingCostFilesPathOriginalValue => GetOriginalValue<System.String>(nameof(ShippingCostFilesPath));
        public bool ShippingCostFilesPathIsChanged => GetIsChanged(nameof(ShippingCostFilesPath));

        /// <summary>
        /// Путь к папке с расчетами себестоимости
        /// </summary>
        public System.String PriceCalculationsFilesPath
        {
          get { return Model.PriceCalculationsFilesPath; }
          set { SetValue(value); }
        }
        public System.String PriceCalculationsFilesPathOriginalValue => GetOriginalValue<System.String>(nameof(PriceCalculationsFilesPath));
        public bool PriceCalculationsFilesPathIsChanged => GetIsChanged(nameof(PriceCalculationsFilesPath));

        /// <summary>
        /// Путь к папке с логами
        /// </summary>
        public System.String LogsPath
        {
          get { return Model.LogsPath; }
          set { SetValue(value); }
        }
        public System.String LogsPathOriginalValue => GetOriginalValue<System.String>(nameof(LogsPath));
        public bool LogsPathIsChanged => GetIsChanged(nameof(LogsPath));

        /// <summary>
        /// Дата последнего визита разработчика
        /// </summary>
        public System.Nullable<System.DateTime> LastDeveloperVizit
        {
          get { return Model.LastDeveloperVizit; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> LastDeveloperVizitOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(LastDeveloperVizit));
        public bool LastDeveloperVizitIsChanged => GetIsChanged(nameof(LastDeveloperVizit));

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

        #region ComplexProperties

        /// <summary>
        /// Наша компания
        /// </summary>
	    public CompanyWrapper OurCompany 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(OurCompany, value); }
        }

        /// <summary>
        /// Стандартные условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper StandartPaymentsConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(StandartPaymentsConditionSet, value); }
        }

        /// <summary>
        /// Родительский параметр новых параметров
        /// </summary>
	    public ParameterWrapper NewProductParameter 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(NewProductParameter, value); }
        }

        /// <summary>
        /// Группа новых параметров
        /// </summary>
	    public ParameterGroupWrapper NewProductParameterGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(NewProductParameterGroup, value); }
        }

        /// <summary>
        /// Признак услуги
        /// </summary>
	    public ParameterWrapper ServiceParameter 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(ServiceParameter, value); }
        }

        /// <summary>
        /// Признак шеф-монтажа
        /// </summary>
	    public ParameterWrapper SupervisionParameter 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(SupervisionParameter, value); }
        }

        /// <summary>
        /// Группа параметров номинального напряжения
        /// </summary>
	    public ParameterGroupWrapper VoltageGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(VoltageGroup, value); }
        }

        /// <summary>
        /// Группа параметров материала изоляции
        /// </summary>
	    public ParameterGroupWrapper IsolationMaterialGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(IsolationMaterialGroup, value); }
        }

        /// <summary>
        /// Группа параметров цвета изоляции
        /// </summary>
	    public ParameterGroupWrapper IsolationColorGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(IsolationColorGroup, value); }
        }

        /// <summary>
        /// Группа параметров ДПУ изолятора
        /// </summary>
	    public ParameterGroupWrapper IsolationDpuGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(IsolationDpuGroup, value); }
        }

        /// <summary>
        /// Группа параметров обозначения комплекта или детали
        /// </summary>
	    public ParameterGroupWrapper ComplectDesignationGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(ComplectDesignationGroup, value); }
        }

        /// <summary>
        /// Параметр комплекты и детали
        /// </summary>
	    public ParameterWrapper ComplectsParameter 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(ComplectsParameter, value); }
        }

        /// <summary>
        /// Группа типа комплекта или детали
        /// </summary>
	    public ParameterGroupWrapper ComplectsGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(ComplectsGroup, value); }
        }

        /// <summary>
        /// Тип проекта (по умолчанию)
        /// </summary>
	    public ProjectTypeWrapper DefaultProjectType 
        {
            get { return GetWrapper<ProjectTypeWrapper>(); }
            set { SetComplexValue<ProjectType, ProjectTypeWrapper>(DefaultProjectType, value); }
        }

        /// <summary>
        /// Получатель писем по ШМ
        /// </summary>
	    public EmployeeWrapper RecipientSupervisionLetterEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(RecipientSupervisionLetterEmployee, value); }
        }

        /// <summary>
        /// Отправитель ТКП
        /// </summary>
	    public EmployeeWrapper SenderOfferEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(SenderOfferEmployee, value); }
        }

        /// <summary>
        /// Производитель ВВА
        /// </summary>
	    public ActivityFieldWrapper HvtProducersActivityField 
        {
            get { return GetWrapper<ActivityFieldWrapper>(); }
            set { SetComplexValue<ActivityField, ActivityFieldWrapper>(HvtProducersActivityField, value); }
        }

        /// <summary>
        /// Стандартные условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSet, value); }
        }

        /// <summary>
        /// Разработчик
        /// </summary>
	    public UserWrapper Developer 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Developer, value); }
        }

        /// <summary>
        /// Дополнительное оборудование
        /// </summary>
	    public ProductWrapper ProductIncludedDefault 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(ProductIncludedDefault, value); }
        }

        /// <summary>
        /// Параметр пустого блока ТТ
        /// </summary>
	    public ParameterWrapper EmptyParameterCurrentTransformersSet 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(EmptyParameterCurrentTransformersSet, value); }
        }

        /// <summary>
        /// Параметр блока ТТ по заказу
        /// </summary>
	    public ParameterWrapper ParameterCurrentTransformersSetCustom 
        {
            get { return GetWrapper<ParameterWrapper>(); }
            set { SetComplexValue<Parameter, ParameterWrapper>(ParameterCurrentTransformersSetCustom, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<CompanyWrapper>(nameof(OurCompany), Model.OurCompany == null ? null : new CompanyWrapper(Model.OurCompany));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(StandartPaymentsConditionSet), Model.StandartPaymentsConditionSet == null ? null : new PaymentConditionSetWrapper(Model.StandartPaymentsConditionSet));
            InitializeComplexProperty<ParameterWrapper>(nameof(NewProductParameter), Model.NewProductParameter == null ? null : new ParameterWrapper(Model.NewProductParameter));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(NewProductParameterGroup), Model.NewProductParameterGroup == null ? null : new ParameterGroupWrapper(Model.NewProductParameterGroup));
            InitializeComplexProperty<ParameterWrapper>(nameof(ServiceParameter), Model.ServiceParameter == null ? null : new ParameterWrapper(Model.ServiceParameter));
            InitializeComplexProperty<ParameterWrapper>(nameof(SupervisionParameter), Model.SupervisionParameter == null ? null : new ParameterWrapper(Model.SupervisionParameter));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(VoltageGroup), Model.VoltageGroup == null ? null : new ParameterGroupWrapper(Model.VoltageGroup));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(IsolationMaterialGroup), Model.IsolationMaterialGroup == null ? null : new ParameterGroupWrapper(Model.IsolationMaterialGroup));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(IsolationColorGroup), Model.IsolationColorGroup == null ? null : new ParameterGroupWrapper(Model.IsolationColorGroup));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(IsolationDpuGroup), Model.IsolationDpuGroup == null ? null : new ParameterGroupWrapper(Model.IsolationDpuGroup));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(ComplectDesignationGroup), Model.ComplectDesignationGroup == null ? null : new ParameterGroupWrapper(Model.ComplectDesignationGroup));
            InitializeComplexProperty<ParameterWrapper>(nameof(ComplectsParameter), Model.ComplectsParameter == null ? null : new ParameterWrapper(Model.ComplectsParameter));
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(ComplectsGroup), Model.ComplectsGroup == null ? null : new ParameterGroupWrapper(Model.ComplectsGroup));
            InitializeComplexProperty<ProjectTypeWrapper>(nameof(DefaultProjectType), Model.DefaultProjectType == null ? null : new ProjectTypeWrapper(Model.DefaultProjectType));
            InitializeComplexProperty<EmployeeWrapper>(nameof(RecipientSupervisionLetterEmployee), Model.RecipientSupervisionLetterEmployee == null ? null : new EmployeeWrapper(Model.RecipientSupervisionLetterEmployee));
            InitializeComplexProperty<EmployeeWrapper>(nameof(SenderOfferEmployee), Model.SenderOfferEmployee == null ? null : new EmployeeWrapper(Model.SenderOfferEmployee));
            InitializeComplexProperty<ActivityFieldWrapper>(nameof(HvtProducersActivityField), Model.HvtProducersActivityField == null ? null : new ActivityFieldWrapper(Model.HvtProducersActivityField));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSet));
            InitializeComplexProperty<UserWrapper>(nameof(Developer), Model.Developer == null ? null : new UserWrapper(Model.Developer));
            InitializeComplexProperty<ProductWrapper>(nameof(ProductIncludedDefault), Model.ProductIncludedDefault == null ? null : new ProductWrapper(Model.ProductIncludedDefault));
            InitializeComplexProperty<ParameterWrapper>(nameof(EmptyParameterCurrentTransformersSet), Model.EmptyParameterCurrentTransformersSet == null ? null : new ParameterWrapper(Model.EmptyParameterCurrentTransformersSet));
            InitializeComplexProperty<ParameterWrapper>(nameof(ParameterCurrentTransformersSetCustom), Model.ParameterCurrentTransformersSetCustom == null ? null : new ParameterWrapper(Model.ParameterCurrentTransformersSetCustom));
        }
	}

    public class GlobalPropertiesEmptyWrapper : WrapperBase<GlobalProperties>
	{
	    public GlobalPropertiesEmptyWrapper(GlobalProperties model) : base(model) { }
    }

		
    public partial class AddressWrapper : WrapperBase<Address>
	{
	    public AddressWrapper(Address model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Описание
        /// </summary>
        public System.String Description
        {
          get { return Model.Description; }
          set { SetValue(value); }
        }
        public System.String DescriptionOriginalValue => GetOriginalValue<System.String>(nameof(Description));
        public bool DescriptionIsChanged => GetIsChanged(nameof(Description));

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

        #region ComplexProperties

        /// <summary>
        /// Населенный пункт
        /// </summary>
	    public LocalityWrapper Locality 
        {
            get { return GetWrapper<LocalityWrapper>(); }
            set { SetComplexValue<Locality, LocalityWrapper>(Locality, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<LocalityWrapper>(nameof(Locality), Model.Locality == null ? null : new LocalityWrapper(Model.Locality));
        }
	}

    public class AddressEmptyWrapper : WrapperBase<Address>
	{
	    public AddressEmptyWrapper(Address model) : base(model) { }
    }

		
    public partial class CountryWrapper : WrapperBase<Country>
	{
	    public CountryWrapper(Country model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
	}

    public class CountryEmptyWrapper : WrapperBase<Country>
	{
	    public CountryEmptyWrapper(Country model) : base(model) { }
    }

		
    public partial class DistrictWrapper : WrapperBase<District>
	{
	    public DistrictWrapper(District model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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

        #region ComplexProperties

        /// <summary>
        /// Страна
        /// </summary>
	    public CountryWrapper Country 
        {
            get { return GetWrapper<CountryWrapper>(); }
            set { SetComplexValue<Country, CountryWrapper>(Country, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<CountryWrapper>(nameof(Country), Model.Country == null ? null : new CountryWrapper(Model.Country));
        }
	}

    public class DistrictEmptyWrapper : WrapperBase<District>
	{
	    public DistrictEmptyWrapper(District model) : base(model) { }
    }

		
    public partial class LocalityWrapper : WrapperBase<Locality>
	{
	    public LocalityWrapper(Locality model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Столица страны
        /// </summary>
        public System.Boolean IsCountryCapital
        {
          get { return Model.IsCountryCapital; }
          set { SetValue(value); }
        }
        public System.Boolean IsCountryCapitalOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsCountryCapital));
        public bool IsCountryCapitalIsChanged => GetIsChanged(nameof(IsCountryCapital));

        /// <summary>
        /// Столица округа
        /// </summary>
        public System.Boolean IsDistrictCapital
        {
          get { return Model.IsDistrictCapital; }
          set { SetValue(value); }
        }
        public System.Boolean IsDistrictCapitalOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsDistrictCapital));
        public bool IsDistrictCapitalIsChanged => GetIsChanged(nameof(IsDistrictCapital));

        /// <summary>
        /// Столица региона
        /// </summary>
        public System.Boolean IsRegionCapital
        {
          get { return Model.IsRegionCapital; }
          set { SetValue(value); }
        }
        public System.Boolean IsRegionCapitalOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsRegionCapital));
        public bool IsRegionCapitalIsChanged => GetIsChanged(nameof(IsRegionCapital));

        /// <summary>
        /// Расстояние до Екатеринбурга, км
        /// </summary>
        public System.Nullable<System.Double> DistanceToEkb
        {
          get { return Model.DistanceToEkb; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> DistanceToEkbOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(DistanceToEkb));
        public bool DistanceToEkbIsChanged => GetIsChanged(nameof(DistanceToEkb));

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

        #region ComplexProperties

        /// <summary>
        /// Тип
        /// </summary>
	    public LocalityTypeWrapper LocalityType 
        {
            get { return GetWrapper<LocalityTypeWrapper>(); }
            set { SetComplexValue<LocalityType, LocalityTypeWrapper>(LocalityType, value); }
        }

        /// <summary>
        /// Регион
        /// </summary>
	    public RegionWrapper Region 
        {
            get { return GetWrapper<RegionWrapper>(); }
            set { SetComplexValue<Region, RegionWrapper>(Region, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<LocalityTypeWrapper>(nameof(LocalityType), Model.LocalityType == null ? null : new LocalityTypeWrapper(Model.LocalityType));
            InitializeComplexProperty<RegionWrapper>(nameof(Region), Model.Region == null ? null : new RegionWrapper(Model.Region));
        }
	}

    public class LocalityEmptyWrapper : WrapperBase<Locality>
	{
	    public LocalityEmptyWrapper(Locality model) : base(model) { }
    }

		
    public partial class LocalityTypeWrapper : WrapperBase<LocalityType>
	{
	    public LocalityTypeWrapper(LocalityType model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Полное название
        /// </summary>
        public System.String FullName
        {
          get { return Model.FullName; }
          set { SetValue(value); }
        }
        public System.String FullNameOriginalValue => GetOriginalValue<System.String>(nameof(FullName));
        public bool FullNameIsChanged => GetIsChanged(nameof(FullName));

        /// <summary>
        /// Сокращенное
        /// </summary>
        public System.String ShortName
        {
          get { return Model.ShortName; }
          set { SetValue(value); }
        }
        public System.String ShortNameOriginalValue => GetOriginalValue<System.String>(nameof(ShortName));
        public bool ShortNameIsChanged => GetIsChanged(nameof(ShortName));

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
	}

    public class LocalityTypeEmptyWrapper : WrapperBase<LocalityType>
	{
	    public LocalityTypeEmptyWrapper(LocalityType model) : base(model) { }
    }

		
    public partial class RegionWrapper : WrapperBase<Region>
	{
	    public RegionWrapper(Region model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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

        #region ComplexProperties

        /// <summary>
        /// Округ
        /// </summary>
	    public DistrictWrapper District 
        {
            get { return GetWrapper<DistrictWrapper>(); }
            set { SetComplexValue<District, DistrictWrapper>(District, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<DistrictWrapper>(nameof(District), Model.District == null ? null : new DistrictWrapper(Model.District));
        }
	}

    public class RegionEmptyWrapper : WrapperBase<Region>
	{
	    public RegionEmptyWrapper(Region model) : base(model) { }
    }

		
    public partial class SumWrapper : WrapperBase<Sum>
	{
	    public SumWrapper(Sum model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Type
        /// </summary>
        public HVTApp.Model.POCOs.SumType Type
        {
          get { return Model.Type; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.SumType TypeOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.SumType>(nameof(Type));
        public bool TypeIsChanged => GetIsChanged(nameof(Type));

        /// <summary>
        /// Currency
        /// </summary>
        public HVTApp.Model.POCOs.Currency Currency
        {
          get { return Model.Currency; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.Currency CurrencyOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.Currency>(nameof(Currency));
        public bool CurrencyIsChanged => GetIsChanged(nameof(Currency));

        /// <summary>
        /// Value
        /// </summary>
        public System.Decimal Value
        {
          get { return Model.Value; }
          set { SetValue(value); }
        }
        public System.Decimal ValueOriginalValue => GetOriginalValue<System.Decimal>(nameof(Value));
        public bool ValueIsChanged => GetIsChanged(nameof(Value));

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
	}

    public class SumEmptyWrapper : WrapperBase<Sum>
	{
	    public SumEmptyWrapper(Sum model) : base(model) { }
    }

		
    public partial class CurrencyExchangeRateWrapper : WrapperBase<CurrencyExchangeRate>
	{
	    public CurrencyExchangeRateWrapper(CurrencyExchangeRate model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Валюта 1
        /// </summary>
        public HVTApp.Model.POCOs.Currency FirstCurrency
        {
          get { return Model.FirstCurrency; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.Currency FirstCurrencyOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.Currency>(nameof(FirstCurrency));
        public bool FirstCurrencyIsChanged => GetIsChanged(nameof(FirstCurrency));

        /// <summary>
        /// Валюта 2
        /// </summary>
        public HVTApp.Model.POCOs.Currency SecondCurrency
        {
          get { return Model.SecondCurrency; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.Currency SecondCurrencyOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.Currency>(nameof(SecondCurrency));
        public bool SecondCurrencyIsChanged => GetIsChanged(nameof(SecondCurrency));

        /// <summary>
        /// Валюта 1 / Валюта 2
        /// </summary>
        public System.Double ExchangeRate
        {
          get { return Model.ExchangeRate; }
          set { SetValue(value); }
        }
        public System.Double ExchangeRateOriginalValue => GetOriginalValue<System.Double>(nameof(ExchangeRate));
        public bool ExchangeRateIsChanged => GetIsChanged(nameof(ExchangeRate));

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
	}

    public class CurrencyExchangeRateEmptyWrapper : WrapperBase<CurrencyExchangeRate>
	{
	    public CurrencyExchangeRateEmptyWrapper(CurrencyExchangeRate model) : base(model) { }
    }

		
    public partial class NoteWrapper : WrapperBase<Note>
	{
	    public NoteWrapper(Note model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// ProjectId
        /// </summary>
        public System.Guid ProjectId
        {
          get { return Model.ProjectId; }
          set { SetValue(value); }
        }
        public System.Guid ProjectIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProjectId));
        public bool ProjectIdIsChanged => GetIsChanged(nameof(ProjectId));

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Текст
        /// </summary>
        public System.String Text
        {
          get { return Model.Text; }
          set { SetValue(value); }
        }
        public System.String TextOriginalValue => GetOriginalValue<System.String>(nameof(Text));
        public bool TextIsChanged => GetIsChanged(nameof(Text));

        /// <summary>
        /// Важно?
        /// </summary>
        public System.Boolean IsImportant
        {
          get { return Model.IsImportant; }
          set { SetValue(value); }
        }
        public System.Boolean IsImportantOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsImportant));
        public bool IsImportantIsChanged => GetIsChanged(nameof(IsImportant));

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
	}

    public class NoteEmptyWrapper : WrapperBase<Note>
	{
	    public NoteEmptyWrapper(Note model) : base(model) { }
    }

		
    public partial class OfferUnitWrapper : WrapperBase<OfferUnit>
	{
	    public OfferUnitWrapper(OfferUnit model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Стоимость
        /// </summary>
        public System.Double Cost
        {
          get { return Model.Cost; }
          set { SetValue(value); }
        }
        public System.Double CostOriginalValue => GetOriginalValue<System.Double>(nameof(Cost));
        public bool CostIsChanged => GetIsChanged(nameof(Cost));

        /// <summary>
        /// Стоимость доставки
        /// </summary>
        public System.Nullable<System.Double> CostDelivery
        {
          get { return Model.CostDelivery; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> CostDeliveryOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(CostDelivery));
        public bool CostDeliveryIsChanged => GetIsChanged(nameof(CostDelivery));

        /// <summary>
        /// Стоимость доставки включена в основную стоимость
        /// </summary>
        public System.Boolean CostDeliveryIncluded
        {
          get { return Model.CostDeliveryIncluded; }
          set { SetValue(value); }
        }
        public System.Boolean CostDeliveryIncludedOriginalValue => GetOriginalValue<System.Boolean>(nameof(CostDeliveryIncluded));
        public bool CostDeliveryIncludedIsChanged => GetIsChanged(nameof(CostDeliveryIncluded));

        /// <summary>
        /// ProductId
        /// </summary>
        public System.Guid ProductId
        {
          get { return Model.ProductId; }
          set { SetValue(value); }
        }
        public System.Guid ProductIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProductId));
        public bool ProductIdIsChanged => GetIsChanged(nameof(ProductId));

        /// <summary>
        /// Срок производства
        /// </summary>
        public System.Int32 ProductionTerm
        {
          get { return Model.ProductionTerm; }
          set { SetValue(value); }
        }
        public System.Int32 ProductionTermOriginalValue => GetOriginalValue<System.Int32>(nameof(ProductionTerm));
        public bool ProductionTermIsChanged => GetIsChanged(nameof(ProductionTerm));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// ТКП
        /// </summary>
	    public OfferWrapper Offer 
        {
            get { return GetWrapper<OfferWrapper>(); }
            set { SetComplexValue<Offer, OfferWrapper>(Offer, value); }
        }

        /// <summary>
        /// Объект
        /// </summary>
	    public FacilityWrapper Facility 
        {
            get { return GetWrapper<FacilityWrapper>(); }
            set { SetComplexValue<Facility, FacilityWrapper>(Facility, value); }
        }

        /// <summary>
        /// Продукт
        /// </summary>
	    public ProductWrapper Product 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(Product, value); }
        }

        /// <summary>
        /// Условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSet, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Включенные продукты
        /// </summary>
        public IValidatableChangeTrackingCollection<ProductIncludedWrapper> ProductsIncluded { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<OfferWrapper>(nameof(Offer), Model.Offer == null ? null : new OfferWrapper(Model.Offer));
            InitializeComplexProperty<FacilityWrapper>(nameof(Facility), Model.Facility == null ? null : new FacilityWrapper(Model.Facility));
            InitializeComplexProperty<ProductWrapper>(nameof(Product), Model.Product == null ? null : new ProductWrapper(Model.Product));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSet));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.ProductsIncluded == null) throw new ArgumentException($"{nameof(Model.ProductsIncluded)} cannot be null");
          ProductsIncluded = new ValidatableChangeTrackingCollection<ProductIncludedWrapper>(Model.ProductsIncluded.Select(e => new ProductIncludedWrapper(e)));
          RegisterCollection(ProductsIncluded, Model.ProductsIncluded);
        }
	}

    public class OfferUnitEmptyWrapper : WrapperBase<OfferUnit>
	{
	    public OfferUnitEmptyWrapper(OfferUnit model) : base(model) { }
    }

		
    public partial class PaymentConditionSetWrapper : WrapperBase<PaymentConditionSet>
	{
	    public PaymentConditionSetWrapper(PaymentConditionSet model) : base(model) { }

        #region SimpleProperties

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
        /// Список условий
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentConditionWrapper> PaymentConditions { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.PaymentConditions == null) throw new ArgumentException($"{nameof(Model.PaymentConditions)} cannot be null");
          PaymentConditions = new ValidatableChangeTrackingCollection<PaymentConditionWrapper>(Model.PaymentConditions.Select(e => new PaymentConditionWrapper(e)));
          RegisterCollection(PaymentConditions, Model.PaymentConditions);
        }
	}

    public class PaymentConditionSetEmptyWrapper : WrapperBase<PaymentConditionSet>
	{
	    public PaymentConditionSetEmptyWrapper(PaymentConditionSet model) : base(model) { }
    }

		
    public partial class ProductBlockWrapper : WrapperBase<ProductBlock>
	{
	    public ProductBlockWrapper(ProductBlock model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Специальное обозначение
        /// </summary>
        public System.String DesignationSpecial
        {
          get { return Model.DesignationSpecial; }
          set { SetValue(value); }
        }
        public System.String DesignationSpecialOriginalValue => GetOriginalValue<System.String>(nameof(DesignationSpecial));
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
        public IValidatableChangeTrackingCollection<ParameterWrapper> Parameters { get; private set; }

        /// <summary>
        /// Себестоимости
        /// </summary>
        public IValidatableChangeTrackingCollection<SumOnDateWrapper> Prices { get; private set; }

        /// <summary>
        /// Фиксированные цены
        /// </summary>
        public IValidatableChangeTrackingCollection<SumOnDateWrapper> FixedCosts { get; private set; }

        /// <summary>
        /// Параметры (упорядоченные)
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> ParametersOrdered { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Обозначение
        /// </summary>
        public System.String Designation => Model.Designation; 

        /// <summary>
        /// Есть прайс
        /// </summary>
        public System.Boolean HasPrice => Model.HasPrice; 

        /// <summary>
        /// Дата последнего прайса
        /// </summary>
        public System.Nullable<System.DateTime> LastPriceDate => Model.LastPriceDate; 

        /// <summary>
        /// Есть фиксированный прайс
        /// </summary>
        public System.Boolean HasFixedPrice => Model.HasFixedPrice; 

        /// <summary>
        /// Новый
        /// </summary>
        public System.Boolean IsNew => Model.IsNew; 

        /// <summary>
        /// Услуга
        /// </summary>
        public System.Boolean IsService => Model.IsService; 

        /// <summary>
        /// Шеф-монтаж
        /// </summary>
        public System.Boolean IsSupervision => Model.IsSupervision; 

        /// <summary>
        /// Комплект
        /// </summary>
        public System.Boolean IsKit => Model.IsKit; 

        /// <summary>
        /// Тип
        /// </summary>
        public HVTApp.Model.POCOs.ProductType ProductType => Model.ProductType; 

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Parameters == null) throw new ArgumentException($"{nameof(Model.Parameters)} cannot be null");
          Parameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.Parameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(Parameters, Model.Parameters);
          if (Model.Prices == null) throw new ArgumentException($"{nameof(Model.Prices)} cannot be null");
          Prices = new ValidatableChangeTrackingCollection<SumOnDateWrapper>(Model.Prices.Select(e => new SumOnDateWrapper(e)));
          RegisterCollection(Prices, Model.Prices);
          if (Model.FixedCosts == null) throw new ArgumentException($"{nameof(Model.FixedCosts)} cannot be null");
          FixedCosts = new ValidatableChangeTrackingCollection<SumOnDateWrapper>(Model.FixedCosts.Select(e => new SumOnDateWrapper(e)));
          RegisterCollection(FixedCosts, Model.FixedCosts);
          if (Model.ParametersOrdered == null) throw new ArgumentException($"{nameof(Model.ParametersOrdered)} cannot be null");
          ParametersOrdered = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.ParametersOrdered.Select(e => new ParameterWrapper(e)));
          RegisterCollection(ParametersOrdered, Model.ParametersOrdered);
        }
	}

    public class ProductBlockEmptyWrapper : WrapperBase<ProductBlock>
	{
	    public ProductBlockEmptyWrapper(ProductBlock model) : base(model) { }
    }

		
    public partial class ProductDependentWrapper : WrapperBase<ProductDependent>
	{
	    public ProductDependentWrapper(ProductDependent model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// MainProductId
        /// </summary>
        public System.Guid MainProductId
        {
          get { return Model.MainProductId; }
          set { SetValue(value); }
        }
        public System.Guid MainProductIdOriginalValue => GetOriginalValue<System.Guid>(nameof(MainProductId));
        public bool MainProductIdIsChanged => GetIsChanged(nameof(MainProductId));

        /// <summary>
        /// Количество
        /// </summary>
        public System.Int32 Amount
        {
          get { return Model.Amount; }
          set { SetValue(value); }
        }
        public System.Int32 AmountOriginalValue => GetOriginalValue<System.Int32>(nameof(Amount));
        public bool AmountIsChanged => GetIsChanged(nameof(Amount));

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

        #region ComplexProperties

        /// <summary>
        /// Продукт
        /// </summary>
	    public ProductWrapper Product 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(Product, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductWrapper>(nameof(Product), Model.Product == null ? null : new ProductWrapper(Model.Product));
        }
	}

    public class ProductDependentEmptyWrapper : WrapperBase<ProductDependent>
	{
	    public ProductDependentEmptyWrapper(ProductDependent model) : base(model) { }
    }

		
    public partial class BankDetailsWrapper : WrapperBase<BankDetails>
	{
	    public BankDetailsWrapper(BankDetails model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Банк
        /// </summary>
        public System.String BankName
        {
          get { return Model.BankName; }
          set { SetValue(value); }
        }
        public System.String BankNameOriginalValue => GetOriginalValue<System.String>(nameof(BankName));
        public bool BankNameIsChanged => GetIsChanged(nameof(BankName));

        /// <summary>
        /// БИК
        /// </summary>
        public System.String BankIdentificationCode
        {
          get { return Model.BankIdentificationCode; }
          set { SetValue(value); }
        }
        public System.String BankIdentificationCodeOriginalValue => GetOriginalValue<System.String>(nameof(BankIdentificationCode));
        public bool BankIdentificationCodeIsChanged => GetIsChanged(nameof(BankIdentificationCode));

        /// <summary>
        /// Кор.счет
        /// </summary>
        public System.String CorrespondentAccount
        {
          get { return Model.CorrespondentAccount; }
          set { SetValue(value); }
        }
        public System.String CorrespondentAccountOriginalValue => GetOriginalValue<System.String>(nameof(CorrespondentAccount));
        public bool CorrespondentAccountIsChanged => GetIsChanged(nameof(CorrespondentAccount));

        /// <summary>
        /// Расч.счет
        /// </summary>
        public System.String CheckingAccount
        {
          get { return Model.CheckingAccount; }
          set { SetValue(value); }
        }
        public System.String CheckingAccountOriginalValue => GetOriginalValue<System.String>(nameof(CheckingAccount));
        public bool CheckingAccountIsChanged => GetIsChanged(nameof(CheckingAccount));

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
	}

    public class BankDetailsEmptyWrapper : WrapperBase<BankDetails>
	{
	    public BankDetailsEmptyWrapper(BankDetails model) : base(model) { }
    }

		
    public partial class CompanyWrapper : WrapperBase<Company>
	{
	    public CompanyWrapper(Company model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Наименование
        /// </summary>
        public System.String FullName
        {
          get { return Model.FullName; }
          set { SetValue(value); }
        }
        public System.String FullNameOriginalValue => GetOriginalValue<System.String>(nameof(FullName));
        public bool FullNameIsChanged => GetIsChanged(nameof(FullName));

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public System.String ShortName
        {
          get { return Model.ShortName; }
          set { SetValue(value); }
        }
        public System.String ShortNameOriginalValue => GetOriginalValue<System.String>(nameof(ShortName));
        public bool ShortNameIsChanged => GetIsChanged(nameof(ShortName));

        /// <summary>
        /// email
        /// </summary>
        public System.String Email
        {
          get { return Model.Email; }
          set { SetValue(value); }
        }
        public System.String EmailOriginalValue => GetOriginalValue<System.String>(nameof(Email));
        public bool EmailIsChanged => GetIsChanged(nameof(Email));

        /// <summary>
        /// ИНН
        /// </summary>
        public System.String Inn
        {
          get { return Model.Inn; }
          set { SetValue(value); }
        }
        public System.String InnOriginalValue => GetOriginalValue<System.String>(nameof(Inn));
        public bool InnIsChanged => GetIsChanged(nameof(Inn));

        /// <summary>
        /// КПП
        /// </summary>
        public System.String Kpp
        {
          get { return Model.Kpp; }
          set { SetValue(value); }
        }
        public System.String KppOriginalValue => GetOriginalValue<System.String>(nameof(Kpp));
        public bool KppIsChanged => GetIsChanged(nameof(Kpp));

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

        #region ComplexProperties

        /// <summary>
        /// Организационная форма
        /// </summary>
	    public CompanyFormWrapper Form 
        {
            get { return GetWrapper<CompanyFormWrapper>(); }
            set { SetComplexValue<CompanyForm, CompanyFormWrapper>(Form, value); }
        }

        /// <summary>
        /// Родительская компания
        /// </summary>
	    public CompanyWrapper ParentCompany 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(ParentCompany, value); }
        }

        /// <summary>
        /// Юридический адрес
        /// </summary>
	    public AddressWrapper AddressLegal 
        {
            get { return GetWrapper<AddressWrapper>(); }
            set { SetComplexValue<Address, AddressWrapper>(AddressLegal, value); }
        }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
	    public AddressWrapper AddressPost 
        {
            get { return GetWrapper<AddressWrapper>(); }
            set { SetComplexValue<Address, AddressWrapper>(AddressPost, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Банковские реквизиты
        /// </summary>
        public IValidatableChangeTrackingCollection<BankDetailsWrapper> BankDetailsList { get; private set; }

        /// <summary>
        /// Сферы деятельности
        /// </summary>
        public IValidatableChangeTrackingCollection<ActivityFieldWrapper> ActivityFilds { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<CompanyFormWrapper>(nameof(Form), Model.Form == null ? null : new CompanyFormWrapper(Model.Form));
            InitializeComplexProperty<CompanyWrapper>(nameof(ParentCompany), Model.ParentCompany == null ? null : new CompanyWrapper(Model.ParentCompany));
            InitializeComplexProperty<AddressWrapper>(nameof(AddressLegal), Model.AddressLegal == null ? null : new AddressWrapper(Model.AddressLegal));
            InitializeComplexProperty<AddressWrapper>(nameof(AddressPost), Model.AddressPost == null ? null : new AddressWrapper(Model.AddressPost));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.BankDetailsList == null) throw new ArgumentException($"{nameof(Model.BankDetailsList)} cannot be null");
          BankDetailsList = new ValidatableChangeTrackingCollection<BankDetailsWrapper>(Model.BankDetailsList.Select(e => new BankDetailsWrapper(e)));
          RegisterCollection(BankDetailsList, Model.BankDetailsList);
          if (Model.ActivityFilds == null) throw new ArgumentException($"{nameof(Model.ActivityFilds)} cannot be null");
          ActivityFilds = new ValidatableChangeTrackingCollection<ActivityFieldWrapper>(Model.ActivityFilds.Select(e => new ActivityFieldWrapper(e)));
          RegisterCollection(ActivityFilds, Model.ActivityFilds);
        }
	}

    public class CompanyEmptyWrapper : WrapperBase<Company>
	{
	    public CompanyEmptyWrapper(Company model) : base(model) { }
    }

		
    public partial class CompanyFormWrapper : WrapperBase<CompanyForm>
	{
	    public CompanyFormWrapper(CompanyForm model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Полное наименование
        /// </summary>
        public System.String FullName
        {
          get { return Model.FullName; }
          set { SetValue(value); }
        }
        public System.String FullNameOriginalValue => GetOriginalValue<System.String>(nameof(FullName));
        public bool FullNameIsChanged => GetIsChanged(nameof(FullName));

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public System.String ShortName
        {
          get { return Model.ShortName; }
          set { SetValue(value); }
        }
        public System.String ShortNameOriginalValue => GetOriginalValue<System.String>(nameof(ShortName));
        public bool ShortNameIsChanged => GetIsChanged(nameof(ShortName));

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
	}

    public class CompanyFormEmptyWrapper : WrapperBase<CompanyForm>
	{
	    public CompanyFormEmptyWrapper(CompanyForm model) : base(model) { }
    }

		
    public partial class DocumentsRegistrationDetailsWrapper : WrapperBase<DocumentsRegistrationDetails>
	{
	    public DocumentsRegistrationDetailsWrapper(DocumentsRegistrationDetails model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Номер
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

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
	}

    public class DocumentsRegistrationDetailsEmptyWrapper : WrapperBase<DocumentsRegistrationDetails>
	{
	    public DocumentsRegistrationDetailsEmptyWrapper(DocumentsRegistrationDetails model) : base(model) { }
    }

		
    public partial class EmployeesPositionWrapper : WrapperBase<EmployeesPosition>
	{
	    public EmployeesPositionWrapper(EmployeesPosition model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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
	}

    public class EmployeesPositionEmptyWrapper : WrapperBase<EmployeesPosition>
	{
	    public EmployeesPositionEmptyWrapper(EmployeesPosition model) : base(model) { }
    }

		
    public partial class FacilityTypeWrapper : WrapperBase<FacilityType>
	{
	    public FacilityTypeWrapper(FacilityType model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Наименование
        /// </summary>
        public System.String FullName
        {
          get { return Model.FullName; }
          set { SetValue(value); }
        }
        public System.String FullNameOriginalValue => GetOriginalValue<System.String>(nameof(FullName));
        public bool FullNameIsChanged => GetIsChanged(nameof(FullName));

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public System.String ShortName
        {
          get { return Model.ShortName; }
          set { SetValue(value); }
        }
        public System.String ShortNameOriginalValue => GetOriginalValue<System.String>(nameof(ShortName));
        public bool ShortNameIsChanged => GetIsChanged(nameof(ShortName));

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
	}

    public class FacilityTypeEmptyWrapper : WrapperBase<FacilityType>
	{
	    public FacilityTypeEmptyWrapper(FacilityType model) : base(model) { }
    }

		
    public partial class ActivityFieldWrapper : WrapperBase<ActivityField>
	{
	    public ActivityFieldWrapper(ActivityField model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// ActivityFieldEnum
        /// </summary>
        public HVTApp.Model.POCOs.ActivityFieldEnum ActivityFieldEnum
        {
          get { return Model.ActivityFieldEnum; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.ActivityFieldEnum ActivityFieldEnumOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.ActivityFieldEnum>(nameof(ActivityFieldEnum));
        public bool ActivityFieldEnumIsChanged => GetIsChanged(nameof(ActivityFieldEnum));

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
	}

    public class ActivityFieldEmptyWrapper : WrapperBase<ActivityField>
	{
	    public ActivityFieldEmptyWrapper(ActivityField model) : base(model) { }
    }

		
    public partial class ContractWrapper : WrapperBase<Contract>
	{
	    public ContractWrapper(Contract model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// №
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

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

        #region ComplexProperties

        /// <summary>
        /// Контрагент
        /// </summary>
	    public CompanyWrapper Contragent 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(Contragent, value); }
        }

        /// <summary>
        /// Подписант
        /// </summary>
	    public EmployeeWrapper ContragentEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(ContragentEmployee, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<CompanyWrapper>(nameof(Contragent), Model.Contragent == null ? null : new CompanyWrapper(Model.Contragent));
            InitializeComplexProperty<EmployeeWrapper>(nameof(ContragentEmployee), Model.ContragentEmployee == null ? null : new EmployeeWrapper(Model.ContragentEmployee));
        }
	}

    public class ContractEmptyWrapper : WrapperBase<Contract>
	{
	    public ContractEmptyWrapper(Contract model) : base(model) { }
    }

		
    public partial class MeasureWrapper : WrapperBase<Measure>
	{
	    public MeasureWrapper(Measure model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Наименование
        /// </summary>
        public System.String FullName
        {
          get { return Model.FullName; }
          set { SetValue(value); }
        }
        public System.String FullNameOriginalValue => GetOriginalValue<System.String>(nameof(FullName));
        public bool FullNameIsChanged => GetIsChanged(nameof(FullName));

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public System.String ShortName
        {
          get { return Model.ShortName; }
          set { SetValue(value); }
        }
        public System.String ShortNameOriginalValue => GetOriginalValue<System.String>(nameof(ShortName));
        public bool ShortNameIsChanged => GetIsChanged(nameof(ShortName));

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
	}

    public class MeasureEmptyWrapper : WrapperBase<Measure>
	{
	    public MeasureEmptyWrapper(Measure model) : base(model) { }
    }

		
    public partial class ParameterWrapper : WrapperBase<Parameter>
	{
	    public ParameterWrapper(Parameter model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Значение
        /// </summary>
        public System.String Value
        {
          get { return Model.Value; }
          set { SetValue(value); }
        }
        public System.String ValueOriginalValue => GetOriginalValue<System.String>(nameof(Value));
        public bool ValueIsChanged => GetIsChanged(nameof(Value));

        /// <summary>
        /// Ранг
        /// </summary>
        public System.Int32 Rang
        {
          get { return Model.Rang; }
          set { SetValue(value); }
        }
        public System.Int32 RangOriginalValue => GetOriginalValue<System.Int32>(nameof(Rang));
        public bool RangIsChanged => GetIsChanged(nameof(Rang));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Группа
        /// </summary>
	    public ParameterGroupWrapper ParameterGroup 
        {
            get { return GetWrapper<ParameterGroupWrapper>(); }
            set { SetComplexValue<ParameterGroup, ParameterGroupWrapper>(ParameterGroup, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Ограничения
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterRelationWrapper> ParameterRelations { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Начало?
        /// </summary>
        public System.Boolean IsOrigin => Model.IsOrigin; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ParameterGroupWrapper>(nameof(ParameterGroup), Model.ParameterGroup == null ? null : new ParameterGroupWrapper(Model.ParameterGroup));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.ParameterRelations == null) throw new ArgumentException($"{nameof(Model.ParameterRelations)} cannot be null");
          ParameterRelations = new ValidatableChangeTrackingCollection<ParameterRelationWrapper>(Model.ParameterRelations.Select(e => new ParameterRelationWrapper(e)));
          RegisterCollection(ParameterRelations, Model.ParameterRelations);
        }
	}

    public class ParameterEmptyWrapper : WrapperBase<Parameter>
	{
	    public ParameterEmptyWrapper(Parameter model) : base(model) { }
    }

		
    public partial class ParameterGroupWrapper : WrapperBase<ParameterGroup>
	{
	    public ParameterGroupWrapper(ParameterGroup model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Сила
        /// </summary>
        public System.Int32 Powerful
        {
          get { return Model.Powerful; }
          set { SetValue(value); }
        }
        public System.Int32 PowerfulOriginalValue => GetOriginalValue<System.Int32>(nameof(Powerful));
        public bool PowerfulIsChanged => GetIsChanged(nameof(Powerful));

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

        #region ComplexProperties

        /// <summary>
        /// Единица измерения
        /// </summary>
	    public MeasureWrapper Measure 
        {
            get { return GetWrapper<MeasureWrapper>(); }
            set { SetComplexValue<Measure, MeasureWrapper>(Measure, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<MeasureWrapper>(nameof(Measure), Model.Measure == null ? null : new MeasureWrapper(Model.Measure));
        }
	}

    public class ParameterGroupEmptyWrapper : WrapperBase<ParameterGroup>
	{
	    public ParameterGroupEmptyWrapper(ParameterGroup model) : base(model) { }
    }

		
    public partial class ProductRelationWrapper : WrapperBase<ProductRelation>
	{
	    public ProductRelationWrapper(ProductRelation model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Имя
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Количество дочерних продуктов
        /// </summary>
        public System.Int32 ChildProductsAmount
        {
          get { return Model.ChildProductsAmount; }
          set { SetValue(value); }
        }
        public System.Int32 ChildProductsAmountOriginalValue => GetOriginalValue<System.Int32>(nameof(ChildProductsAmount));
        public bool ChildProductsAmountIsChanged => GetIsChanged(nameof(ChildProductsAmount));

        /// <summary>
        /// Уникальность
        /// </summary>
        public System.Boolean IsUnique
        {
          get { return Model.IsUnique; }
          set { SetValue(value); }
        }
        public System.Boolean IsUniqueOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsUnique));
        public bool IsUniqueIsChanged => GetIsChanged(nameof(IsUnique));

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
        /// Родительские параметры
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> ParentProductParameters { get; private set; }

        /// <summary>
        /// Дочерние параметры
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> ChildProductParameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.ParentProductParameters == null) throw new ArgumentException($"{nameof(Model.ParentProductParameters)} cannot be null");
          ParentProductParameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.ParentProductParameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(ParentProductParameters, Model.ParentProductParameters);
          if (Model.ChildProductParameters == null) throw new ArgumentException($"{nameof(Model.ChildProductParameters)} cannot be null");
          ChildProductParameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.ChildProductParameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(ChildProductParameters, Model.ChildProductParameters);
        }
	}

    public class ProductRelationEmptyWrapper : WrapperBase<ProductRelation>
	{
	    public ProductRelationEmptyWrapper(ProductRelation model) : base(model) { }
    }

		
    public partial class PersonWrapper : WrapperBase<Person>
	{
	    public PersonWrapper(Person model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Фамилия
        /// </summary>
        public System.String Surname
        {
          get { return Model.Surname; }
          set { SetValue(value); }
        }
        public System.String SurnameOriginalValue => GetOriginalValue<System.String>(nameof(Surname));
        public bool SurnameIsChanged => GetIsChanged(nameof(Surname));

        /// <summary>
        /// Имя
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Отчество
        /// </summary>
        public System.String Patronymic
        {
          get { return Model.Patronymic; }
          set { SetValue(value); }
        }
        public System.String PatronymicOriginalValue => GetOriginalValue<System.String>(nameof(Patronymic));
        public bool PatronymicIsChanged => GetIsChanged(nameof(Patronymic));

        /// <summary>
        /// Мужского пола
        /// </summary>
        public System.Boolean IsMan
        {
          get { return Model.IsMan; }
          set { SetValue(value); }
        }
        public System.Boolean IsManOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsMan));
        public bool IsManIsChanged => GetIsChanged(nameof(IsMan));

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
	}

    public class PersonEmptyWrapper : WrapperBase<Person>
	{
	    public PersonEmptyWrapper(Person model) : base(model) { }
    }

		
    public partial class ParameterRelationWrapper : WrapperBase<ParameterRelation>
	{
	    public ParameterRelationWrapper(ParameterRelation model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Id связанного параметра
        /// </summary>
        public System.Guid ParameterId
        {
          get { return Model.ParameterId; }
          set { SetValue(value); }
        }
        public System.Guid ParameterIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ParameterId));
        public bool ParameterIdIsChanged => GetIsChanged(nameof(ParameterId));

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
        /// Обязательные параметры перед
        /// </summary>
        public IValidatableChangeTrackingCollection<ParameterWrapper> RequiredParameters { get; private set; }

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.RequiredParameters == null) throw new ArgumentException($"{nameof(Model.RequiredParameters)} cannot be null");
          RequiredParameters = new ValidatableChangeTrackingCollection<ParameterWrapper>(Model.RequiredParameters.Select(e => new ParameterWrapper(e)));
          RegisterCollection(RequiredParameters, Model.RequiredParameters);
        }
	}

    public class ParameterRelationEmptyWrapper : WrapperBase<ParameterRelation>
	{
	    public ParameterRelationEmptyWrapper(ParameterRelation model) : base(model) { }
    }

		
    public partial class SalesUnitWrapper : WrapperBase<SalesUnit>
	{
	    public SalesUnitWrapper(SalesUnit model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// FacilityId
        /// </summary>
        public System.Guid FacilityId
        {
          get { return Model.FacilityId; }
          set { SetValue(value); }
        }
        public System.Guid FacilityIdOriginalValue => GetOriginalValue<System.Guid>(nameof(FacilityId));
        public bool FacilityIdIsChanged => GetIsChanged(nameof(FacilityId));

        /// <summary>
        /// ProductId
        /// </summary>
        public System.Guid ProductId
        {
          get { return Model.ProductId; }
          set { SetValue(value); }
        }
        public System.Guid ProductIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProductId));
        public bool ProductIdIsChanged => GetIsChanged(nameof(ProductId));

        /// <summary>
        /// Стоимость
        /// </summary>
        public System.Double Cost
        {
          get { return Model.Cost; }
          set { SetValue(value); }
        }
        public System.Double CostOriginalValue => GetOriginalValue<System.Double>(nameof(Cost));
        public bool CostIsChanged => GetIsChanged(nameof(Cost));

        /// <summary>
        /// Стоимость для формирования бюджета
        /// </summary>
        public System.Nullable<System.Double> CostWithReserve
        {
          get { return Model.CostWithReserve; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> CostWithReserveOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(CostWithReserve));
        public bool CostWithReserveIsChanged => GetIsChanged(nameof(CostWithReserve));

        /// <summary>
        /// Себестоимость
        /// </summary>
        public System.Nullable<System.Double> Price
        {
          get { return Model.Price; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> PriceOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(Price));
        public bool PriceIsChanged => GetIsChanged(nameof(Price));

        /// <summary>
        /// Нормо-часы
        /// </summary>
        public System.Nullable<System.Double> LaborHours
        {
          get { return Model.LaborHours; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> LaborHoursOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(LaborHours));
        public bool LaborHoursIsChanged => GetIsChanged(nameof(LaborHours));

        /// <summary>
        /// PaymentConditionSetId
        /// </summary>
        public System.Guid PaymentConditionSetId
        {
          get { return Model.PaymentConditionSetId; }
          set { SetValue(value); }
        }
        public System.Guid PaymentConditionSetIdOriginalValue => GetOriginalValue<System.Guid>(nameof(PaymentConditionSetId));
        public bool PaymentConditionSetIdIsChanged => GetIsChanged(nameof(PaymentConditionSetId));

        /// <summary>
        /// Срок производства
        /// </summary>
        public System.Int32 ProductionTerm
        {
          get { return Model.ProductionTerm; }
          set { SetValue(value); }
        }
        public System.Int32 ProductionTermOriginalValue => GetOriginalValue<System.Int32>(nameof(ProductionTerm));
        public bool ProductionTermIsChanged => GetIsChanged(nameof(ProductionTerm));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// ProjectId
        /// </summary>
        public System.Guid ProjectId
        {
          get { return Model.ProjectId; }
          set { SetValue(value); }
        }
        public System.Guid ProjectIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProjectId));
        public bool ProjectIdIsChanged => GetIsChanged(nameof(ProjectId));

        /// <summary>
        /// Требуемая дата поставки
        /// </summary>
        public System.DateTime DeliveryDateExpected
        {
          get { return Model.DeliveryDateExpected; }
          set { SetValue(value); }
        }
        public System.DateTime DeliveryDateExpectedOriginalValue => GetOriginalValue<System.DateTime>(nameof(DeliveryDateExpected));
        public bool DeliveryDateExpectedIsChanged => GetIsChanged(nameof(DeliveryDateExpected));

        /// <summary>
        /// Дата реализации
        /// </summary>
        public System.Nullable<System.DateTime> RealizationDate
        {
          get { return Model.RealizationDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> RealizationDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(RealizationDate));
        public bool RealizationDateIsChanged => GetIsChanged(nameof(RealizationDate));

        /// <summary>
        /// Позиция
        /// </summary>
        public System.String OrderPosition
        {
          get { return Model.OrderPosition; }
          set { SetValue(value); }
        }
        public System.String OrderPositionOriginalValue => GetOriginalValue<System.String>(nameof(OrderPosition));
        public bool OrderPositionIsChanged => GetIsChanged(nameof(OrderPosition));

        /// <summary>
        /// Номер
        /// </summary>
        public System.String SerialNumber
        {
          get { return Model.SerialNumber; }
          set { SetValue(value); }
        }
        public System.String SerialNumberOriginalValue => GetOriginalValue<System.String>(nameof(SerialNumber));
        public bool SerialNumberIsChanged => GetIsChanged(nameof(SerialNumber));

        /// <summary>
        /// Срок сборки
        /// </summary>
        public System.Nullable<System.Int32> AssembleTerm
        {
          get { return Model.AssembleTerm; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int32> AssembleTermOriginalValue => GetOriginalValue<System.Nullable<System.Int32>>(nameof(AssembleTerm));
        public bool AssembleTermIsChanged => GetIsChanged(nameof(AssembleTerm));

        /// <summary>
        /// Сигнал менеджера о производстве
        /// </summary>
        public System.Nullable<System.DateTime> SignalToStartProduction
        {
          get { return Model.SignalToStartProduction; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> SignalToStartProductionOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(SignalToStartProduction));
        public bool SignalToStartProductionIsChanged => GetIsChanged(nameof(SignalToStartProduction));

        /// <summary>
        /// Дата размещения в производстве
        /// </summary>
        public System.Nullable<System.DateTime> SignalToStartProductionDone
        {
          get { return Model.SignalToStartProductionDone; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> SignalToStartProductionDoneOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(SignalToStartProductionDone));
        public bool SignalToStartProductionDoneIsChanged => GetIsChanged(nameof(SignalToStartProductionDone));

        /// <summary>
        /// Дата начала производства
        /// </summary>
        public System.Nullable<System.DateTime> StartProductionDate
        {
          get { return Model.StartProductionDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> StartProductionDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(StartProductionDate));
        public bool StartProductionDateIsChanged => GetIsChanged(nameof(StartProductionDate));

        /// <summary>
        /// Дата комплектации
        /// </summary>
        public System.Nullable<System.DateTime> PickingDate
        {
          get { return Model.PickingDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> PickingDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(PickingDate));
        public bool PickingDateIsChanged => GetIsChanged(nameof(PickingDate));

        /// <summary>
        /// Плановая дата окончания производства
        /// </summary>
        public System.Nullable<System.DateTime> EndProductionPlanDate
        {
          get { return Model.EndProductionPlanDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> EndProductionPlanDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(EndProductionPlanDate));
        public bool EndProductionPlanDateIsChanged => GetIsChanged(nameof(EndProductionPlanDate));

        /// <summary>
        /// Дата окончания производства
        /// </summary>
        public System.Nullable<System.DateTime> EndProductionDate
        {
          get { return Model.EndProductionDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> EndProductionDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(EndProductionDate));
        public bool EndProductionDateIsChanged => GetIsChanged(nameof(EndProductionDate));

        /// <summary>
        /// Стоимость доставки
        /// </summary>
        public System.Nullable<System.Double> CostDelivery
        {
          get { return Model.CostDelivery; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Double> CostDeliveryOriginalValue => GetOriginalValue<System.Nullable<System.Double>>(nameof(CostDelivery));
        public bool CostDeliveryIsChanged => GetIsChanged(nameof(CostDelivery));

        /// <summary>
        /// Стоимость доставки включена в основную стоимость
        /// </summary>
        public System.Boolean CostDeliveryIncluded
        {
          get { return Model.CostDeliveryIncluded; }
          set { SetValue(value); }
        }
        public System.Boolean CostDeliveryIncludedOriginalValue => GetOriginalValue<System.Boolean>(nameof(CostDeliveryIncluded));
        public bool CostDeliveryIncludedIsChanged => GetIsChanged(nameof(CostDeliveryIncluded));

        /// <summary>
        /// Срок доставки
        /// </summary>
        public System.Nullable<System.Int32> ExpectedDeliveryPeriod
        {
          get { return Model.ExpectedDeliveryPeriod; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Int32> ExpectedDeliveryPeriodOriginalValue => GetOriginalValue<System.Nullable<System.Int32>>(nameof(ExpectedDeliveryPeriod));
        public bool ExpectedDeliveryPeriodIsChanged => GetIsChanged(nameof(ExpectedDeliveryPeriod));

        /// <summary>
        /// Дата отгрузки
        /// </summary>
        public System.Nullable<System.DateTime> ShipmentDate
        {
          get { return Model.ShipmentDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> ShipmentDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(ShipmentDate));
        public bool ShipmentDateIsChanged => GetIsChanged(nameof(ShipmentDate));

        /// <summary>
        /// Дата отгрузки (плановая)
        /// </summary>
        public System.Nullable<System.DateTime> ShipmentPlanDate
        {
          get { return Model.ShipmentPlanDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> ShipmentPlanDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(ShipmentPlanDate));
        public bool ShipmentPlanDateIsChanged => GetIsChanged(nameof(ShipmentPlanDate));

        /// <summary>
        /// Дата поставки
        /// </summary>
        public System.Nullable<System.DateTime> DeliveryDate
        {
          get { return Model.DeliveryDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DeliveryDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DeliveryDate));
        public bool DeliveryDateIsChanged => GetIsChanged(nameof(DeliveryDate));

        /// <summary>
        /// Удален
        /// </summary>
        public System.Boolean IsRemoved
        {
          get { return Model.IsRemoved; }
          set { SetValue(value); }
        }
        public System.Boolean IsRemovedOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsRemoved));
        public bool IsRemovedIsChanged => GetIsChanged(nameof(IsRemoved));

        /// <summary>
        /// Дата первого платежа по заказу
        /// </summary>
        public System.Nullable<System.DateTime> FirstPaymentDate
        {
          get { return Model.FirstPaymentDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> FirstPaymentDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(FirstPaymentDate));
        public bool FirstPaymentDateIsChanged => GetIsChanged(nameof(FirstPaymentDate));

        /// <summary>
        /// Оплачено
        /// </summary>
        public System.Double PaidSum
        {
          get { return Model.PaidSum; }
          set { SetValue(value); }
        }
        public System.Double PaidSumOriginalValue => GetOriginalValue<System.Double>(nameof(PaidSum));
        public bool PaidSumIsChanged => GetIsChanged(nameof(PaidSum));

        /// <summary>
        /// OrderInTakeDateInjected
        /// </summary>
        public System.Nullable<System.DateTime> OrderInTakeDateInjected
        {
          get { return Model.OrderInTakeDateInjected; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> OrderInTakeDateInjectedOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(OrderInTakeDateInjected));
        public bool OrderInTakeDateInjectedIsChanged => GetIsChanged(nameof(OrderInTakeDateInjected));

        /// <summary>
        /// StartProductionDateInjected
        /// </summary>
        public System.Nullable<System.DateTime> StartProductionDateInjected
        {
          get { return Model.StartProductionDateInjected; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> StartProductionDateInjectedOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(StartProductionDateInjected));
        public bool StartProductionDateInjectedIsChanged => GetIsChanged(nameof(StartProductionDateInjected));

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

        #region ComplexProperties

        /// <summary>
        /// Объект
        /// </summary>
	    public FacilityWrapper Facility 
        {
            get { return GetWrapper<FacilityWrapper>(); }
            set { SetComplexValue<Facility, FacilityWrapper>(Facility, value); }
        }

        /// <summary>
        /// Продукт
        /// </summary>
	    public ProductWrapper Product 
        {
            get { return GetWrapper<ProductWrapper>(); }
            set { SetComplexValue<Product, ProductWrapper>(Product, value); }
        }

        /// <summary>
        /// Условия оплаты
        /// </summary>
	    public PaymentConditionSetWrapper PaymentConditionSet 
        {
            get { return GetWrapper<PaymentConditionSetWrapper>(); }
            set { SetComplexValue<PaymentConditionSet, PaymentConditionSetWrapper>(PaymentConditionSet, value); }
        }

        /// <summary>
        /// Проект
        /// </summary>
	    public ProjectWrapper Project 
        {
            get { return GetWrapper<ProjectWrapper>(); }
            set { SetComplexValue<Project, ProjectWrapper>(Project, value); }
        }

        /// <summary>
        /// Производитель
        /// </summary>
	    public CompanyWrapper Producer 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(Producer, value); }
        }

        /// <summary>
        /// Заказ
        /// </summary>
	    public OrderWrapper Order 
        {
            get { return GetWrapper<OrderWrapper>(); }
            set { SetComplexValue<Order, OrderWrapper>(Order, value); }
        }

        /// <summary>
        /// Спецификация
        /// </summary>
	    public SpecificationWrapper Specification 
        {
            get { return GetWrapper<SpecificationWrapper>(); }
            set { SetComplexValue<Specification, SpecificationWrapper>(Specification, value); }
        }

        /// <summary>
        /// Штрафные санкции
        /// </summary>
	    public PenaltyWrapper Penalty 
        {
            get { return GetWrapper<PenaltyWrapper>(); }
            set { SetComplexValue<Penalty, PenaltyWrapper>(Penalty, value); }
        }

        /// <summary>
        /// Адрес доставки
        /// </summary>
	    public AddressWrapper AddressDelivery 
        {
            get { return GetWrapper<AddressWrapper>(); }
            set { SetComplexValue<Address, AddressWrapper>(AddressDelivery, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Включенные продукты
        /// </summary>
        public IValidatableChangeTrackingCollection<ProductIncludedWrapper> ProductsIncluded { get; private set; }

        /// <summary>
        /// Причины проигрыша
        /// </summary>
        public IValidatableChangeTrackingCollection<LosingReasonWrapper> LosingReasons { get; private set; }

        /// <summary>
        /// Совершённые платежи
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentActualWrapper> PaymentsActual { get; private set; }

        /// <summary>
        /// Планируемые платежи
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentPlannedWrapper> PaymentsPlanned { get; private set; }

        /// <summary>
        /// PaymentsPlannedActual
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentPlannedWrapper> PaymentsPlannedActual { get; private set; }

        /// <summary>
        /// Расчетные плановые платежи
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentPlannedWrapper> PaymentsPlannedGenerated { get; private set; }

        /// <summary>
        /// Расчетные плановые платежи + сохраненные
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentPlannedWrapper> PaymentsPlannedCalculated { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Срок доставки расчетный
        /// </summary>
        public System.Nullable<System.Int32> ExpectedDeliveryPeriodCalculated => Model.ExpectedDeliveryPeriodCalculated; 

        /// <summary>
        /// Разрешение на редактирование стоимости
        /// </summary>
        public System.Boolean AllowEditCost => Model.AllowEditCost; 

        /// <summary>
        /// Разрешение на редактирование техники
        /// </summary>
        public System.Boolean AllowEditProduct => Model.AllowEditProduct; 

        /// <summary>
        /// Проиграно
        /// </summary>
        public System.Boolean IsLoosen => Model.IsLoosen; 

        /// <summary>
        /// Выиграно
        /// </summary>
        public System.Boolean IsWon => Model.IsWon; 

        /// <summary>
        /// Исполнено
        /// </summary>
        public System.Boolean IsDone => Model.IsDone; 

        /// <summary>
        /// Id актуального расчета калькуляции
        /// </summary>
        public System.Guid ActualPriceCalculationItemId => Model.ActualPriceCalculationItemId; 

        /// <summary>
        /// Заказ взят
        /// </summary>
        public System.Boolean OrderIsTaken => Model.OrderIsTaken; 

        /// <summary>
        /// Заказ реализован
        /// </summary>
        public System.Boolean OrderIsRealized => Model.OrderIsRealized; 

        /// <summary>
        /// Разрешено тотальное удаление
        /// </summary>
        public System.Boolean AllowTotalRemove => Model.AllowTotalRemove; 

        /// <summary>
        /// Оплачено?
        /// </summary>
        public System.Boolean IsPaid => Model.IsPaid; 

        /// <summary>
        /// Неоплачено без НДС
        /// </summary>
        public System.Double SumNotPaid => Model.SumNotPaid; 

        /// <summary>
        /// НДС
        /// </summary>
        public System.Double Vat => Model.Vat; 

        /// <summary>
        /// Неоплачено с НДС
        /// </summary>
        public System.Double SumNotPaidWithVat => Model.SumNotPaidWithVat; 

        /// <summary>
        /// Сумма старта производства
        /// </summary>
        public System.Double SumToStartProduction => Model.SumToStartProduction; 

        /// <summary>
        /// Сумма отгрузки
        /// </summary>
        public System.Double SumToShipping => Model.SumToShipping; 

        /// <summary>
        /// ОИТ
        /// </summary>
        public System.DateTime OrderInTakeDate => Model.OrderInTakeDate; 

        /// <summary>
        /// Год ОИТ
        /// </summary>
        public System.Int32 OrderInTakeYear => Model.OrderInTakeYear; 

        /// <summary>
        /// Месяц ОИТ
        /// </summary>
        public System.Int32 OrderInTakeMonth => Model.OrderInTakeMonth; 

        /// <summary>
        /// Дата исполнения условий для начала производства
        /// </summary>
        public System.Nullable<System.DateTime> StartProductionConditionsDoneDate => Model.StartProductionConditionsDoneDate; 

        /// <summary>
        /// Дата исполнения условий для отгрузки
        /// </summary>
        public System.Nullable<System.DateTime> ShippingConditionsDoneDate => Model.ShippingConditionsDoneDate; 

        /// <summary>
        /// Начало производства (расч.)
        /// </summary>
        public System.DateTime StartProductionDateCalculated => Model.StartProductionDateCalculated; 

        /// <summary>
        /// Окончание производства (расч.)
        /// </summary>
        public System.DateTime EndProductionDateCalculated => Model.EndProductionDateCalculated; 

        /// <summary>
        /// Окончание производства по договору
        /// </summary>
        public System.DateTime EndProductionDateByContractCalculated => Model.EndProductionDateByContractCalculated; 

        /// <summary>
        /// Расчетная дата реализации
        /// </summary>
        public System.DateTime RealizationDateCalculated => Model.RealizationDateCalculated; 

        /// <summary>
        /// Расчетная дата отгрузки
        /// </summary>
        public System.DateTime ShipmentDateCalculated => Model.ShipmentDateCalculated; 

        /// <summary>
        /// Расчетная дата доставки
        /// </summary>
        public System.DateTime DeliveryDateCalculated => Model.DeliveryDateCalculated; 

        /// <summary>
        /// Расчетный срок доставки
        /// </summary>
        public System.Double DeliveryPeriodCalculated => Model.DeliveryPeriodCalculated; 

        /// <summary>
        /// Адрес доставки (расчетный)
        /// </summary>
        public HVTApp.Model.POCOs.Address AddressDeliveryCalculated => Model.AddressDeliveryCalculated; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<FacilityWrapper>(nameof(Facility), Model.Facility == null ? null : new FacilityWrapper(Model.Facility));
            InitializeComplexProperty<ProductWrapper>(nameof(Product), Model.Product == null ? null : new ProductWrapper(Model.Product));
            InitializeComplexProperty<PaymentConditionSetWrapper>(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetWrapper(Model.PaymentConditionSet));
            InitializeComplexProperty<ProjectWrapper>(nameof(Project), Model.Project == null ? null : new ProjectWrapper(Model.Project));
            InitializeComplexProperty<CompanyWrapper>(nameof(Producer), Model.Producer == null ? null : new CompanyWrapper(Model.Producer));
            InitializeComplexProperty<OrderWrapper>(nameof(Order), Model.Order == null ? null : new OrderWrapper(Model.Order));
            InitializeComplexProperty<SpecificationWrapper>(nameof(Specification), Model.Specification == null ? null : new SpecificationWrapper(Model.Specification));
            InitializeComplexProperty<PenaltyWrapper>(nameof(Penalty), Model.Penalty == null ? null : new PenaltyWrapper(Model.Penalty));
            InitializeComplexProperty<AddressWrapper>(nameof(AddressDelivery), Model.AddressDelivery == null ? null : new AddressWrapper(Model.AddressDelivery));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.ProductsIncluded == null) throw new ArgumentException($"{nameof(Model.ProductsIncluded)} cannot be null");
          ProductsIncluded = new ValidatableChangeTrackingCollection<ProductIncludedWrapper>(Model.ProductsIncluded.Select(e => new ProductIncludedWrapper(e)));
          RegisterCollection(ProductsIncluded, Model.ProductsIncluded);
          if (Model.LosingReasons == null) throw new ArgumentException($"{nameof(Model.LosingReasons)} cannot be null");
          LosingReasons = new ValidatableChangeTrackingCollection<LosingReasonWrapper>(Model.LosingReasons.Select(e => new LosingReasonWrapper(e)));
          RegisterCollection(LosingReasons, Model.LosingReasons);
          if (Model.PaymentsActual == null) throw new ArgumentException($"{nameof(Model.PaymentsActual)} cannot be null");
          PaymentsActual = new ValidatableChangeTrackingCollection<PaymentActualWrapper>(Model.PaymentsActual.Select(e => new PaymentActualWrapper(e)));
          RegisterCollection(PaymentsActual, Model.PaymentsActual);
          if (Model.PaymentsPlanned == null) throw new ArgumentException($"{nameof(Model.PaymentsPlanned)} cannot be null");
          PaymentsPlanned = new ValidatableChangeTrackingCollection<PaymentPlannedWrapper>(Model.PaymentsPlanned.Select(e => new PaymentPlannedWrapper(e)));
          RegisterCollection(PaymentsPlanned, Model.PaymentsPlanned);
          if (Model.PaymentsPlannedActual == null) throw new ArgumentException($"{nameof(Model.PaymentsPlannedActual)} cannot be null");
          PaymentsPlannedActual = new ValidatableChangeTrackingCollection<PaymentPlannedWrapper>(Model.PaymentsPlannedActual.Select(e => new PaymentPlannedWrapper(e)));
          RegisterCollection(PaymentsPlannedActual, Model.PaymentsPlannedActual);
          if (Model.PaymentsPlannedGenerated == null) throw new ArgumentException($"{nameof(Model.PaymentsPlannedGenerated)} cannot be null");
          PaymentsPlannedGenerated = new ValidatableChangeTrackingCollection<PaymentPlannedWrapper>(Model.PaymentsPlannedGenerated.Select(e => new PaymentPlannedWrapper(e)));
          RegisterCollection(PaymentsPlannedGenerated, Model.PaymentsPlannedGenerated);
          if (Model.PaymentsPlannedCalculated == null) throw new ArgumentException($"{nameof(Model.PaymentsPlannedCalculated)} cannot be null");
          PaymentsPlannedCalculated = new ValidatableChangeTrackingCollection<PaymentPlannedWrapper>(Model.PaymentsPlannedCalculated.Select(e => new PaymentPlannedWrapper(e)));
          RegisterCollection(PaymentsPlannedCalculated, Model.PaymentsPlannedCalculated);
        }
	}

    public class SalesUnitEmptyWrapper : WrapperBase<SalesUnit>
	{
	    public SalesUnitEmptyWrapper(SalesUnit model) : base(model) { }
    }

		
    public partial class DocumentWrapper : WrapperBase<Document>
	{
	    public DocumentWrapper(Document model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// SenderId
        /// </summary>
        public System.Guid SenderId
        {
          get { return Model.SenderId; }
          set { SetValue(value); }
        }
        public System.Guid SenderIdOriginalValue => GetOriginalValue<System.Guid>(nameof(SenderId));
        public bool SenderIdIsChanged => GetIsChanged(nameof(SenderId));

        /// <summary>
        /// RecipientId
        /// </summary>
        public System.Guid RecipientId
        {
          get { return Model.RecipientId; }
          set { SetValue(value); }
        }
        public System.Guid RecipientIdOriginalValue => GetOriginalValue<System.Guid>(nameof(RecipientId));
        public bool RecipientIdIsChanged => GetIsChanged(nameof(RecipientId));

        /// <summary>
        /// WhoRegisteredUserId
        /// </summary>
        public System.Nullable<System.Guid> WhoRegisteredUserId
        {
          get { return Model.WhoRegisteredUserId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> WhoRegisteredUserIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(WhoRegisteredUserId));
        public bool WhoRegisteredUserIdIsChanged => GetIsChanged(nameof(WhoRegisteredUserId));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Номер в ТСЕ
        /// </summary>
        public System.String TceNumber
        {
          get { return Model.TceNumber; }
          set { SetValue(value); }
        }
        public System.String TceNumberOriginalValue => GetOriginalValue<System.String>(nameof(TceNumber));
        public bool TceNumberIsChanged => GetIsChanged(nameof(TceNumber));

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

        #region ComplexProperties

        /// <summary>
        /// ИД
        /// </summary>
	    public DocumentNumberWrapper Number 
        {
            get { return GetWrapper<DocumentNumberWrapper>(); }
            set { SetComplexValue<DocumentNumber, DocumentNumberWrapper>(Number, value); }
        }

        /// <summary>
        /// Запрос
        /// </summary>
	    public DocumentWrapper RequestDocument 
        {
            get { return GetWrapper<DocumentWrapper>(); }
            set { SetComplexValue<Document, DocumentWrapper>(RequestDocument, value); }
        }

        /// <summary>
        /// Автор
        /// </summary>
	    public EmployeeWrapper Author 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(Author, value); }
        }

        /// <summary>
        /// Отправитель
        /// </summary>
	    public EmployeeWrapper SenderEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(SenderEmployee, value); }
        }

        /// <summary>
        /// Получатель
        /// </summary>
	    public EmployeeWrapper RecipientEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(RecipientEmployee, value); }
        }

        /// <summary>
        /// Регистратор
        /// </summary>
	    public UserWrapper WhoRegisteredUser 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(WhoRegisteredUser, value); }
        }

        /// <summary>
        /// Рег.данные получателя
        /// </summary>
	    public DocumentsRegistrationDetailsWrapper RegistrationDetailsOfRecipient 
        {
            get { return GetWrapper<DocumentsRegistrationDetailsWrapper>(); }
            set { SetComplexValue<DocumentsRegistrationDetails, DocumentsRegistrationDetailsWrapper>(RegistrationDetailsOfRecipient, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Копия
        /// </summary>
        public IValidatableChangeTrackingCollection<EmployeeWrapper> CopyToRecipients { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Номер
        /// </summary>
        public System.String RegNumber => Model.RegNumber; 

        /// <summary>
        /// Направление
        /// </summary>
        public HVTApp.Model.POCOs.DocumentDirection Direction => Model.Direction; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<DocumentNumberWrapper>(nameof(Number), Model.Number == null ? null : new DocumentNumberWrapper(Model.Number));
            InitializeComplexProperty<DocumentWrapper>(nameof(RequestDocument), Model.RequestDocument == null ? null : new DocumentWrapper(Model.RequestDocument));
            InitializeComplexProperty<EmployeeWrapper>(nameof(Author), Model.Author == null ? null : new EmployeeWrapper(Model.Author));
            InitializeComplexProperty<EmployeeWrapper>(nameof(SenderEmployee), Model.SenderEmployee == null ? null : new EmployeeWrapper(Model.SenderEmployee));
            InitializeComplexProperty<EmployeeWrapper>(nameof(RecipientEmployee), Model.RecipientEmployee == null ? null : new EmployeeWrapper(Model.RecipientEmployee));
            InitializeComplexProperty<UserWrapper>(nameof(WhoRegisteredUser), Model.WhoRegisteredUser == null ? null : new UserWrapper(Model.WhoRegisteredUser));
            InitializeComplexProperty<DocumentsRegistrationDetailsWrapper>(nameof(RegistrationDetailsOfRecipient), Model.RegistrationDetailsOfRecipient == null ? null : new DocumentsRegistrationDetailsWrapper(Model.RegistrationDetailsOfRecipient));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.CopyToRecipients == null) throw new ArgumentException($"{nameof(Model.CopyToRecipients)} cannot be null");
          CopyToRecipients = new ValidatableChangeTrackingCollection<EmployeeWrapper>(Model.CopyToRecipients.Select(e => new EmployeeWrapper(e)));
          RegisterCollection(CopyToRecipients, Model.CopyToRecipients);
        }
	}

    public class DocumentEmptyWrapper : WrapperBase<Document>
	{
	    public DocumentEmptyWrapper(Document model) : base(model) { }
    }

		
    public partial class SumOnDateWrapper : WrapperBase<SumOnDate>
	{
	    public SumOnDateWrapper(SumOnDate model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Сумма
        /// </summary>
        public System.Double Sum
        {
          get { return Model.Sum; }
          set { SetValue(value); }
        }
        public System.Double SumOriginalValue => GetOriginalValue<System.Double>(nameof(Sum));
        public bool SumIsChanged => GetIsChanged(nameof(Sum));

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
	}

    public class SumOnDateEmptyWrapper : WrapperBase<SumOnDate>
	{
	    public SumOnDateEmptyWrapper(SumOnDate model) : base(model) { }
    }

		
    public partial class ProductWrapper : WrapperBase<Product>
	{
	    public ProductWrapper(Product model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Специальное обозначение
        /// </summary>
        public System.String DesignationSpecial
        {
          get { return Model.DesignationSpecial; }
          set { SetValue(value); }
        }
        public System.String DesignationSpecialOriginalValue => GetOriginalValue<System.String>(nameof(DesignationSpecial));
        public bool DesignationSpecialIsChanged => GetIsChanged(nameof(DesignationSpecial));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

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

        #region ComplexProperties

        /// <summary>
        /// Блок
        /// </summary>
	    public ProductBlockWrapper ProductBlock 
        {
            get { return GetWrapper<ProductBlockWrapper>(); }
            set { SetComplexValue<ProductBlock, ProductBlockWrapper>(ProductBlock, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Продукты в составе
        /// </summary>
        public IValidatableChangeTrackingCollection<ProductDependentWrapper> DependentProducts { get; private set; }

        /// <summary>
        /// КБ ремкомплектов
        /// </summary>
        public IValidatableChangeTrackingCollection<DesignDepartmentWrapper> DesignDepartmentsKits { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Обозначение
        /// </summary>
        public System.String Designation => Model.Designation; 

        /// <summary>
        /// В продукте есть блоки с фиксированной ценой
        /// </summary>
        public System.Boolean HasBlockWithFixedCost => Model.HasBlockWithFixedCost; 

        /// <summary>
        /// IsKit
        /// </summary>
        public System.Boolean IsKit => Model.IsKit; 

        /// <summary>
        /// Тип
        /// </summary>
        public HVTApp.Model.POCOs.ProductType ProductType => Model.ProductType; 

        /// <summary>
        /// Категория
        /// </summary>
        public HVTApp.Model.POCOs.ProductCategory Category => Model.Category; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProductBlockWrapper>(nameof(ProductBlock), Model.ProductBlock == null ? null : new ProductBlockWrapper(Model.ProductBlock));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.DependentProducts == null) throw new ArgumentException($"{nameof(Model.DependentProducts)} cannot be null");
          DependentProducts = new ValidatableChangeTrackingCollection<ProductDependentWrapper>(Model.DependentProducts.Select(e => new ProductDependentWrapper(e)));
          RegisterCollection(DependentProducts, Model.DependentProducts);
          if (Model.DesignDepartmentsKits == null) throw new ArgumentException($"{nameof(Model.DesignDepartmentsKits)} cannot be null");
          DesignDepartmentsKits = new ValidatableChangeTrackingCollection<DesignDepartmentWrapper>(Model.DesignDepartmentsKits.Select(e => new DesignDepartmentWrapper(e)));
          RegisterCollection(DesignDepartmentsKits, Model.DesignDepartmentsKits);
        }
	}

    public class ProductEmptyWrapper : WrapperBase<Product>
	{
	    public ProductEmptyWrapper(Product model) : base(model) { }
    }

		
    public partial class OfferWrapper : WrapperBase<Offer>
	{
	    public OfferWrapper(Offer model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Срок действия
        /// </summary>
        public System.DateTime ValidityDate
        {
          get { return Model.ValidityDate; }
          set { SetValue(value); }
        }
        public System.DateTime ValidityDateOriginalValue => GetOriginalValue<System.DateTime>(nameof(ValidityDate));
        public bool ValidityDateIsChanged => GetIsChanged(nameof(ValidityDate));

        /// <summary>
        /// НДС
        /// </summary>
        public System.Double Vat
        {
          get { return Model.Vat; }
          set { SetValue(value); }
        }
        public System.Double VatOriginalValue => GetOriginalValue<System.Double>(nameof(Vat));
        public bool VatIsChanged => GetIsChanged(nameof(Vat));

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// SenderId
        /// </summary>
        public System.Guid SenderId
        {
          get { return Model.SenderId; }
          set { SetValue(value); }
        }
        public System.Guid SenderIdOriginalValue => GetOriginalValue<System.Guid>(nameof(SenderId));
        public bool SenderIdIsChanged => GetIsChanged(nameof(SenderId));

        /// <summary>
        /// RecipientId
        /// </summary>
        public System.Guid RecipientId
        {
          get { return Model.RecipientId; }
          set { SetValue(value); }
        }
        public System.Guid RecipientIdOriginalValue => GetOriginalValue<System.Guid>(nameof(RecipientId));
        public bool RecipientIdIsChanged => GetIsChanged(nameof(RecipientId));

        /// <summary>
        /// WhoRegisteredUserId
        /// </summary>
        public System.Nullable<System.Guid> WhoRegisteredUserId
        {
          get { return Model.WhoRegisteredUserId; }
          set { SetValue(value); }
        }
        public System.Nullable<System.Guid> WhoRegisteredUserIdOriginalValue => GetOriginalValue<System.Nullable<System.Guid>>(nameof(WhoRegisteredUserId));
        public bool WhoRegisteredUserIdIsChanged => GetIsChanged(nameof(WhoRegisteredUserId));

        /// <summary>
        /// Комментарий
        /// </summary>
        public System.String Comment
        {
          get { return Model.Comment; }
          set { SetValue(value); }
        }
        public System.String CommentOriginalValue => GetOriginalValue<System.String>(nameof(Comment));
        public bool CommentIsChanged => GetIsChanged(nameof(Comment));

        /// <summary>
        /// Номер в ТСЕ
        /// </summary>
        public System.String TceNumber
        {
          get { return Model.TceNumber; }
          set { SetValue(value); }
        }
        public System.String TceNumberOriginalValue => GetOriginalValue<System.String>(nameof(TceNumber));
        public bool TceNumberIsChanged => GetIsChanged(nameof(TceNumber));

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

        #region ComplexProperties

        /// <summary>
        /// Проект
        /// </summary>
	    public ProjectWrapper Project 
        {
            get { return GetWrapper<ProjectWrapper>(); }
            set { SetComplexValue<Project, ProjectWrapper>(Project, value); }
        }

        /// <summary>
        /// ИД
        /// </summary>
	    public DocumentNumberWrapper Number 
        {
            get { return GetWrapper<DocumentNumberWrapper>(); }
            set { SetComplexValue<DocumentNumber, DocumentNumberWrapper>(Number, value); }
        }

        /// <summary>
        /// Запрос
        /// </summary>
	    public DocumentWrapper RequestDocument 
        {
            get { return GetWrapper<DocumentWrapper>(); }
            set { SetComplexValue<Document, DocumentWrapper>(RequestDocument, value); }
        }

        /// <summary>
        /// Автор
        /// </summary>
	    public EmployeeWrapper Author 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(Author, value); }
        }

        /// <summary>
        /// Отправитель
        /// </summary>
	    public EmployeeWrapper SenderEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(SenderEmployee, value); }
        }

        /// <summary>
        /// Получатель
        /// </summary>
	    public EmployeeWrapper RecipientEmployee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(RecipientEmployee, value); }
        }

        /// <summary>
        /// Регистратор
        /// </summary>
	    public UserWrapper WhoRegisteredUser 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(WhoRegisteredUser, value); }
        }

        /// <summary>
        /// Рег.данные получателя
        /// </summary>
	    public DocumentsRegistrationDetailsWrapper RegistrationDetailsOfRecipient 
        {
            get { return GetWrapper<DocumentsRegistrationDetailsWrapper>(); }
            set { SetComplexValue<DocumentsRegistrationDetails, DocumentsRegistrationDetailsWrapper>(RegistrationDetailsOfRecipient, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Копия
        /// </summary>
        public IValidatableChangeTrackingCollection<EmployeeWrapper> CopyToRecipients { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Номер
        /// </summary>
        public System.String RegNumber => Model.RegNumber; 

        /// <summary>
        /// Направление
        /// </summary>
        public HVTApp.Model.POCOs.DocumentDirection Direction => Model.Direction; 

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProjectWrapper>(nameof(Project), Model.Project == null ? null : new ProjectWrapper(Model.Project));
            InitializeComplexProperty<DocumentNumberWrapper>(nameof(Number), Model.Number == null ? null : new DocumentNumberWrapper(Model.Number));
            InitializeComplexProperty<DocumentWrapper>(nameof(RequestDocument), Model.RequestDocument == null ? null : new DocumentWrapper(Model.RequestDocument));
            InitializeComplexProperty<EmployeeWrapper>(nameof(Author), Model.Author == null ? null : new EmployeeWrapper(Model.Author));
            InitializeComplexProperty<EmployeeWrapper>(nameof(SenderEmployee), Model.SenderEmployee == null ? null : new EmployeeWrapper(Model.SenderEmployee));
            InitializeComplexProperty<EmployeeWrapper>(nameof(RecipientEmployee), Model.RecipientEmployee == null ? null : new EmployeeWrapper(Model.RecipientEmployee));
            InitializeComplexProperty<UserWrapper>(nameof(WhoRegisteredUser), Model.WhoRegisteredUser == null ? null : new UserWrapper(Model.WhoRegisteredUser));
            InitializeComplexProperty<DocumentsRegistrationDetailsWrapper>(nameof(RegistrationDetailsOfRecipient), Model.RegistrationDetailsOfRecipient == null ? null : new DocumentsRegistrationDetailsWrapper(Model.RegistrationDetailsOfRecipient));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.CopyToRecipients == null) throw new ArgumentException($"{nameof(Model.CopyToRecipients)} cannot be null");
          CopyToRecipients = new ValidatableChangeTrackingCollection<EmployeeWrapper>(Model.CopyToRecipients.Select(e => new EmployeeWrapper(e)));
          RegisterCollection(CopyToRecipients, Model.CopyToRecipients);
        }
	}

    public class OfferEmptyWrapper : WrapperBase<Offer>
	{
	    public OfferEmptyWrapper(Offer model) : base(model) { }
    }

		
    public partial class EmployeeWrapper : WrapperBase<Employee>
	{
	    public EmployeeWrapper(Employee model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Шифр
        /// </summary>
        public System.String PersonalNumber
        {
          get { return Model.PersonalNumber; }
          set { SetValue(value); }
        }
        public System.String PersonalNumberOriginalValue => GetOriginalValue<System.String>(nameof(PersonalNumber));
        public bool PersonalNumberIsChanged => GetIsChanged(nameof(PersonalNumber));

        /// <summary>
        /// Телефон
        /// </summary>
        public System.String PhoneNumber
        {
          get { return Model.PhoneNumber; }
          set { SetValue(value); }
        }
        public System.String PhoneNumberOriginalValue => GetOriginalValue<System.String>(nameof(PhoneNumber));
        public bool PhoneNumberIsChanged => GetIsChanged(nameof(PhoneNumber));

        /// <summary>
        /// e-mail
        /// </summary>
        public System.String Email
        {
          get { return Model.Email; }
          set { SetValue(value); }
        }
        public System.String EmailOriginalValue => GetOriginalValue<System.String>(nameof(Email));
        public bool EmailIsChanged => GetIsChanged(nameof(Email));

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

        #region ComplexProperties

        /// <summary>
        /// Персона
        /// </summary>
	    public PersonWrapper Person 
        {
            get { return GetWrapper<PersonWrapper>(); }
            set { SetComplexValue<Person, PersonWrapper>(Person, value); }
        }

        /// <summary>
        /// Компания
        /// </summary>
	    public CompanyWrapper Company 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(Company, value); }
        }

        /// <summary>
        /// Должность
        /// </summary>
	    public EmployeesPositionWrapper Position 
        {
            get { return GetWrapper<EmployeesPositionWrapper>(); }
            set { SetComplexValue<EmployeesPosition, EmployeesPositionWrapper>(Position, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<PersonWrapper>(nameof(Person), Model.Person == null ? null : new PersonWrapper(Model.Person));
            InitializeComplexProperty<CompanyWrapper>(nameof(Company), Model.Company == null ? null : new CompanyWrapper(Model.Company));
            InitializeComplexProperty<EmployeesPositionWrapper>(nameof(Position), Model.Position == null ? null : new EmployeesPositionWrapper(Model.Position));
        }
	}

    public class EmployeeEmptyWrapper : WrapperBase<Employee>
	{
	    public EmployeeEmptyWrapper(Employee model) : base(model) { }
    }

		
    public partial class OrderWrapper : WrapperBase<Order>
	{
	    public OrderWrapper(Order model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Номер
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Дата открытия
        /// </summary>
        public System.DateTime DateOpen
        {
          get { return Model.DateOpen; }
          set { SetValue(value); }
        }
        public System.DateTime DateOpenOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateOpen));
        public bool DateOpenIsChanged => GetIsChanged(nameof(DateOpen));

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
	}

    public class OrderEmptyWrapper : WrapperBase<Order>
	{
	    public OrderEmptyWrapper(Order model) : base(model) { }
    }

		
    public partial class PaymentConditionWrapper : WrapperBase<PaymentCondition>
	{
	    public PaymentConditionWrapper(PaymentCondition model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Часть
        /// </summary>
        public System.Double Part
        {
          get { return Model.Part; }
          set { SetValue(value); }
        }
        public System.Double PartOriginalValue => GetOriginalValue<System.Double>(nameof(Part));
        public bool PartIsChanged => GetIsChanged(nameof(Part));

        /// <summary>
        /// Дней до условия
        /// </summary>
        public System.Int32 DaysToPoint
        {
          get { return Model.DaysToPoint; }
          set { SetValue(value); }
        }
        public System.Int32 DaysToPointOriginalValue => GetOriginalValue<System.Int32>(nameof(DaysToPoint));
        public bool DaysToPointIsChanged => GetIsChanged(nameof(DaysToPoint));

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

        #region ComplexProperties

        /// <summary>
        /// Условие
        /// </summary>
	    public PaymentConditionPointWrapper PaymentConditionPoint 
        {
            get { return GetWrapper<PaymentConditionPointWrapper>(); }
            set { SetComplexValue<PaymentConditionPoint, PaymentConditionPointWrapper>(PaymentConditionPoint, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<PaymentConditionPointWrapper>(nameof(PaymentConditionPoint), Model.PaymentConditionPoint == null ? null : new PaymentConditionPointWrapper(Model.PaymentConditionPoint));
        }
	}

    public class PaymentConditionEmptyWrapper : WrapperBase<PaymentCondition>
	{
	    public PaymentConditionEmptyWrapper(PaymentCondition model) : base(model) { }
    }

		
    public partial class PaymentDocumentWrapper : WrapperBase<PaymentDocument>
	{
	    public PaymentDocumentWrapper(PaymentDocument model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Номер
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// НДС
        /// </summary>
        public System.Double Vat
        {
          get { return Model.Vat; }
          set { SetValue(value); }
        }
        public System.Double VatOriginalValue => GetOriginalValue<System.Double>(nameof(Vat));
        public bool VatIsChanged => GetIsChanged(nameof(Vat));

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
        /// Платежи
        /// </summary>
        public IValidatableChangeTrackingCollection<PaymentActualWrapper> Payments { get; private set; }

        #endregion

        #region GetProperties

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date => Model.Date; 

        /// <summary>
        /// SumWithVat
        /// </summary>
        public System.Double SumWithVat => Model.SumWithVat; 

        #endregion

        protected override void InitializeCollectionProperties()
        {
          if (Model.Payments == null) throw new ArgumentException($"{nameof(Model.Payments)} cannot be null");
          Payments = new ValidatableChangeTrackingCollection<PaymentActualWrapper>(Model.Payments.Select(e => new PaymentActualWrapper(e)));
          RegisterCollection(Payments, Model.Payments);
        }
	}

    public class PaymentDocumentEmptyWrapper : WrapperBase<PaymentDocument>
	{
	    public PaymentDocumentEmptyWrapper(PaymentDocument model) : base(model) { }
    }

		
    public partial class FacilityWrapper : WrapperBase<Facility>
	{
	    public FacilityWrapper(Facility model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

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

        #region ComplexProperties

        /// <summary>
        /// Тип
        /// </summary>
	    public FacilityTypeWrapper Type 
        {
            get { return GetWrapper<FacilityTypeWrapper>(); }
            set { SetComplexValue<FacilityType, FacilityTypeWrapper>(Type, value); }
        }

        /// <summary>
        /// Владелец
        /// </summary>
	    public CompanyWrapper OwnerCompany 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(OwnerCompany, value); }
        }

        /// <summary>
        /// Местоположение
        /// </summary>
	    public AddressWrapper Address 
        {
            get { return GetWrapper<AddressWrapper>(); }
            set { SetComplexValue<Address, AddressWrapper>(Address, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<FacilityTypeWrapper>(nameof(Type), Model.Type == null ? null : new FacilityTypeWrapper(Model.Type));
            InitializeComplexProperty<CompanyWrapper>(nameof(OwnerCompany), Model.OwnerCompany == null ? null : new CompanyWrapper(Model.OwnerCompany));
            InitializeComplexProperty<AddressWrapper>(nameof(Address), Model.Address == null ? null : new AddressWrapper(Model.Address));
        }
	}

    public class FacilityEmptyWrapper : WrapperBase<Facility>
	{
	    public FacilityEmptyWrapper(Facility model) : base(model) { }
    }

		
    public partial class ProjectWrapper : WrapperBase<Project>
	{
	    public ProjectWrapper(Project model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// ProjectTypeId
        /// </summary>
        public System.Guid ProjectTypeId
        {
          get { return Model.ProjectTypeId; }
          set { SetValue(value); }
        }
        public System.Guid ProjectTypeIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ProjectTypeId));
        public bool ProjectTypeIdIsChanged => GetIsChanged(nameof(ProjectTypeId));

        /// <summary>
        /// В работе
        /// </summary>
        public System.Boolean InWork
        {
          get { return Model.InWork; }
          set { SetValue(value); }
        }
        public System.Boolean InWorkOriginalValue => GetOriginalValue<System.Boolean>(nameof(InWork));
        public bool InWorkIsChanged => GetIsChanged(nameof(InWork));

        /// <summary>
        /// Отчетный
        /// </summary>
        public System.Boolean ForReport
        {
          get { return Model.ForReport; }
          set { SetValue(value); }
        }
        public System.Boolean ForReportOriginalValue => GetOriginalValue<System.Boolean>(nameof(ForReport));
        public bool ForReportIsChanged => GetIsChanged(nameof(ForReport));

        /// <summary>
        /// ManagerId
        /// </summary>
        public System.Guid ManagerId
        {
          get { return Model.ManagerId; }
          set { SetValue(value); }
        }
        public System.Guid ManagerIdOriginalValue => GetOriginalValue<System.Guid>(nameof(ManagerId));
        public bool ManagerIdIsChanged => GetIsChanged(nameof(ManagerId));

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

        #region ComplexProperties

        /// <summary>
        /// Тип проекта
        /// </summary>
	    public ProjectTypeWrapper ProjectType 
        {
            get { return GetWrapper<ProjectTypeWrapper>(); }
            set { SetComplexValue<ProjectType, ProjectTypeWrapper>(ProjectType, value); }
        }

        /// <summary>
        /// Менеджер
        /// </summary>
	    public UserWrapper Manager 
        {
            get { return GetWrapper<UserWrapper>(); }
            set { SetComplexValue<User, UserWrapper>(Manager, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Заметки
        /// </summary>
        public IValidatableChangeTrackingCollection<NoteWrapper> Notes { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProjectTypeWrapper>(nameof(ProjectType), Model.ProjectType == null ? null : new ProjectTypeWrapper(Model.ProjectType));
            InitializeComplexProperty<UserWrapper>(nameof(Manager), Model.Manager == null ? null : new UserWrapper(Model.Manager));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Notes == null) throw new ArgumentException($"{nameof(Model.Notes)} cannot be null");
          Notes = new ValidatableChangeTrackingCollection<NoteWrapper>(Model.Notes.Select(e => new NoteWrapper(e)));
          RegisterCollection(Notes, Model.Notes);
        }
	}

    public class ProjectEmptyWrapper : WrapperBase<Project>
	{
	    public ProjectEmptyWrapper(Project model) : base(model) { }
    }

		
    public partial class UserRoleWrapper : WrapperBase<UserRole>
	{
	    public UserRoleWrapper(UserRole model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Role
        /// </summary>
        public HVTApp.Infrastructure.Role Role
        {
          get { return Model.Role; }
          set { SetValue(value); }
        }
        public HVTApp.Infrastructure.Role RoleOriginalValue => GetOriginalValue<HVTApp.Infrastructure.Role>(nameof(Role));
        public bool RoleIsChanged => GetIsChanged(nameof(Role));

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
	}

    public class UserRoleEmptyWrapper : WrapperBase<UserRole>
	{
	    public UserRoleEmptyWrapper(UserRole model) : base(model) { }
    }

		
    public partial class SpecificationWrapper : WrapperBase<Specification>
	{
	    public SpecificationWrapper(Specification model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// №
        /// </summary>
        public System.String Number
        {
          get { return Model.Number; }
          set { SetValue(value); }
        }
        public System.String NumberOriginalValue => GetOriginalValue<System.String>(nameof(Number));
        public bool NumberIsChanged => GetIsChanged(nameof(Number));

        /// <summary>
        /// Дата
        /// </summary>
        public System.DateTime Date
        {
          get { return Model.Date; }
          set { SetValue(value); }
        }
        public System.DateTime DateOriginalValue => GetOriginalValue<System.DateTime>(nameof(Date));
        public bool DateIsChanged => GetIsChanged(nameof(Date));

        /// <summary>
        /// Дата подписания
        /// </summary>
        public System.Nullable<System.DateTime> SignDate
        {
          get { return Model.SignDate; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> SignDateOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(SignDate));
        public bool SignDateIsChanged => GetIsChanged(nameof(SignDate));

        /// <summary>
        /// НДС
        /// </summary>
        public System.Double Vat
        {
          get { return Model.Vat; }
          set { SetValue(value); }
        }
        public System.Double VatOriginalValue => GetOriginalValue<System.Double>(nameof(Vat));
        public bool VatIsChanged => GetIsChanged(nameof(Vat));

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

        #region ComplexProperties

        /// <summary>
        /// Договор
        /// </summary>
	    public ContractWrapper Contract 
        {
            get { return GetWrapper<ContractWrapper>(); }
            set { SetComplexValue<Contract, ContractWrapper>(Contract, value); }
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ContractWrapper>(nameof(Contract), Model.Contract == null ? null : new ContractWrapper(Model.Contract));
        }
	}

    public class SpecificationEmptyWrapper : WrapperBase<Specification>
	{
	    public SpecificationEmptyWrapper(Specification model) : base(model) { }
    }

		
    public partial class TenderWrapper : WrapperBase<Tender>
	{
	    public TenderWrapper(Tender model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Ссылка
        /// </summary>
        public System.String Link
        {
          get { return Model.Link; }
          set { SetValue(value); }
        }
        public System.String LinkOriginalValue => GetOriginalValue<System.String>(nameof(Link));
        public bool LinkIsChanged => GetIsChanged(nameof(Link));

        /// <summary>
        /// Открытие
        /// </summary>
        public System.DateTime DateOpen
        {
          get { return Model.DateOpen; }
          set { SetValue(value); }
        }
        public System.DateTime DateOpenOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateOpen));
        public bool DateOpenIsChanged => GetIsChanged(nameof(DateOpen));

        /// <summary>
        /// Закрытие
        /// </summary>
        public System.DateTime DateClose
        {
          get { return Model.DateClose; }
          set { SetValue(value); }
        }
        public System.DateTime DateCloseOriginalValue => GetOriginalValue<System.DateTime>(nameof(DateClose));
        public bool DateCloseIsChanged => GetIsChanged(nameof(DateClose));

        /// <summary>
        /// Итоги
        /// </summary>
        public System.Nullable<System.DateTime> DateNotice
        {
          get { return Model.DateNotice; }
          set { SetValue(value); }
        }
        public System.Nullable<System.DateTime> DateNoticeOriginalValue => GetOriginalValue<System.Nullable<System.DateTime>>(nameof(DateNotice));
        public bool DateNoticeIsChanged => GetIsChanged(nameof(DateNotice));

        /// <summary>
        /// Не состоялся
        /// </summary>
        public System.Boolean DidNotTakePlace
        {
          get { return Model.DidNotTakePlace; }
          set { SetValue(value); }
        }
        public System.Boolean DidNotTakePlaceOriginalValue => GetOriginalValue<System.Boolean>(nameof(DidNotTakePlace));
        public bool DidNotTakePlaceIsChanged => GetIsChanged(nameof(DidNotTakePlace));

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

        #region ComplexProperties

        /// <summary>
        /// Проект
        /// </summary>
	    public ProjectWrapper Project 
        {
            get { return GetWrapper<ProjectWrapper>(); }
            set { SetComplexValue<Project, ProjectWrapper>(Project, value); }
        }

        /// <summary>
        /// Победитель
        /// </summary>
	    public CompanyWrapper Winner 
        {
            get { return GetWrapper<CompanyWrapper>(); }
            set { SetComplexValue<Company, CompanyWrapper>(Winner, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Типы
        /// </summary>
        public IValidatableChangeTrackingCollection<TenderTypeWrapper> Types { get; private set; }

        /// <summary>
        /// Участники
        /// </summary>
        public IValidatableChangeTrackingCollection<CompanyWrapper> Participants { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<ProjectWrapper>(nameof(Project), Model.Project == null ? null : new ProjectWrapper(Model.Project));
            InitializeComplexProperty<CompanyWrapper>(nameof(Winner), Model.Winner == null ? null : new CompanyWrapper(Model.Winner));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Types == null) throw new ArgumentException($"{nameof(Model.Types)} cannot be null");
          Types = new ValidatableChangeTrackingCollection<TenderTypeWrapper>(Model.Types.Select(e => new TenderTypeWrapper(e)));
          RegisterCollection(Types, Model.Types);
          if (Model.Participants == null) throw new ArgumentException($"{nameof(Model.Participants)} cannot be null");
          Participants = new ValidatableChangeTrackingCollection<CompanyWrapper>(Model.Participants.Select(e => new CompanyWrapper(e)));
          RegisterCollection(Participants, Model.Participants);
        }
	}

    public class TenderEmptyWrapper : WrapperBase<Tender>
	{
	    public TenderEmptyWrapper(Tender model) : base(model) { }
    }

		
    public partial class TenderTypeWrapper : WrapperBase<TenderType>
	{
	    public TenderTypeWrapper(TenderType model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Название
        /// </summary>
        public System.String Name
        {
          get { return Model.Name; }
          set { SetValue(value); }
        }
        public System.String NameOriginalValue => GetOriginalValue<System.String>(nameof(Name));
        public bool NameIsChanged => GetIsChanged(nameof(Name));

        /// <summary>
        /// Type
        /// </summary>
        public HVTApp.Model.POCOs.TenderTypeEnum Type
        {
          get { return Model.Type; }
          set { SetValue(value); }
        }
        public HVTApp.Model.POCOs.TenderTypeEnum TypeOriginalValue => GetOriginalValue<HVTApp.Model.POCOs.TenderTypeEnum>(nameof(Type));
        public bool TypeIsChanged => GetIsChanged(nameof(Type));

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
	}

    public class TenderTypeEmptyWrapper : WrapperBase<TenderType>
	{
	    public TenderTypeEmptyWrapper(TenderType model) : base(model) { }
    }

		
    public partial class UserWrapper : WrapperBase<User>
	{
	    public UserWrapper(User model) : base(model) { }

        #region SimpleProperties

        /// <summary>
        /// Логин
        /// </summary>
        public System.String Login
        {
          get { return Model.Login; }
          set { SetValue(value); }
        }
        public System.String LoginOriginalValue => GetOriginalValue<System.String>(nameof(Login));
        public bool LoginIsChanged => GetIsChanged(nameof(Login));

        /// <summary>
        /// Пароль
        /// </summary>
        public System.Guid Password
        {
          get { return Model.Password; }
          set { SetValue(value); }
        }
        public System.Guid PasswordOriginalValue => GetOriginalValue<System.Guid>(nameof(Password));
        public bool PasswordIsChanged => GetIsChanged(nameof(Password));

        /// <summary>
        /// Текущая роль
        /// </summary>
        public HVTApp.Infrastructure.Role RoleCurrent
        {
          get { return Model.RoleCurrent; }
          set { SetValue(value); }
        }
        public HVTApp.Infrastructure.Role RoleCurrentOriginalValue => GetOriginalValue<HVTApp.Infrastructure.Role>(nameof(RoleCurrent));
        public bool RoleCurrentIsChanged => GetIsChanged(nameof(RoleCurrent));

        /// <summary>
        /// Актуален
        /// </summary>
        public System.Boolean IsActual
        {
          get { return Model.IsActual; }
          set { SetValue(value); }
        }
        public System.Boolean IsActualOriginalValue => GetOriginalValue<System.Boolean>(nameof(IsActual));
        public bool IsActualIsChanged => GetIsChanged(nameof(IsActual));

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

        #region ComplexProperties

        /// <summary>
        /// Сотрудник
        /// </summary>
	    public EmployeeWrapper Employee 
        {
            get { return GetWrapper<EmployeeWrapper>(); }
            set { SetComplexValue<Employee, EmployeeWrapper>(Employee, value); }
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Роли
        /// </summary>
        public IValidatableChangeTrackingCollection<UserRoleWrapper> Roles { get; private set; }

        #endregion

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty<EmployeeWrapper>(nameof(Employee), Model.Employee == null ? null : new EmployeeWrapper(Model.Employee));
        }

        protected override void InitializeCollectionProperties()
        {
          if (Model.Roles == null) throw new ArgumentException($"{nameof(Model.Roles)} cannot be null");
          Roles = new ValidatableChangeTrackingCollection<UserRoleWrapper>(Model.Roles.Select(e => new UserRoleWrapper(e)));
          RegisterCollection(Roles, Model.Roles);
        }
	}

    public class UserEmptyWrapper : WrapperBase<User>
	{
	    public UserEmptyWrapper(User model) : base(model) { }
    }

	}
