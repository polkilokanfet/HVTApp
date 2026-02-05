using HVTApp.UI.Modules.Settings.ViewModels;
using Prism.Events;
using Prism.Regions;

namespace HVTApp.UI.Modules.Settings.Views
{
    public partial class UserSettingsView
    {
        public UserSettingsView(
            UserSettingsViewModel viewModel, 
            IRegionManager regionManager, 
            IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
