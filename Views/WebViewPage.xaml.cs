using System;

using UwpAppWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UwpAppWithWindowsTemplateStudio.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; } = new WebViewViewModel();

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
