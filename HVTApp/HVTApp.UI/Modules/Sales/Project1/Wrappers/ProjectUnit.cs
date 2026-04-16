using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure.Comparers;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Price;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;

namespace HVTApp.UI.Modules.Sales.Project1.Wrappers
{
    public class ProjectUnit : WrapperBase<SalesUnit>, IProjectUnit
    {
        public Project Project
        {
            get => this.Model.Project;
            set => this.Model.Project = value;
        }

        public Specification Specification => this.Model.Specification;
        public string OrderNumber => this.Model.Order?.Number;

        #region SimpleProperties

        public double Cost
        {
            get => Model.Cost;
            set
            {
                if (value < 0) return;
                SetValue(value);
                RaisePropertyChanged(nameof(CalculatedParts));
            }
        }

        /// <summary>
        /// Стоимость для формирования бюджета
        /// </summary>
        public double? CostWithReserve
        {
            get => Model.CostWithReserve;
            set
            {
                if (value < 0) return;
                SetValue(value);
            }
        }
        public double? CostWithReserveOriginalValue => GetOriginalValue<double?>(nameof(CostWithReserve));
        public bool CostWithReserveIsChanged => GetIsChanged(nameof(CostWithReserve));


        public double? CostDelivery
        {
            get => Model.CostDelivery;
            set
            {
                if (value < 0) return;
                SetValue(value == 0 ? default : value);
            }
        }

        public DateTime DeliveryDateExpected
        {
            get => Model.DeliveryDateExpected;
            set => SetValue(value);
        }

        public bool IsRemoved
        {
            get => Model.IsRemoved;
            set => SetValue(value);
        }

        public int ProductionTerm
        {
            get => Model.ProductionTerm;
            set
            {
                if (value < 0) return;
                SetValue(value);
            }
        }

        public string Comment
        {
            get => Model.Comment;
            set => SetValue(value);
        }

        #endregion

        #region ComplexProperties

        public FacilityEmptyWrapper Facility
        {
            get => GetWrapper<FacilityEmptyWrapper>();
            set => SetComplexValue<Facility, FacilityEmptyWrapper>(Facility, value);
        }

        public ProductEmptyWrapper Product
        {
            get => GetWrapper<ProductEmptyWrapper>();
            set => SetComplexValue<Product, ProductEmptyWrapper>(Product, value);
        }

        public PaymentConditionSetEmptyWrapper PaymentConditionSet
        {
            get => GetWrapper<PaymentConditionSetEmptyWrapper>();
            set => SetComplexValue<PaymentConditionSet, PaymentConditionSetEmptyWrapper>(PaymentConditionSet, value);
        }

        public CompanyEmptyWrapper Producer
        {
            get => GetWrapper<CompanyEmptyWrapper>();
            set => SetComplexValue<Company, CompanyEmptyWrapper>(Producer, value);
        }

        #endregion

        #region CollectionProperties

        /// <summary>
        /// Включенные продукты
        /// </summary>
        public IValidatableChangeTrackingCollection<ProjectUnitProductIncluded> ProductsIncluded { get; private set; }

        #endregion

        public IEnumerable<ProjectUnitProductIncludedGroup> ProductsIncludedGroups =>
            this.ProductsIncluded
                .GroupBy(x => x, new ProjectUnitProductIncluded.ProjectUnitProductIncludedComparer())
                .Select(x => new ProjectUnitProductIncludedGroup(x));

        public Price Price => GlobalAppProperties.PriceService.GetPrice(this.Model, this.Model.RealizationDateCalculated, true);
        public ProjectUnitCalculatedParts CalculatedParts { get; }

        public IEnumerable<PaymentViewModel> Payments =>
            this.Model.PaymentsActual
                .Select(paymentActual => new PaymentViewModel(paymentActual, Model.Cost))
                .OrderBy(paymentViewModel => paymentViewModel.Date);

        public IEnumerable<Price> Prices => new List<Price> { this.Price };

        #region Ctors

