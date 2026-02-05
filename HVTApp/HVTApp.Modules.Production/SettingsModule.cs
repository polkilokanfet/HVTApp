using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Prism;
using HVTApp.Modules.Settings.Menus;
using HVTApp.UI.Modules.Settings.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace HVTApp.Modules.Settings
{
    public class SettingsModule : ModuleBase
    {
        public SettingsModule(IUnityContainer container, IRegionManager regionManager) : base(container, regionManager)
        {
        }

        protected override void RegisterTypes()
        {
            Container.RegisterViewForNavigation<UserSettingsView>();
            Container.RegisterViewForNavigation<SyncSettingsView>();
            Container.RegisterViewForNavigation<AdminView>();
            Container.RegisterViewForNavigation<DataBaseBackupView>();
        }

        protected override void ResolveOutlookGroup()
        {
            RegionManager.Regions[RegionNames.OutlookBarGroupsRegion].Add(Container.Resolve<SettingsMenu>());
        }
    }
}