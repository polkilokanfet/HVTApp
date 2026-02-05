using HVTApp.Infrastructure.Interfaces.Services.EventService;
using HVTApp.UI.Commands;
using Microsoft.Practices.Unity;

namespace HVTApp.UI.Modules.Settings.ViewModels
{
    public class SyncSettingsViewModel
    {
        public DelegateLogCommand StartEventServiceCommand { get; }
        public DelegateLogCommand StopEventServiceCommand { get; }

        public SyncSettingsViewModel(IUnityContainer container)
        {
            var eventServiceClient = container.Resolve<IEventServiceClient>();

            StartEventServiceCommand = new DelegateLogCommand(async () =>
                {
                    await eventServiceClient.Stop();
                    await eventServiceClient.Start();
                });

            StopEventServiceCommand = new DelegateLogCommand(async () =>
                {
                    await eventServiceClient.Stop();
                });

        }
    }
}