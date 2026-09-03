using System.Text.Json;
using HVTApp.Api.Hubs;

namespace HVTApp.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddSignalR()
            .AddJsonProtocol(opts =>
            {
                opts.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

        var app = builder.Build();

        app.MapHub<NotificationsHub>("/notificationsHub");

        app.Run();
    }
}