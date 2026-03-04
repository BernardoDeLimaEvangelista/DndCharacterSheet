using Microsoft.Extensions.DependencyInjection;

namespace DndCharacterSheet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Define o título (opcional)
            window.Title = "Character Builder";

            // No Windows, precisamos de um pequeno ajuste para maximizar logo no início
            window.Created += (s, e) =>
            {
#if WINDOWS
            var nativeWindow = window.Handler.PlatformView as Microsoft.UI.Xaml.Window;
            if (nativeWindow != null)
            {
                var presenter = GetAppWindowPresenter(nativeWindow);
                presenter.Maximize();
            }
#endif

#if MACCATALYST
            // No Mac, o conceito é um pouco diferente, mas você pode setar o tamanho
            window.Width = 1920; 
            window.Height = 1080;
#endif
            };

            return window;
        }

#if WINDOWS
    private Microsoft.UI.Windowing.OverlappedPresenter GetAppWindowPresenter(Microsoft.UI.Xaml.Window nativeWindow)
    {
        var windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
        var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
        return appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;
    }
#endif
    }
}