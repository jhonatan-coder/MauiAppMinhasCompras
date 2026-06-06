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
            Window window = new Window(new AppShell());

            window.Width = AutomationIdProperty.DefaultValue switch
            {
                "iOS" => 375,
                "Android" => 400,
                _ => 1280
            };
            window.Height = AutomationIdProperty.DefaultValue switch
            {
                "iOS" => 667,
                "Android" => 700,
                _ => 720

            };

            return window;
        }
    }
}