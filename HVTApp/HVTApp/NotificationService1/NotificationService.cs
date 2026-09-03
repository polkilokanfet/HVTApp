using HVTApp.Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows;
using HVTApp.Model;
using System.Configuration;

namespace HVTApp.NotificationService1
{
    internal class NotificationService : INotificationServiceClient, IDisposable, IAsyncDisposable
    {
        private readonly HubConnection _connection;

        public NotificationService()
        {
            var baseUrl = ConfigurationManager.AppSettings["NotificationHubBaseUrl"];
            _connection = new HubConnectionBuilder()
                .WithUrl($"{baseUrl}/notificationsHub", options =>
                {
                    // Для не‑чувствительных метаданных можно добавить кастомные заголовки
                    options.Headers.Add("X-User-Id", GlobalAppProperties.User.Id.ToString());
                    options.Headers.Add("X-Role", GlobalAppProperties.User.RoleCurrent.ToString());

                    // Для аутентификации используйте AccessTokenProvider
                    // options.AccessTokenProvider = () => Task.FromResult(yourJwtToken);
                })
                .WithAutomaticReconnect()
                .Build();

            _connection.On<NotificationHvtApp>(nameof(ShowNotification), ShowNotification);

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

        public Task ShowNotification(NotificationHvtApp notification)
        {
            // Важно: колбэк SignalR приходит не из UI‑потока
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Тут можно показать всплывающее окно, добавить в список уведомлений и т. п.
                MessageBox.Show($"{notification.Message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            return Task.CompletedTask;
        }

        public async Task SendNotificationToHub(NotificationHvtApp notification)
        {
            await _connection.InvokeAsync("Send", notification);
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