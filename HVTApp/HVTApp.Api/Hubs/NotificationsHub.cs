using HVTApp.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace HVTApp.Api.Hubs;

public class NotificationsHub : Hub<INotificationServiceClient>
{
    public Task Send(NotificationHvtApp notification)
    {
        Console.WriteLine($"Task Send");
        return this.Clients.Caller.ShowNotification(notification);
    }

    private static string GroupName(string userId, string role) => $"userId: {userId}; role: {role}";

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        if (httpContext != null)
        {
            var userId = httpContext.Request.Headers["X-User-Id"].ToString();
            var role = httpContext.Request.Headers["X-Role"].ToString();
            if (string.IsNullOrWhiteSpace(userId) == false)
                await Groups.AddToGroupAsync(Context.ConnectionId, GroupName(userId, role));
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var httpContext = Context.GetHttpContext();
        if (httpContext != null)
        {
            var userId = httpContext.Request.Headers["X-User-Id"].ToString();
            var role = httpContext.Request.Headers["X-Role"].ToString();
            if (string.IsNullOrWhiteSpace(userId) == false)
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(userId, role));
        }

        await base.OnDisconnectedAsync(exception);
    }
}