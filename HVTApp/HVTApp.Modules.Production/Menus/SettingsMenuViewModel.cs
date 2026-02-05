using HVTApp.Infrastructure;
using HVTApp.Model;
using HVTApp.UI.Modules.Settings.Views;

namespace HVTApp.Modules.Settings.Menus
{
    public class SettingsMenuViewModel : BaseMenuViewModel
    {
        protected override void GenerateMenu()
        {
            Items.Add(new NavigationItem("Настройки", typeof(UserSettingsView)));
            Items.Add(new NavigationItem("Синхронизация", typeof(SyncSettingsView)));

            if (GlobalAppProperties.User.RoleCurrent == Role.Admin)
            {
                Items.Add(new NavigationItem("Admin", typeof(AdminView)));
                Items.Add(new NavigationItem("DB Backup", typeof(DataBaseBackupView)));
            }
        }
    }
}
