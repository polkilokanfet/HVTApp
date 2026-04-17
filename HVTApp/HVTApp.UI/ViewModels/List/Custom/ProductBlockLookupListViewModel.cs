using System.Collections.Generic;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services.SelectService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.UI.Commands;
using HVTApp.UI.Lookup;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.ViewModels
{
    public partial class PriceEngineeringTaskLookupListViewModel
    {

    }
    public partial class ProductBlockLookupListViewModel
    {
        private class PricesByQuarter
        {
            public int Year { get; }
            public int Quarter { get; }
            public int QuarterAbsolute { get; }
            public List<SumOnDate> SumOnDates { get; }

            public double? Average => SumOnDates.Any()
                ? SumOnDates.Select(x => x.Sum).Average()
                : default;

            public PricesByQuarter( IEnumerable<SumOnDate> sumOnDates)
            {
                SumOnDates = sumOnDates.ToList();
                Year = SumOnDates.First().Date.Year;
                Quarter = SumOnDates.First().Date.Quarter();
                QuarterAbsolute = SumOnDates.First().Date.QuarterAbsolute();
            }

            public override string ToString()
            {
                return $"{Average:C} на {Quarter} кв. {Year} г.";
            }
        }
        public DelegateLogCommand AddParameterCommand { get; private set; }
        public DelegateLogCommand CheckPricesCommand { get; private set; }
        public DelegateLogCommand DesignationRefreshCommand { get; private set; }

        protected override void InitSpecialCommands()
        {
            AddParameterCommand = new DelegateLogCommand(
                () =>
                {
                    var unitOfWork = Container.Resolve<IUnitOfWork>();
                    var parameter = Container.Resolve<ISelectService>().SelectItem(unitOfWork.Repository<Parameter>().GetAll());
                    if (parameter != null)
                    {
                        foreach (var block in SelectedItems)
                        {
                            var productBlock = unitOfWork.Repository<ProductBlock>().GetById(block.Id);
                            productBlock.Parameters.Add(parameter);
                            var lookup = Lookups.Single(x => x.Id == block.Id);
                            lookup.Refresh(block);
                        }

                        unitOfWork.SaveChanges();
                    }
                },
                () => SelectedItems != null && SelectedItems.Any());

            CheckPricesCommand = new DelegateLogCommand(
                () =>
                {
                    var messageService = Container.Resolve<IMessageService>();
                    using (var unitOfWork = Container.Resolve<IUnitOfWork>())
                    {
                        foreach (var selectedItem in SelectedItems)
                        {
                            var productBlock = unitOfWork.Repository<ProductBlock>().GetById(selectedItem.Id);
                            if (productBlock.Prices.Any() == false) continue;

                            var pricesByQuarterList = productBlock
                                .Prices
                                .GroupBy(x => x.Date.QuarterAbsolute())
                                .Select(x => new PricesByQuarter(x))
                                .OrderBy(x => x.QuarterAbsolute)
                                .ToList();

                            var all = pricesByQuarterList
                                .SelectMany(x => x.SumOnDates)
                                .OrderBy(x => x.Date)
                                .ToStringEnum();

                            foreach (var pricesByQuarter in pricesByQuarterList.ToList())
                            {
                                //среднее значение в этом квартале
                                var averageQuarter = pricesByQuarter.Average;
                                var averageLastQuarter = pricesByQuarterList.FirstOrDefault(x => (x.QuarterAbsolute - 1) == pricesByQuarter.QuarterAbsolute)?.Average;
                                var averageYear = pricesByQuarterList.Where(x => x.Year == pricesByQuarter.Year).Select(x => x.Average).Average();
                                var averageLastYear = pricesByQuarterList.Where(x => x.Year - 1 == pricesByQuarter.Year).Select(x => x.Average).Average();
                                foreach (var sumOnDate in pricesByQuarter.SumOnDates.ToList())
                                {
                                    if ((sumOnDate.Sum * 0.5) > averageQuarter ||
                                        (averageLastQuarter.HasValue && (sumOnDate.Sum * 0.5) > averageLastQuarter) ||
                                        (sumOnDate.Sum * 0.5) > averageYear ||
                                        (averageLastYear.HasValue && (sumOnDate.Sum * 0.5) > averageLastYear))
                                    {
                                        var sb = new StringBuilder();
                                        sb.AppendLine(productBlock.Designation);
                                        sb.AppendLine($"{pricesByQuarter.Quarter} квартал {sumOnDate.Date.Year}");
                                        sb.AppendLine($"подозрительное: {sumOnDate}");
                                        sb.AppendLine($"среднее в текущем году: {averageLastYear:C}");
                                        sb.AppendLine($"среднее в текущем квартале: {averageQuarter:C}");
                                        sb.AppendLine($"среднее в прошлом квартале: {averageLastQuarter:C}");
                                        sb.AppendLine($"среднее по кварталам: {pricesByQuarterList.ToStringEnum()}");
                                        sb.AppendLine($"все прайсы: {all}");
                                        sb.AppendLine("Удалить подозрительное значение?");
                                        var dr = messageService.ConfirmationDialog(sb.ToString());
                                        if (dr)
                                        {
                                            pricesByQuarter.SumOnDates.Remove(sumOnDate);
                                            if (pricesByQuarter.SumOnDates.Any() == false)
                                                pricesByQuarterList.Remove(pricesByQuarter);
                                            productBlock.Prices.Remove(sumOnDate);
                                            unitOfWork.Repository<SumOnDate>().Delete(sumOnDate);
                                        }
                                    }
                                }
                            }
                            
                        }

                        unitOfWork.SaveChanges();
                    }

                    messageService.Message("done", "done");
                },
                () => SelectedItems != null && SelectedItems.Any());

            DesignationRefreshCommand = new DelegateLogCommand(
                () =>
                {
                    var sb = new StringBuilder();

                    using (var unitOfWork = Container.Resolve<IUnitOfWork>())
                    {

                        var productBlocks = unitOfWork.Repository<ProductBlock>().GetAll();
                        foreach (var block in productBlocks)
                        {
                            var designation = block.Designation;
                            var designationSpecial = block.DesignationSpecial;

                            if (designation.Length > 256)
                                continue;

                            if (designation != designationSpecial)
                            {
                                sb.AppendLine($"{designationSpecial} => {designation}");
                                block.DesignationSpecial = designation;
                            }
                        }

                        unitOfWork.SaveChanges();
                    }

                    Container.Resolve<IMessageService>().Message("done", sb.ToString());
                });

            this.SelectedLookupChanged += lookup =>
            {
                AddParameterCommand.RaiseCanExecuteChanged();
                CheckPricesCommand.RaiseCanExecuteChanged();
            };
        }

        public override void Load()
        {
            base.Load();

            var designDepartments = UnitOfWork.Repository<DesignDepartment>().GetAll();

            foreach (var productBlockLookup in this.Lookups)
            {
                var dd = designDepartments
                    .Where(x => x.ParameterSets.Any(p => p.Parameters.AllContainsInById(productBlockLookup.Entity.Parameters)))
                    .ToList();
                if (dd.Any())
                {
                    productBlockLookup.DesignDepartments = dd.ToStringEnum();
                }
            }
        }
    }

    public partial class ParameterGroupLookupListViewModel
    {
        public override IEnumerable<ParameterGroupLookup> GetAllLookups()
        {
            return UnitOfWork.Repository<ParameterGroup>()
                .GetAllAsNoTracking()
                .OrderBy(x => x)
                .Select(x => new ParameterGroupLookup(x));
        }
    }
}