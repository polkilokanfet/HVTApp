using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Price;
using HVTApp.Model.Wrapper;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Mvvm;
using static HVTApp.UI.Modules.Sales.Project1.Wrappers.ProjectUnit;

namespace HVTApp.UI.Modules.Sales.Project1.Wrappers
{
    public class ProjectUnitGroup : BindableBase, IProjectUnit
    {
        public ICollection<ProjectUnit> Units { get; }

        public int Amount => Units.Count;

        #region SimpleProperties

        public double Cost
        {
            get => this.Units.First().Cost;
            set { this.Units.ForEach(projectUnit => projectUnit.Cost = value); }
        }

        public double? CostWithReserve
        {
            get => this.Units.First().CostWithReserve;
            set { this.Units.ForEach(projectUnit => projectUnit.CostWithReserve = value); }
        }

        public double CostTotal
        {
            get
            {
                return this.Units.Sum(projectUnit => projectUnit.Cost);
            }
        }

        public double? CostDelivery
        {
            get => this.Units.Where(x => x.CostDelivery.HasValue).Sum(x => x.CostDelivery.Value);
            set { this.Units.ForEach(projectUnit => projectUnit.CostDelivery = value / Amount); }
        }

        public int ProductionTerm
        {
            get => this.Units.First().ProductionTerm;
            set => this.Units.ForEach(projectUnit => projectUnit.ProductionTerm = value);
        }

        public DateTime DeliveryDateExpected
        {
            get => this.Units.First().DeliveryDateExpected;
            set => this.Units.ForEach(projectUnit => projectUnit.DeliveryDateExpected = value);
        }

        public string Comment
        {
            get => this.Units.First().Comment;
            set => this.Units.ForEach(projectUnit => projectUnit.Comment = value);
        }

        public bool IsRemoved => this.Units.First().IsRemoved;

        #endregion

        #region ComplexProperties

        public FacilityEmptyWrapper Facility
        {
            get => Units.First().Facility;
            set
            {
                Units.ForEach(projectUnit => projectUnit.Facility = value);
                RaisePropertyChanged();
            }
        }

        public ProductEmptyWrapper Product
        {
            get => Units.First().Product;
            set
            {
                Units.ForEach(projectUnit => projectUnit.Product = value);
                RaisePropertyChanged();
            }
        }

        public PaymentConditionSetEmptyWrapper PaymentConditionSet
        {
            get => Units.First().PaymentConditionSet;
            set
            {
                Units.ForEach(projectUnit => projectUnit.PaymentConditionSet = value);
                RaisePropertyChanged();
            }
        }

        public CompanyEmptyWrapper Producer
        {
            get => Units.First().Producer;
            set
            {
                Units.ForEach(projectUnit => projectUnit.Producer = value);
                RaisePropertyChanged();
            }
        }

        #endregion

        public Project Project
        {
            get => this.Units.First().Project;
            set
            {
                this.Units.ForEach(unit => unit.Project = value);
            }
        }

        public Specification Specification => Units.First().Specification;

        public IEnumerable<ProjectUnitProductIncludedGroup> ProductsIncludedGroups =>
            this.Units
                .SelectMany(x => x.ProductsIncluded)
                .GroupBy(x => x, new ProjectUnitProductIncluded.ProjectUnitProductIncludedComparer())
                .Select(x => new ProjectUnitProductIncludedGroup(x));

        public ProjectUnitProductIncludedGroup SelectedProductsIncludedGroup { get; set; }

        public Price Price => GlobalAppProperties.PriceService.GetPrice(this.Units.Select(unit => unit.Model), Units.First().Model.RealizationDateCalculated, true);
        public ProjectUnitCalculatedParts CalculatedParts { get; }

        public IEnumerable<Price> Prices => new List<Price> { this.Price };

        public ProjectUnitGroup(IEnumerable<ProjectUnit> projectUnits)
        {
            var units = new ValidatableChangeTrackingCollection<ProjectUnit>(projectUnits);
            CalculatedParts = new ProjectUnitCalculatedParts(this);

            units.CollectionChanged += (sender, args) =>
            {
                RaisePropertyChanged(nameof(Amount));
            };

            foreach (var unit in units)
            {
                unit.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == nameof(Cost))
                    {
                        RaisePropertyChanged(nameof(Cost));
                        RaisePropertyChanged(nameof(CostTotal));
                        RaisePropertyChanged(nameof(CalculatedParts));
                    }
                    else if (args.PropertyName == nameof(CostWithReserve))
                    {
                        RaisePropertyChanged(nameof(CostWithReserve));
                        RaisePropertyChanged(nameof(CalculatedParts));
                    }
                    else if (args.PropertyName == nameof(CostDelivery))
                    {
                        RaisePropertyChanged(nameof(CostDelivery));
                        RaisePropertyChanged(nameof(CalculatedParts));
                    }
                    else if (args.PropertyName == nameof(Comment))
                    {
                        RaisePropertyChanged(nameof(Comment));
                    }
                    else if (args.PropertyName == nameof(ProductionTerm))
                    {
                        RaisePropertyChanged(nameof(ProductionTerm));
                    }
                    else if (args.PropertyName == nameof(DeliveryDateExpected))
                    {
                        RaisePropertyChanged(nameof(DeliveryDateExpected));
                        RaisePropertyChanged(nameof(CalculatedParts));
                        RaisePropertyChanged(nameof(Prices));
                    }
                    else if (args.PropertyName == nameof(Product))
                    {
                        RaisePropertyChanged(nameof(Product));
                        RaisePropertyChanged(nameof(CalculatedParts));
                        RaisePropertyChanged(nameof(Prices));
                    }
                };

                unit.ProductsIncluded.CollectionChanged += (sender, args) =>
                {
                    RaisePropertyChanged(nameof(CalculatedParts));
                    RaisePropertyChanged(nameof(Prices));
                    RaisePropertyChanged(nameof(ProductsIncludedGroups));
                };
            }

            Units = units;
        }

        public bool Add(ProjectUnit projectUnit)
        {
            //если эта группа не подходит для добавляемой сущности
            if ((new ProjectUnitComparer()).Equals(this.Units.First(), projectUnit) == false) 
                return false;
            
            this.Units.Add(projectUnit);
            return true;
        }

        public bool IsValid => this.Units.All(projectUnit => projectUnit.IsValid);
    }
}