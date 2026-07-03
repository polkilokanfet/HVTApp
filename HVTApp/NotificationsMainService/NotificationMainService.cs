using System;
using System.Threading.Tasks;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Interfaces.Services;
using HVTApp.Infrastructure.Interfaces.Services.EventService;
using HVTApp.Infrastructure.Services;
using HVTApp.Model.Events.EventServiceEvents;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace NotificationsMainService
{
    public class NotificationMainService : INotificationMainService, IDisposable
    {
        public IEventServiceClient EventServiceClient { get; }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private readonly ISendNotificationThroughApp _sendNotificationThroughApp;
        private readonly INotificationGeneratorService _notificationGeneratorService;
        private readonly INotificationFromDataBaseService _notificationFromDataBaseService;
        private readonly INotificationUnitWatcher _notificationUnitWatcher;
        private readonly IEmailService _emailService;

        public NotificationMainService(IUnityContainer container)
        {
            _unitOfWork = container.Resolve<IUnitOfWork>();
            _eventAggregator = container.Resolve<IEventAggregator>();
            _sendNotificationThroughApp = container.Resolve<ISendNotificationThroughApp>();
            _notificationGeneratorService = container.Resolve<INotificationGeneratorService>();
            _notificationFromDataBaseService = container.Resolve<INotificationFromDataBaseService>();
            _notificationUnitWatcher = container.Resolve<INotificationUnitWatcher>();
            _emailService = container.Resolve<IEmailService>();
            EventServiceClient = container.Resolve<IEventServiceClient>();
        }

        public void Start()
        {
            _notificationUnitWatcher.Start();

            this.EventServiceClient.StartEvent += EventServiceClientOnStartEvent;

            EventServiceClient.Start();

            //подписка на уведомления о событиях в ТСП
            _eventAggregator.GetEvent<NotificationEvent>().Subscribe(OnNotificationEvent, true);
        }

        private void EventServiceClientOnStartEvent()
        {
            //при старте сервиса синхронизации необходимо проверить уведомления из базы данных
            Task.Run(() => _notificationFromDataBaseService.CheckMessagesInDbAndShowNotifications()).Await();
        }

        #region OnPriceEngineeringTaskNotificationEvent

        private async void OnNotificationEvent(NotificationUnit notification)
        {
            //сохраняем уведомление в базе данных
            _notificationFromDataBaseService.SaveNotificationInDataBase(notification);

            if (await _sendNotificationThroughApp.SendNotificationAsync(notification))
                //удаляем уведомление в базе данных
                _notificationFromDataBaseService.RemoveNotificationFromDataBase(notification);
        }

        #endregion

        //#region OnAfterSavePaymentDocumentEvent

        //private void OnAfterSavePaymentDocumentEvent(PaymentDocument paymentDocument)
        //{
        //    if (paymentDocument.Payments.Any() == false) return;

        //    var salesUnits = new List<SalesUnit>();
        //    paymentDocument.Payments
        //        .ForEach(paymentActual => salesUnits.Add(_unitOfWork.Repository<SalesUnit>().GetById(paymentActual.SalesUnitId)));

        //    var manager = salesUnits.First().Project.Manager;
        //    var email = manager.Employee.Email;
        //    var subject = "[УП ВВА] Пришла денюжка!";
        //    var message = GetEmailMessageOnAfterSavePaymentDocumentEvent(paymentDocument, salesUnits);

        //    var emails = _unitOfWork.Repository<NotificationsReportsSettings>()
        //        .GetAll()
        //        .FirstOrDefault()?
        //        .SavePaymentDocumentDistributionList
        //        .Where(user => string.IsNullOrEmpty(user.Employee.Email) == false)
        //        .Select(user => user.Employee.Email)
        //        .ToList() ?? new List<string>();

        //    if (string.IsNullOrEmpty(email) == false) emails.Add(email);

        //    foreach (var email1 in emails)
        //    {
        //        Task.Run(() => _emailService.SendMail(email1, subject, message)).Await();
        //    }
        //}

        //private string GetEmailMessageOnAfterSavePaymentDocumentEvent(PaymentDocument paymentDocument, IEnumerable<SalesUnit> salesUnits)
        //{
        //    var units = salesUnits.ToList();
        //    var sb = new StringBuilder();
        //    sb.AppendLine($"Платежный документ №{paymentDocument.Number} от {paymentDocument.Date.ToShortDateString()} г.");
        //    sb.AppendLine($"Сумма с НДС: {paymentDocument.SumWithVat:N} руб.");
        //    sb.AppendLine($"Менеджер: {units.GroupBy(x => x.Project.Manager).Select(x => x.Key.Employee.Person).ToStringEnum()}");
        //    sb.AppendLine($"Контрагент: {units.Where(x => x.Specification != null).GroupBy(x => x.Specification).Select(x => x.Key.Contract.Contragent).ToStringEnum()}");
        //    sb.AppendLine($"Договор: {units.Where(x => x.Specification != null).GroupBy(x => x.Specification).Select(x => x.Key.Contract.Number).ToStringEnum()}");
        //    sb.AppendLine($"Спецификация: {units.Where(x => x.Specification != null).GroupBy(x => x.Specification).Select(x => $"{x.Key.Number} от {x.Key.Date.ToShortDateString()}").ToStringEnum()}");
        //    sb.AppendLine("За позиции:");
        //    foreach (var salesUnit in units)
        //    {
        //        sb.AppendLine($" - з/з: {salesUnit.Order?.Number}; поз.: {salesUnit.OrderPosition}; Объект: {salesUnit.Facility}; Наименование: {salesUnit.Product}");
        //    }

        //    return sb.ToString();
        //}

        //#endregion

        public void Dispose()
        {
            this.EventServiceClient.StartEvent -= EventServiceClientOnStartEvent;
            _unitOfWork.Dispose();
        }
    }
}