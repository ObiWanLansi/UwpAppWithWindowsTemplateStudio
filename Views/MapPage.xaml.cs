using System;

using UwpAppWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpAppWithWindowsTemplateStudio.Views
{
    public sealed partial class MapPage : Page
    {
        public MapViewModel ViewModel { get; } = new MapViewModel();

        public MapPage()
        {
            InitializeComponent();
            Loaded += MapPage_Loaded;
            Unloaded += MapPage_Unloaded;
        }

        private async void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        private void MapPage_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
