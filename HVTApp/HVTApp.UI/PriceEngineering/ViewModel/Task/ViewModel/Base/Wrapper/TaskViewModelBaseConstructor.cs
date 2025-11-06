using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.PriceEngineering.Wrapper
{
    public abstract class TaskViewModelBaseConstructor : TaskViewModelBaseStartable
    {
        #region SimpleProperties

        /// <summary>
        /// Запрос на проверку от исполнителя
        /// </summary>
        public bool RequestForVerificationFromConstructor
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public bool RequestForVerificationFromConstructorOriginalValue => GetOriginalValue<bool>(nameof(RequestForVerificationFromConstructor));
        public bool RequestForVerificationFromConstructorIsChanged => GetIsChanged(nameof(RequestForVerificationFromConstructor));

        /// <summary>
        /// ТЗ валидно для производства
        /// </summary>
        public new bool IsValidForProduction
        {
            get => GetValue<bool>();
            set => SetValue(value);
        }
        public bool IsValidForProductionOriginalValue => GetOriginalValue<bool>(nameof(IsValidForProduction));
        public bool IsValidForProductionIsChanged => GetIsChanged(nameof(IsValidForProduction));

        /// <summary>
        /// Требуется разработка КД
        /// </summary>
        public bool NeedDesignDocumentationDevelopment
        {
            get => Model.NeedDesignDocumentationDevelopment;
            set
            {
                SetValue(value);
                if (value == false)
                {
                    DaysToDesignDocumentationDevelopment = null;
                    DesignDocumentationAvailabilityComment = null;
                }
            }
        }
        public bool NeedDesignDocumentationDevelopmentOriginalValue => GetOriginalValue<bool>(nameof(NeedDesignDocumentationDevelopment));
        public bool NeedDesignDocumentationDevelopmentIsChanged => GetIsChanged(nameof(NeedDesignDocumentationDevelopment));

        /// <summary>
        /// Дней на разработку КД
        /// </summary>
        public short? DaysToDesignDocumentationDevelopment
        {
            get => Model.DaysToDesignDocumentationDevelopment;
            set => SetValue(value);
        }
        public short? DaysToDesignDocumentationDevelopmentOriginalValue => GetOriginalValue<short?>(nameof(DaysToDesignDocumentationDevelopment));
        public bool DaysToDesignDocumentationDevelopmentIsChanged => GetIsChanged(nameof(DaysToDesignDocumentationDevelopment));

        /// <summary>
        /// Комментарий по разработке КД
        /// </summary>
        public string DesignDocumentationAvailabilityComment
        {
            get => Model.DesignDocumentationAvailabilityComment;
            set => SetValue(value);
        }
        public string DesignDocumentationAvailabilityCommentOriginalValue => GetOriginalValue<string>(nameof(DesignDocumentationAvailabilityComment));
        public bool DesignDocumentationAvailabilityCommentIsChanged => GetIsChanged(nameof(DesignDocumentationAvailabilityComment));

        /// <summary>
        /// Коэффициент удорожания
        /// </summary>
        public double? PriceIncreaseFactor
        {
            get => Model.PriceIncreaseFactor;
            set => SetValue(value);
        }
        public double? PriceIncreaseFactorOriginalValue => GetOriginalValue<double?>(nameof(PriceIncreaseFactor));
        public bool PriceIncreaseFactorIsChanged => GetIsChanged(nameof(PriceIncreaseFactor));

        #endregion

        #region ComplexProperties

        /// <summary>
        /// Блок продукта от инженера-конструктора
        /// </summary>
        public new ProductBlockStructureCostWrapperConstructor ProductBlockEngineer
        {
            get => GetWrapper<ProductBlockStructureCostWrapperConstructor>();
            set => SetComplexValue<ProductBlock, ProductBlockStructureCostWrapperConstructor>(ProductBlockEngineer, value);
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Добавленные блоки продукта от инженера-конструктора
        /// </summary>
        public new IValidatableChangeTrackingCollection<TaskProductBlockAddedWrapperConstructor> ProductBlocksAdded { get; private set; }

        public IValidatableChangeTrackingCollection<UpdateStructureCostNumberTaskForConstructorViewModel> UpdateStructureCostNumberTasks { get; private set; }

        #endregion

        #region ctors

        protected TaskViewModelBaseConstructor(IUnityContainer container, Guid priceEngineeringTaskId) : base(container, priceEngineeringTaskId)
        {
        }

        protected TaskViewModelBaseConstructor(IUnityContainer container, IUnitOfWork unitOfWork) : base(container, unitOfWork)
        {
        }

        #endregion

        public override void InitializeComplexProperties()
        {
            base.InitializeComplexProperties();

            InitializeComplexProperty(nameof(ProductBlockEngineer), Model.ProductBlockEngineer == null 
                ? null 
                : new ProductBlockStructureCostWrapperConstructor(Model.ProductBlockEngineer));
        }

        protected override void InitializeCollectionProperties()
        {
            base.InitializeCollectionProperties();

            if (Model.ProductBlocksAdded == null) throw new ArgumentException("ProductBlocksAdded cannot be null");
            ProductBlocksAdded = new ValidatableChangeTrackingCollection<TaskProductBlockAddedWrapperConstructor>(Model.ProductBlocksAdded.Select(x => new TaskProductBlockAddedWrapperConstructor(x)));
            RegisterCollection(ProductBlocksAdded, Model.ProductBlocksAdded);

            if (Model.UpdateStructureCostNumberTasks == null) throw new ArgumentException("UpdateStructureCostNumberTasks cannot be null");
            UpdateStructureCostNumberTasks = new ValidatableChangeTrackingCollection<UpdateStructureCostNumberTaskForConstructorViewModel>(Model.UpdateStructureCostNumberTasks.Select(x => new UpdateStructureCostNumberTaskForConstructorViewModel(x)));
            RegisterCollection(UpdateStructureCostNumberTasks, Model.UpdateStructureCostNumberTasks);
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            if (PriceIncreaseFactor.HasValue)
            {
                if (PriceIncreaseFactor.Value <= 0)
                    yield return new ValidationResult("Коэффициент удорожания должен быть больше 0", new[] { nameof(DaysToDesignDocumentationDevelopment) });
            }

            if (DaysToDesignDocumentationDevelopment.HasValue)
            {
                if (DaysToDesignDocumentationDevelopment < 0)
                    yield return new ValidationResult("Дней на разработку не должно быть меньше 0", new[] { nameof(DaysToDesignDocumentationDevelopment) });
                else if (DaysToDesignDocumentationDevelopment > 1024)
                    yield return new ValidationResult("Дней на разработку не должно быть больше 1024", new[] { nameof(DaysToDesignDocumentationDevelopment) });
            }

            if (NeedDesignDocumentationDevelopment && DaysToDesignDocumentationDevelopment.HasValue == false)
                yield return new ValidationResult("Дней на разработку не заполнено", new[] { nameof(DaysToDesignDocumentationDevelopment) });
        }
    }
}