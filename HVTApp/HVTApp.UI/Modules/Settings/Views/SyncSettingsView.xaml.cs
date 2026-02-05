using Prism.Events;
using Prism.Regions;

namespace HVTApp.UI.Modules.Settings.Views
{
    public partial class SyncSettingsView
    {
        public SyncSettingsView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            InitializeComponent();
        }
    }
}
