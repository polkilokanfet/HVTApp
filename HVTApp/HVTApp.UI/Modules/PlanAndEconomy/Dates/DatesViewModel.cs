using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using HVTApp.DataAccess;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Infrastructure.ViewModels;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using HVTApp.UI.Commands;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using EnumerableExtensions = HVTApp.Infrastructure.Extensions.EnumerableExtensions;

namespace HVTApp.UI.Modules.PlanAndEconomy.Dates
{
    public class DatesViewModel : LoadableExportableViewModel
    {
        private IUnitOfWork _unitOfWork;
        private IValidatableChangeTrackingCollection<DatesUnitViewModel> _salesUnits;

        public ObservableCollection<DatesGroupViewModel> Groups { get; } = new ObservableCollection<DatesGroupViewModel>();

        public DelegateLogCommand SaveCommand { get; }
        public DelegateLogCommand LoadPickingDatesCommand { get; }

        public bool AutoFillingDates { get; set; } = true;

        public DatesViewModel(IUnityContainer container) : base(container)
        {
            SaveCommand = new DelegateLogCommand(
                () =>
                {
                    _salesUnits.PropertyChanged -= SalesUnitsOnPropertyChanged;

                    //сохран€ем изменени€
                    if (_unitOfWork.SaveChanges().OperationCompletedSuccessfully)
                    {
                        //принимаем все изменени€
                        _salesUnits.AcceptChanges();
                    }
                    //провер€ем актуальность команды
                    SaveCommand.RaiseCanExecuteChanged();

                    _salesUnits.PropertyChanged += SalesUnitsOnPropertyChanged;
                },
                () => _salesUnits != null &&
                      _salesUnits.IsValid &&
                      _salesUnits.IsChanged);

            LoadPickingDatesCommand = new DelegateLogCommand(
                () =>
                {
                    try
                    {
                        var path = container.Resolve<IGetFilePaths>().GetFilePath();
                        if (string.IsNullOrEmpty(path)) return;

                        var dic = container.Resolve<IGetInformationFromExcelFileService>().GetPickingDatesFromFile(path);

                        var sb = new StringBuilder();

                        var targetGroups = this.Groups.Where(x => string.IsNullOrWhiteSpace(x.Model.Order?.Number) == false).ToList();

                        foreach (var m1 in dic)
                        {
                            foreach (var datesGroup in targetGroups.Where(x => x.Model.Order.Number.Trim() == m1.Key))
                            {
                                var targetUnits = datesGroup.Units.Where(x =>
                                    x.Model.RealizationDate == null &&
                                    x.Model.EndProductionDate == null &&
                                    string.IsNullOrWhiteSpace(x.Model.OrderPosition) == false &&
                                    int.TryParse(x.Model.OrderPosition.Trim(), out _)).ToList();

                                foreach (var unit in targetUnits)
                                {
                                    var position = int.Parse(unit.Model.OrderPosition.Trim());
                                    if (m1.Value.ContainsKey(position) == false) continue;

                                    var pickingDate = m1.Value[position];
                                    if (pickingDate.Equals(unit.PickingDate) == false)
                                    {
                                        sb.AppendLine($"{unit.Model.Order} поз. {unit.Model.OrderPosition}: {unit.PickingDate?.ToLongDateString()} => {pickingDate.ToLongDateString()} :: {unit.Model.Product.Category}");
                                        unit.PickingDate = pickingDate;
                                    }
                                }
                            }
                        }

                        var dr = container.Resolve<IMessageService>().ConfirmationDialog("ѕрименить изменени€?", sb.ToString(), defaultYes:true);
                        if (dr == false)
                            EnumerableExtensions.ForEach(this.Groups.SelectMany(x => x.Units).Where(x => x.IsChanged), x => x.RejectChanges());
                    }
                    catch (Exception e)
                    {
                        container.Resolve<IMessageService>().Message("error", e.PrintAllExceptions());
                    }
                });
        }

        private IOrderedEnumerable<DatesGroupViewModel> _groups;

        protected override void GetData()
        {
            _unitOfWork = Container.Resolve<IUnitOfWork>();

            var salesUnits = ((ISalesUnitRepository)_unitOfWork.Repository<SalesUnit>()).GetForDatesView()
                .Where(salesUnit => salesUnit.Order != null || salesUnit.OrderInTakeDate <= DateTime.Today)
                .OrderBy(salesUnit => salesUnit.EndProductionDateCalculated)
                .Select(salesUnit => new DatesUnitViewModel(salesUnit))
                .ToList();
            _salesUnits = new ValidatableChangeTrackingCollection<DatesUnitViewModel>(salesUnits);

            //подписываемс€ на изменение каждой сущности
            _salesUnits.PropertyChanged += SalesUnitsOnPropertyChanged;

            _groups = _salesUnits
                .GroupBy(salesUnitDates => new
                {
                    Cost = salesUnitDates.Model.Cost,
                    Facility = salesUnitDates.Model.Facility.Id,
                    Product = salesUnitDates.Model.Product.Id,
                    Order = salesUnitDates.Model.Order?.Id,
                    Project = salesUnitDates.Model.Project.Id,
                    Specification = salesUnitDates.Model.Specification?.Id,
                    salesUnitDates.DeliveryDate,
                    salesUnitDates.EndProductionDate,
                    salesUnitDates.PickingDate,
                    salesUnitDates.RealizationDate,
                    salesUnitDates.ShipmentDate
                })
                .Select(x => new DatesGroupViewModel(x))
                .OrderBy(x => x.Units.First().Model.OrderInTakeDate);
        }

        protected override void AfterGetData()
        {
            Microsoft.Practices.ObjectBuilder2.EnumerableExtensions.ForEach(Groups.SelectMany(x => x.Units), x => x.PropertyChanged -= UnitOnPropertyChanged);
            Groups.Clear();
            Groups.AddRange(_groups);
            Microsoft.Practices.ObjectBuilder2.EnumerableExtensions.ForEach(Groups.SelectMany(x => x.Units), x => x.PropertyChanged += UnitOnPropertyChanged);
        }

        private void UnitOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (AutoFillingDates && args.PropertyName == nameof(DatesUnitViewModel.ShipmentDate))
                ((DatesUnitViewModel)sender).SetCalculatedDates();
        }

        private void SalesUnitsOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
}