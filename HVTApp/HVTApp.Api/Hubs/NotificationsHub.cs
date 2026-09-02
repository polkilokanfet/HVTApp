using HVTApp.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace HVTApp.Api.Hubs;

public class NotificationsHub : Hub<INotificationServiceClient>
{
    public Task Send(string message)
    {
        return this.Clients.Caller.ShowNotification(message);
    }

    private string GetGroupName(string userId, string role)
    {
        return $"userId: {userId}; role: {role}";
    }

    public override Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        if (httpContext != null)
        {
            var userId = httpContext.Request.Query["userId"].ToString();
            var role = httpContext.Request.Query["role"].ToString();
            Groups.AddToGroupAsync(Context.ConnectionId, this.GetGroupName(userId, role));
        }

        return base.OnConnectedAsync();
    }
}