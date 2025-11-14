using System;
using System.Linq;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.ObjectBuilder2;

namespace HVTApp.UI.PriceEngineering.Tce.Second
{
    public class ProductBlockAddedWrapper : WrapperBase<PriceEngineeringTaskProductBlockAdded>
    {
        /// <summary>
        /// Версии SCC
        /// </summary>
        public IValidatableChangeTrackingCollection<SccVersionWrapper> StructureCostVersions { get; private set; }

        public ProductBlockAddedWrapper(PriceEngineeringTaskProductBlockAdded model, string constructor, string department) : base(model)
        {
            var originalStructureCostNumber = this.Model.ProductBlock.StructureCostNumber;

            //если нет актуального scc, добавляем его
            if (model.IsRemoved == false &&
                this.StructureCostVersions.Any(x => x.OriginalStructureCostNumber == originalStructureCostNumber) == false)
            {
                var scc = new SccVersionWrapper(new StructureCostVersion(), this.Model.ProductBlock.ToString(), true);
                this.StructureCostVersions.Add(scc);
                scc.OriginalStructureCostNumber = originalStructureCostNumber;
                StructureCostVersions.AcceptChanges();
            }

            this.StructureCostVersions.ForEach(x =>
            {
                x.Constructor = constructor;
                x.Department = department;
            });
        }

        protected override void InitializeCollectionProperties()
        {
            if (Model.StructureCostVersions == null) throw new ArgumentException("StructureCostVersions cannot be null");
            var originalStructureCostNumber = this.Model.ProductBlock.StructureCostNumber;
            var structureCostName = this.Model.ProductBlock.ToString();
            StructureCostVersions = new ValidatableChangeTrackingCollection<SccVersionWrapper>(Model.StructureCostVersions.Select(x => new SccVersionWrapper(x, structureCostName, originalStructureCostNumber == x.OriginalStructureCostNumber && Model.IsRemoved == false)));
            RegisterCollection(StructureCostVersions, Model.StructureCostVersions);
        }
    }
}