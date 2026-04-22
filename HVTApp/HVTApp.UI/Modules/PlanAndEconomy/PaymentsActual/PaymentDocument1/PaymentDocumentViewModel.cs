using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using HVTApp.DataAccess;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace HVTApp.UI.Modules.PlanAndEconomy.PaymentsActual
{
    public class PaymentDocumentViewModel : ViewModelBase
    {
        #region Fields

        private PaymentActualWrapper2 _selectedPayment;
        private object[] _selectedPotentialUnits;
        private PaymentDocumentWrapper1 _paymentDocumentWrapper;

        #endregion

        #region Props

        public PaymentDocumentWrapper1 Item
        {
            get => _paymentDocumentWrapper;
            private set => SetProperty(ref _paymentDocumentWrapper, value, () =>
            {
                RestPaymentCommand.RaiseCanExecuteChanged();
                _paymentDocumentWrapper.PropertyChanged += (sender, args) =>
                {
                    SaveCommand.RaiseCanExecuteChanged();
                    RestPaymentCommand.RaiseCanExecuteChanged();
                };

                _paymentDocumentWrapper.Payments.CollectionChanged += (sender, args) =>
                {
                    RestPaymentCommand.RaiseCanExecuteChanged();
                };
            });
        }

        /// <summary>
        /// Потенциальные платежи
        /// </summary>
        public ObservableCollection<SalesUnit> Potential { get; } = new ObservableCollection<SalesUnit>();

        /// <summary>
        /// Выбранные потенциальные юниты
        /// </summary>
        public object[] SelectedPotentialUnits
        {
            get => _selectedPotentialUnits;
            set
            {
                _selectedPotentialUnits = value;
                AddPaymentCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Выбранный платеж
        /// </summary>
        public PaymentActualWrapper2 SelectedPayment
        {
            get => _selectedPayment;
            set
            {
                _selectedPayment = value;
                RemovePaymentCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public string OrderNumberFilter { get; set; }

        #endregion

        #region ICommand

        /// <summary>
        /// Команда добавления платежа
        /// </summary>
        public AddPaymentCommand AddPaymentCommand { get; }

        /// <summary>
        /// Команда удаления платежа
        /// </summary>
        public RemovePaymentCommand RemovePaymentCommand { get; }

        /// <summary>
        /// Команда удаления платежки
        /// </summary>
        public ICommand RemoveDocumentCommand { get; }

        /// <summary>
        /// Команда оплаты остатка
        /// </summary>
        public RestPaymentCommand RestPaymentCommand { get; }

        public ICommand LoadPotentialCommand { get; }

        public DelegateLogCommand SaveCommand { get; }

        #endregion

        public PaymentDocumentViewModel(IUnityContainer container) : base(container)
        {
            AddPaymentCommand = new AddPaymentCommand(this, container);
            RemovePaymentCommand = new RemovePaymentCommand(this, container);
            RemoveDocumentCommand = new DelegateLogConfirmationCommand(
                container.Resolve<IMessageService>(),
                () =>
                {
                    this.Item.RejectChanges();

                    foreach (var paymentActualWrapper2 in this.Item.Payments.ToList())
                    {
                        this.Item.Payments.Remove(paymentActualWrapper2);
                        this.UnitOfWork.Repository<PaymentActual>().Delete(paymentActualWrapper2.Model);
                    }

                    this.UnitOfWork.Repository<PaymentDocument>().Delete(this.Item.Model);
                    this.UnitOfWork.SaveChanges();

                    this.GoBackCommand.Execute(null);
                },
                () => this.UnitOfWork.Repository<PaymentDocument>().GetById(this.Item.Model.Id) != null);
            RestPaymentCommand = new RestPaymentCommand(this, this.Container);

            LoadPotentialCommand = new DelegateLogCommand(
                () =>
                {
                    //формируем список потенциального оборудования 
                    //(исключая то, что в выбранном платеже и полностью оплачено)
                    Potential.Clear();
                    Potential.AddRange(((ISalesUnitRepository)UnitOfWork.Repository<SalesUnit>()).GetAllForPaymentDocument(OrderNumberFilter)
                        .Except(Item.Payments.Select(payment => payment.Model.SalesUnit))
                        .Where(salesUnit => salesUnit.IsPaid == false)
                        .OrderBy(salesUnit => salesUnit.Facility.ToString())
                        .ThenBy(salesUnit => salesUnit.Project.Name)
                        .ThenBy(salesUnit => salesUnit.Product.ToString())
                        .ThenBy(salesUnit => salesUnit.Cost));
                    SelectedPotentialUnits = null;

                    if (Potential.Any() == false)
                        container.Resolve<IMessageService>().Message("Уведомление", "Вашим критериям не соответствует ни одна строка.");
                });

            SaveCommand = new DelegateLogCommand(
                () =>
                {
                    var paymentsRemoved = this.Item.Payments
                        .RemovedItems
                        .Select(x => x.Model);

                    UnitOfWork.Repository<PaymentActual>().DeleteRange(paymentsRemoved);

                    if (UnitOfWork.SaveChanges().OperationCompletedSuccessfully)
                    {
                        Item.AcceptChanges();

                        this.Container.Resolve<IEventAggregator>()
                            .GetEvent<AfterSaveActualPaymentDocumentEvent>()
                            .Publish(this.Item.Model);

                        SaveCommand.RaiseCanExecuteChanged();
                    }
                },
                () => 
                    this.Item.IsValid &&
                    this.Item.IsChanged);
        }

        public void Load(PaymentDocument paymentDocument)
        {
            var pd = paymentDocument == null
                ? new PaymentDocument()
                : UnitOfWork.Repository<PaymentDocument>().GetById(paymentDocument.Id);
            this.Item = new PaymentDocumentWrapper1(pd);
        }
    }

}