using System.Threading.Tasks;

namespace HVTApp.Infrastructure
{
    public interface INotificationServiceClient
    {
        Task StartAsync();
        Task ShowNotification(string message);
        Task SendNotificationToHub(string message);
    }
}
