using HVTApp.Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using HVTApp.Model;

namespace HVTApp.NotificationService1
{
    internal class NotificationService : INotificationServiceClient, IDisposable, IAsyncDisposable
    {
        private readonly HubConnection _connection;

        public NotificationService()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl($"https://localhost:7204/notificationsHub?userId={GlobalAppProperties.User.Id}&role={GlobalAppProperties.User.RoleCurrent}")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>(nameof(ShowNotification), ShowNotification);

            _connection.Closed += async (ex) =>
            {
                // Пробуем переподключиться
                await Task.Delay(2000);
                await StartAsync();
            };
        }

        public async Task StartAsync()
        {
            await _connection.StartAsync();
        }

        //private void ShowNotification(string title, string message)
        //{
        //    // Важно: колбэк SignalR приходит не из UI‑потока
        //    Application.Current.Dispatcher.Invoke(() =>
        //    {
        //        // Тут можно показать всплывающее окно, добавить в список уведомлений и т. п.
        //        MessageBox.Show($"{title}\n{message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

        //        // Или свой кастомный toast‑блок в интерфейсе
        //    });
        //}

        public Task ShowNotification(string message)
        {
            return Task.CompletedTask;
        }

        public async Task SendNotificationToHub(string message)
        {
            await _connection.InvokeAsync("Send", "test");
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null) 
                await _connection.DisposeAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
