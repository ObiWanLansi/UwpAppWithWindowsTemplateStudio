using System;

using UwpAppWithWindowsTemplateStudio.Services.Ink;
using UwpAppWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpAppWithWindowsTemplateStudio.Views
{
    // For more information regarding Windows Ink documentation and samples see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/ink.md
    public sealed partial class InkDrawPage : Page
    {
        public InkDrawViewModel ViewModel { get; } = new InkDrawViewModel();

        public InkDrawPage()
        {
            InitializeComponent();
            Loaded += (sender, eventArgs) =>
            {
                SetCanvasSize();

                var strokeService = new InkStrokesService(inkCanvas.InkPresenter);
                var selectionRectangleService = new InkSelectionRectangleService(inkCanvas, selectionCanvas, strokeService);

                ViewModel.Initialize(
                    strokeService,
                    new InkLassoSelectionService(inkCanvas, selectionCanvas, strokeService, selectionRectangleService),
                    new InkPointerDeviceService(inkCanvas),
                    new InkCopyPasteService(strokeService),
                    new InkUndoRedoService(inkCanvas, strokeService),
                    new InkFileService(inkCanvas, strokeService),
                    new InkZoomService(canvasScroll));

                // In tabbedpivot projects the ballpoint pen is not selected by default, so we set it explicitly
                toolbar.ActiveTool = toolbar.GetToolButton(InkToolbarTool.BallpointPen);
                toolbar.ActiveTool.IsChecked = true;
            };
        }

        private void SetCanvasSize()
        {
            inkCanvas.Width = Math.Max(canvasScroll.ViewportWidth, 1000);
            inkCanvas.Height = Math.Max(canvasScroll.ViewportHeight, 1000);
        }
    }
}
