using System.Windows;
using System.Windows.Controls;

namespace HVTApp.Infrastructure.Controls
{
    public partial class LoadableContentControl : UserControl
    {
        public static readonly DependencyProperty LoadingInProcessProperty = DependencyProperty.Register(
            nameof(LoadingInProcess), typeof(bool), typeof(LoadableContentControl), new PropertyMetadata(default(bool)));

        public bool LoadingInProcess
        {
            get => (bool)GetValue(LoadingInProcessProperty);
            set => SetValue(LoadingInProcessProperty, value);
        }


        public LoadableContentControl()
        {
            InitializeComponent();
        }
    }
}