        /// <summary>
        /// Для редактирования
        /// </summary>
        /// <param name="model"></param>
        public ProjectUnit(SalesUnit model) : base(model)
        {
            CalculatedParts = new ProjectUnitCalculatedParts(this);

            this.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Cost) ||
                    args.PropertyName == nameof(CostWithReserve) ||
                    args.PropertyName == nameof(CostDelivery))
                {
                    RaisePropertyChanged(nameof(CalculatedParts));
                }
                else if (args.PropertyName == nameof(Product) ||
                         args.PropertyName == nameof(ProductsIncluded) ||
                         args.PropertyName == nameof(DeliveryDateExpected))
                {
                    RaisePropertyChanged(nameof(CalculatedParts));
                    RaisePropertyChanged(nameof(Prices));
                }
            };

            this.ProductsIncluded.CollectionChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(CalculatedParts));
                RaisePropertyChanged(nameof(ProductsIncludedGroups));
                RaisePropertyChanged(nameof(Prices));
            };
        }

        public override void InitializeComplexProperties()
        {
            InitializeComplexProperty(nameof(Facility), Model.Facility == null ? null : new FacilityEmptyWrapper(Model.Facility));
            InitializeComplexProperty(nameof(Product), Model.Product == null ? null : new ProductEmptyWrapper(Model.Product));
            InitializeComplexProperty(nameof(PaymentConditionSet), Model.PaymentConditionSet == null ? null : new PaymentConditionSetEmptyWrapper(Model.PaymentConditionSet));
            InitializeComplexProperty(nameof(Producer), Model.Producer == null ? null : new CompanyEmptyWrapper(Model.Producer));
        }

        protected override void InitializeCollectionProperties()
        {
            if (Model.ProductsIncluded == null) throw new ArgumentException($"{nameof(Model.ProductsIncluded)} cannot be null");
            ProductsIncluded = new ValidatableChangeTrackingCollection<ProjectUnitProductIncluded>(Model.ProductsIncluded.Select(e => new ProjectUnitProductIncluded(e)));
            RegisterCollection(ProductsIncluded, Model.ProductsIncluded);
        }

        #endregion

        public class ProjectUnitComparer : IEqualityComparer<IProjectUnit>
        {
            public virtual bool Equals(IProjectUnit x, IProjectUnit y)
            {
                if (x == null) throw new ArgumentNullException(nameof(x));
                if (y == null) throw new ArgumentNullException(nameof(y));

                if (!Equals(x.IsRemoved, y.IsRemoved)) return false;
                if (!Equals(x.Cost, y.Cost)) return false;
                if (!Equals(x.CostWithReserve, y.CostWithReserve)) return false;
                if (!Equals(x.ProductionTerm, y.ProductionTerm)) return false;
                if (!Equals(x.CostDelivery, y.CostDelivery)) return false;
                if (!Equals(x.Comment, y.Comment)) return false;
                if (!Equals(x.DeliveryDateExpected, y.DeliveryDateExpected)) return false;
                if (!Equals(x.Product?.Model.Id, y.Product?.Model.Id)) return false;
                if (!Equals(x.Facility?.Model.Id, y.Facility?.Model.Id)) return false;
                if (!Equals(x.PaymentConditionSet?.Model.Id, y.PaymentConditionSet?.Model.Id)) return false;
                if (!Equals(x.Producer?.Model.Id, y.Producer?.Model.Id)) return false;
                if (!Equals(x.Specification?.Id, y.Specification?.Id)) return false;
                if (!Equals(x.OrderNumber, y.OrderNumber)) return false;

                var productsInclX = x.ProductsIncludedGroups
                    .SelectMany(productIncludedGroup => productIncludedGroup.Items)
                    .Select(p => new ProductAmount(p.Model.Product.Id, p.Model.Amount, p.CustomFixedPrice))
                    .ToList();
                var productsInclY = y.ProductsIncludedGroups
                    .SelectMany(productIncludedGroup => productIncludedGroup.Items)
                    .Select(p => new ProductAmount(p.Model.Product.Id, p.Model.Amount, p.CustomFixedPrice))
                    .ToList();

                if (productsInclX.Except(productsInclY, new ProductAmountComparer()).Any()) return false;
                if (productsInclY.Except(productsInclX, new ProductAmountComparer()).Any()) return false;

                return true;
            }

            public int GetHashCode(IProjectUnit obj)
            {
                return 0;
            }
        }


        public void CopyProperties(IProjectUnit projectUnit)
        {
            this.Cost = projectUnit.Cost;
            this.Comment = projectUnit.Comment;
            this.CostDelivery = projectUnit.CostDelivery;
            this.DeliveryDateExpected = projectUnit.DeliveryDateExpected;
            this.ProductionTerm = projectUnit.ProductionTerm;

            this.Facility = projectUnit.Facility;
            this.Project = projectUnit.Project;
            this.Product = projectUnit.Product;
            this.PaymentConditionSet = projectUnit.PaymentConditionSet;
            this.Producer = projectUnit.Producer;

            var pu = projectUnit is ProjectUnitGroup projectUnitGroup
                ? projectUnitGroup.Units.First()
                : projectUnit;
            var pi = pu
                .ProductsIncludedGroups
                .SelectMany(x => x.Items)
                .Select(x => x.Model)
                .Select(productIncluded => new ProductIncluded
                {
                    Product = productIncluded.Product, 
                    Amount = productIncluded.Amount, 
                    CustomFixedPrice = productIncluded.CustomFixedPrice
                });

            foreach (var productIncluded in pi)
            {
                this.ProductsIncluded.Add(new ProjectUnitProductIncluded(productIncluded));
            }
        }

    }
}