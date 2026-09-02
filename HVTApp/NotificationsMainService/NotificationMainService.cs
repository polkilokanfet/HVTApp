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

            //подписка на уведомления о событиях
            _eventAggregator.GetEvent<NotificationEvent>().Subscribe(OnNotificationEvent, true);
        }

        private void EventServiceClientOnStartEvent()
        {
            //при старте сервиса синхронизации необходимо проверить уведомления из базы данных
            Task
                .Run(() => _notificationFromDataBaseService.CheckMessagesInDbAndShowNotifications())
                .Await();
        }

        #region OnPriceEngineeringTaskNotificationEvent

        private async void OnNotificationEvent(NotificationUnit notification)
        {
            try
            {
                //сохраняем уведомление в базе данных
                _notificationFromDataBaseService.SaveNotificationInDataBase(notification);

                if (await _sendNotificationThroughApp.SendNotificationAsync(notification))
                    //удаляем уведомление в базе данных
                    _notificationFromDataBaseService.RemoveNotificationFromDataBase(notification);
            }
            catch (Exception e)
            {
                // TODO handle exception
            }
        }

        #endregion

        public void Dispose()
        {
            this.EventServiceClient.StartEvent -= EventServiceClientOnStartEvent;
            _unitOfWork.Dispose();
        }
    }
}