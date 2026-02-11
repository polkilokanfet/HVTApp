using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.ViewModels;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Model.Wrapper.Base.TrackingCollections;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.Modules.PlanAndEconomy.Supervision
{
    public class SupervisionViewModel : LoadableExportableViewModel
    {
        private object[] _selectedUnits;

        public IValidatableChangeTrackingCollection<SupervisionWr> Units { get; } = new ValidatableChangeTrackingCollection<SupervisionWr>(new List<SupervisionWr>());

        public object[] SelectedUnits
        {
            get => _selectedUnits;
            set
            {
                _selectedUnits = value;
                PrintLetterCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public DelegateLogCommand SaveCommand { get; }

        public DelegateLogCommand PrintLetterCommand { get; }

        public string SupervisionContractNumber
        {
            get => Properties.Settings.Default.SupervisionContractNumber;
            set
            {
                Properties.Settings.Default.SupervisionContractNumber = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged();
            }
        }

        public DateTime SupervisionContractDate
        {
            get => Properties.Settings.Default.SupervisionContractDate;
            set
            {
                Properties.Settings.Default.SupervisionContractDate = value;
                Properties.Settings.Default.Save();
                RaisePropertyChanged();
            }
        }

        public SupervisionViewModel(IUnityContainer container) : base(container)
        {
            var fileManagerService = container.Resolve<IFileManagerService>();

            SaveCommand = new DelegateLogCommand(
                () =>
                {
                    foreach (var supervisionWr in Units.Where(x => x.IsNew && x.IsValid && x.IsChanged).ToList())
                    {
                        var supervision = UnitOfWork.Repository<Model.POCOs.Supervision>()
                            .Find(supervision1 => supervision1.SalesUnit.Id == supervisionWr.Model.SalesUnit.Id)
                            .SingleOrDefault();

                        if (supervision == null)
                        {
                            if (UnitOfWork.Repository<Model.POCOs.Supervision>().Add(supervisionWr.Model).OperationCompletedSuccessfully == false)
                            {
                                return;
                            }
                            supervisionWr.IsNew = false;
                        }
                        //если кто-то раньше сохранил
                        else
                        {
                            var supervisionWr2 = new SupervisionWr(supervision);

                            if (supervisionWr.DateFinishIsChanged)
                                supervisionWr2.DateFinish = supervisionWr.DateFinish;

                            if (supervisionWr.DateRequiredIsChanged)
                                supervisionWr2.DateRequired = supervisionWr.DateRequired;

                            if (supervisionWr.ServiceOrderNumberIsChanged)
                                supervisionWr2.ServiceOrderNumber = supervisionWr.ServiceOrderNumber;

                            if (supervisionWr.ClientOrderNumberIsChanged)
                                supervisionWr2.ClientOrderNumber = supervisionWr.ClientOrderNumber;

                            Units.Remove(supervisionWr);
                            Units.Add(supervisionWr2);
                        }

                    }

                    if (UnitOfWork.SaveChanges().OperationCompletedSuccessfully)
                    {
                        Units.AcceptChanges();
                    }
                }, 
                () => Units.IsValid && Units.IsChanged);

            PrintLetterCommand = new DelegateLogCommand(
                () =>
                {
                    var unitOfWork = Container.Resolve<IUnitOfWork>();
                    var supervisions = SelectedUnits
                        .Cast<SupervisionWr>()
                        .Select(x => x.Model)
                        .OrderBy(supervision => supervision.SalesUnit.SerialNumber)
                        .ToList();

                    var letter = new Document
                    {
                        Number = new DocumentNumber(),
                        Date = DateTime.Today,
                        Comment = $"О шеф-монтаже на объектах: {supervisions.Select(supervision => supervision.SalesUnit.Facility).Distinct().ToStringEnum(", ")}".GetFirstSimbols(150),
                        Author = unitOfWork.Repository<User>().GetById(GlobalAppProperties.User.Id).Employee,
                        SenderEmployee = unitOfWork.Repository<Employee>().GetById(GlobalAppProperties.Actual.SenderOfferEmployee.Id),
                        RecipientEmployee = unitOfWork.Repository<Employee>().GetById(GlobalAppProperties.Actual.RecipientSupervisionLetterEmployee.Id)
                    };

                    if (unitOfWork.SaveEntity(letter).OperationCompletedSuccessfully)
                    {
                        Container.Resolve<IPrintSupervisionLetterService>()
                            .PrintSupervisionLetter(
                                SelectedUnits.Cast<SupervisionWr>().Select(x => x.Model), 
                                SupervisionContractNumber,
                                SupervisionContractDate,
                                letter, 
                                fileManagerService.GetLettersDefaultStoragePath());
                    }

                },
                () => SelectedUnits != null && SelectedUnits.Any());

            Units.PropertyChanged += (sender, args) =>
            {
                SaveCommand.RaiseCanExecuteChanged();
            };
        }

        protected List<SupervisionWr> Wrappers;
        protected override void GetData()
        {
            UnitOfWork = Container.Resolve<IUnitOfWork>();

            //шеф-монтажи (сохраненные)
            var supervisions = UnitOfWork.Repository<Model.POCOs.Supervision>().GetAll();
            Wrappers = supervisions.Select(supervision => new SupervisionWr(supervision)).ToList();

            //выигранное оборудование со включенным шеф-монтажом
            var salesUnits = UnitOfWork.Repository<SalesUnit>()
                    .Find(x => !x.IsRemoved && x.IsWon) //только выигранное оборудование
                    .Except(supervisions.Select(x => x.SalesUnit)) //еще не сохраненное
                    .Where(x => x.ProductsIncluded.Any(pi => pi.Product.ProductBlock.IsSupervision)); //в которое включен шеф-монтаж

            Wrappers.AddRange(salesUnits.Select(x => new SupervisionWr(x)));
        }

        protected override void AfterGetData()
        {
            Units.Clear();

            Units.AddRange(Wrappers.OrderBy(x => x.DateFinish).ThenBy(x => x.Model.SalesUnit.OrderInTakeDate));
            Units.AcceptChanges();
        }
    }
}