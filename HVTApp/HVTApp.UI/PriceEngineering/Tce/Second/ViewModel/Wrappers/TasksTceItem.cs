using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;

namespace HVTApp.UI.PriceEngineering.Tce.Second
{
    public class TasksTceItem : WrapperBase<PriceEngineeringTask>
    {
        #region TcePosition

        /// <summary>
        /// Позиция в ТСЕ
        /// </summary>
        public string TcePosition
        {
            get => GetValue<string>();
            set
            {
                foreach (var childTask in ChildPriceEngineeringTasks)
                {
                    childTask.TcePosition = value;
                }
                SetValue(value);
            }
        }

        public string TcePositionOriginalValue => GetOriginalValue<string>(nameof(TcePosition));
        public bool TcePositionIsChanged => GetIsChanged(nameof(TcePosition));

        #endregion

        /// <summary>
        /// Дочерние задачи
        /// </summary>
        public IValidatableChangeTrackingCollection<TasksTceItem> ChildPriceEngineeringTasks { get; private set; }

        /// <summary>
        /// Добавленные блоки продукта от инженера-конструктора
        /// </summary>
        public IValidatableChangeTrackingCollection<ProductBlockAddedWrapper> BlockAddedList { get; private set; }

        /// <summary>
        /// Версии SCC
        /// </summary>
        public IValidatableChangeTrackingCollection<SccVersionWrapper> StructureCostVersions { get; private set; }

        /// <summary>
        /// Список scc для отображения во View
        /// </summary>
        public IEnumerable<SccVersionWrapper> SccVersions
        {
            get
            {
                var sccMainTask = this.Model.ProductBlock.StructureCostNumberIsRequired
                    ? this.StructureCostVersions.ToList()
                    : new List<SccVersionWrapper>();
                var sccChildTasks = this.ChildPriceEngineeringTasks.SelectMany(x => x.SccVersions);
                var sccBlocksAdded = this.BlockAddedList.SelectMany(x => x.StructureCostVersions);

                return sccMainTask
                    .Union(sccChildTasks)
                    .Union(sccBlocksAdded)
                    .OrderBy(sccVersionWrapper => sccVersionWrapper.Name);
            }
        }

        public ICommand LoadFilesCommand { get; }

        public event Action<PriceEngineeringTask> LoadFilesRequest; 

        public TasksTceItem(PriceEngineeringTask priceEngineeringTask) : base(priceEngineeringTask)
        {
            var originalStructureCostNumber = this.Model.ProductBlock.StructureCostNumber;

            //если нет актуального scc, добавляем его
            if (this.Model.ProductBlock.StructureCostNumberIsRequired)
            {
                if (this.StructureCostVersions.Any(sccVersion => sccVersion.OriginalStructureCostNumber == originalStructureCostNumber && sccVersion.Model.PriceIncreaseFactor.Equals(this.Model.PriceIncreaseFactor)) == false)
                {
                    var scc = new SccVersionWrapper(new StructureCostVersion(), this.Model.ProductBlock.ToString(), true);
                    this.StructureCostVersions.Add(scc);
                    scc.OriginalStructureCostNumber = originalStructureCostNumber;
                    scc.PriceIncreaseFactor = this.Model.PriceIncreaseFactor;
                    StructureCostVersions.AcceptChanges();
                }
            }

            this.StructureCostVersions.ForEach(sccVersionWrapper =>
            {
                sccVersionWrapper.Constructor = this.Model.UserConstructor?.Employee.Person.ToString();
                sccVersionWrapper.Department = this.Model.DesignDepartment?.Name;
            });

            LoadFilesCommand = new DelegateCommand(() =>
            {
                LoadFilesRequest?.Invoke(this.Model);
            });
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            var sccVersionWrappers = this.SccVersions
                .Where(x => x.IsActual)
                .Where(x => x.IsValid == false);
            foreach (var sccVersionWrapper in sccVersionWrappers)
            {
                yield return new ValidationResult($"{sccVersionWrapper} has not valid items", new[] {nameof(SccVersions)});
            }

            if (string.IsNullOrWhiteSpace(this.TcePosition) && 
                this.Model.SalesUnits.Any())
            {
                yield return new ValidationResult("Позиция в ТСЕ не может быть пустой", new[] {nameof(TcePosition)});
            }
        }

        protected override void InitializeCollectionProperties()
        {
            if (Model.ChildPriceEngineeringTasks == null) throw new ArgumentException("ChildPriceEngineeringTasks cannot be null");
            ChildPriceEngineeringTasks = new ValidatableChangeTrackingCollection<TasksTceItem>(Model.ChildPriceEngineeringTasks.Select(e => new TasksTceItem(e)));
            RegisterCollection(ChildPriceEngineeringTasks, Model.ChildPriceEngineeringTasks);

            if (Model.ProductBlocksAdded == null) throw new ArgumentException("ProductBlocksAdded cannot be null");
            BlockAddedList = new ValidatableChangeTrackingCollection<ProductBlockAddedWrapper>(Model.ProductBlocksAdded.Select(e => new ProductBlockAddedWrapper(e, this.Model.UserConstructor.Employee.Person.ToString(), this.Model.DesignDepartment?.Name)));
            RegisterCollection(BlockAddedList, Model.ProductBlocksAdded);

            if (Model.StructureCostVersions == null) throw new ArgumentException("StructureCostVersions cannot be null");

            var originalStructureCostNumber = this.Model.ProductBlock.StructureCostNumber;
            var structureCostName = this.Model.ProductBlock.ToString();
            StructureCostVersions = new ValidatableChangeTrackingCollection<SccVersionWrapper>(Model.StructureCostVersions.Select(x => new SccVersionWrapper(x, structureCostName, originalStructureCostNumber == x.OriginalStructureCostNumber && x.PriceIncreaseFactor.Equals(this.Model.PriceIncreaseFactor))));
            RegisterCollection(StructureCostVersions, Model.StructureCostVersions);
        }
    }
}