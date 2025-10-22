using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base.TrackingCollections;

namespace HVTApp.UI.Modules.Sales.Project1.Wrappers
{
    public class ProjectUnitGroupsContainer : ValidatableChangeTrackingCollection<ProjectUnit>
    {
        public IEnumerable<ProjectUnitGroup> Groups { get; }

        /// <summary>
        /// Стоимость всего проекта
        /// </summary>
        public double Cost
        {
            get { return this.Sum(projectUnit => projectUnit.Cost); }
            set
            {
                //распределение суммы по всем юнитам равномерно

                var projectUnits = this.ToList();
                if (value <= 0) return;
                if (projectUnits.Any() == false) return;

                var totalWithout = value
                                   - projectUnits.Sum(x => x.Price.SumFixedTotal)
                                   - projectUnits.Sum(x => x.CostDelivery ?? 0);

                if (totalWithout <= 0) return;

                var priceTotal = projectUnits.Sum(x => x.Price.SumPriceTotal);

                foreach (var projectUnit in projectUnits)
                {
                    double deliveryCost = projectUnit.CostDelivery ?? 0;
                    projectUnit.Cost = projectUnit.Price.SumFixedTotal + deliveryCost + totalWithout * (projectUnit.Price.SumPriceTotal) / priceTotal;
                }
            }
        }

        public ProjectUnitGroupsContainer(IEnumerable<SalesUnit> salesUnits) : base(salesUnits.Select(salesUnit => new ProjectUnit(salesUnit)))
        {
            var groups = this
                .GroupBy(projectUnit => projectUnit, new ProjectUnit.ProjectUnitComparer())
                .Select(projectUnits => new ProjectUnitGroup(projectUnits))
                .OrderByDescending(x => x.Cost);
            this.Groups = new ObservableCollection<ProjectUnitGroup>(groups);

            this.CollectionChanged += (sender, args) =>
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Cost)));
            };

            foreach (var pu in this)
            {
                pu.PropertyChanged += PuOnPropertyChanged; 
            }
        }

        private void PuOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(ProjectUnit.Cost)) return;
            this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Cost)));
        }

        public new void Add(ProjectUnit projectUnit)
        {
            if (this.Groups.Any(projectUnitGroup => projectUnitGroup.Add(projectUnit)) == false)
                ((ObservableCollection<ProjectUnitGroup>)this.Groups).Add(new ProjectUnitGroup(new [] { projectUnit }));

            base.Add(projectUnit);
            projectUnit.PropertyChanged += PuOnPropertyChanged;
        }

        public new void Remove(ProjectUnit projectUnit)
        {
            var projectUnitGroup = Groups.Single(group => group.Units.Contains(projectUnit));
            projectUnitGroup.Units.Remove(projectUnit);
            if (projectUnitGroup.Units.Count == 0)
                ((ObservableCollection<ProjectUnitGroup>)Groups).Remove(projectUnitGroup);
            projectUnit.PropertyChanged -= PuOnPropertyChanged;

            base.Remove(projectUnit);
        }
    }
}