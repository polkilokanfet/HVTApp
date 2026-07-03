using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Enums;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.Events;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace EventServiceClient2
{
    //действия, когда прилетают события из сервера синхронизации
    public partial class EventServiceClient
    {
        public void ApplicationShutdown()
        {
            int t = 120;

            Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(
                    () =>
                    {
                        this._container.Resolve<IMessageService>().Message("Внимание", $"Приложение будет закрыто через {t} секунд для установки обновлений.\nСохраните сделанные изменения.");
                    });
            }).Await();

            Application.Current.Dispatcher.Invoke(
                () =>
                {
                    Task.Run(() => Thread.Sleep(t * 1000)).Await(() => { Application.Current.Shutdown(); });
                });
        }

        /// <summary>
        /// Реакция сервиса-клиента на остановку сервиса-сервера
        /// </summary>
        public void OnServiceDisposeEvent()
        {
            this.Stop();
        }

        public bool IsAlive()
        {
            return true;
        }

        public bool OnNotificationCallback(NotificationActionType actionType, Guid targetEntityId)
        {
            var notificationUnit = new NotificationUnit
            {
                ActionType = actionType,
                RecipientRole = GlobalAppProperties.User.RoleCurrent,
                RecipientUser = GlobalAppProperties.User,
                RecipientUserId = GlobalAppProperties.User.Id,
                TargetEntityId = targetEntityId
            };

#if DEBUG
            _notificationFromDataBaseService.ShowNotification(notificationUnit);
#else
            try
            {
                _notificationFromDataBaseService.ShowNotification(notificationUnit);
            }
            catch
            {
                return false;
            }
#endif
            return true;
        }

        public bool OnPriceEngineeringTaskSendMessageServiceCallback(Guid messageId)
        {
            //var unitOfWork = _container.Resolve<IUnitOfWork>();
            //var taskMessage = unitOfWork.Repository<PriceEngineeringTaskMessage>().GetById(messageId);

            //var message = $"{taskMessage.Message}";
            //var title = $"Сообщение от {taskMessage.Author}";
            //var priceEngineeringTask = unitOfWork.Repository<PriceEngineeringTask>()
            //    .GetById(taskMessage.PriceEngineeringTaskId);
            //_popupNotificationsService.ShowPopupNotification(priceEngineeringTask, message, title);
            ////переводим в основной поток
            //Application.Current.Dispatcher.Invoke(
            //    () =>
            //    {
            //        _container.Resolve<IEventAggregator>().GetEvent<PriceEngineeringTaskReciveMessageEvent>().Publish(taskMessage);
            //    });

            return true;
        }
    }
}