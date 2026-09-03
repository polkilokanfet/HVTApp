using System;
using System.Threading.Tasks;

namespace HVTApp.Infrastructure
{
    public interface INotificationServiceClient
    {
        Task StartAsync();
        Task ShowNotification(NotificationHvtApp notification);
        Task SendNotificationToHub(NotificationHvtApp notification);
    }

    public class NotificationHvtApp
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
    }
}
