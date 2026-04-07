namespace wake_up
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 500;
            window.Height = 500;
            window.MinimumWidth = 500;
            window.MaximumWidth = 500;
            window.MinimumHeight = 500;
            window.MaximumHeight = 500;

            return window;
        }


    }
}