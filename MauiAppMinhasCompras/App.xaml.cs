using MauiAppMinhasCompras.Views;
namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Page PaginaInicial = new ListaProduto();

            Window window = new Window(PaginaInicial);

            window.Width = DeviceInfo.Platform switch
            {
                var p when p == DevicePlatform.iOS => 375,
                var p when p == DevicePlatform.Android => 360,
                _ => 1280
            };

            window.Height = DeviceInfo.Platform switch
            {
                var p when p == DevicePlatform.iOS => 667,
                var p when p == DevicePlatform.Android => 640,
                _ => 720
            };

            return window;
        }
    }
}