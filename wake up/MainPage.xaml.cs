namespace wake_up
{
    public partial class MainPage : ContentPage
    {
        [Obsolete("Obsolete")]
        public MainPage()
        {
            
            InitializeComponent();
            string savedPath = Preferences.Default.Get("SavedImagePath", "dotnet_bot.png");

            if (File.Exists(savedPath))
            {
                MainPageImage.Source = ImageSource.FromFile(savedPath);
            }
            else
            {
                MainPageImage.Source = savedPath;
            }
            MessagingCenter.Subscribe<SettingPage, string>(this, "UpdateImage", (sender, filePath) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    MainPageImage.Source = ImageSource.FromFile(filePath);
                });
            });
        }


        private async void AddAccountButtonClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new AddAccountPage());
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }

        private async void PublicOrPrivateClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PrivateOrPublic());
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }

        private async void SettingClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new SettingPage());
            }
            catch (Exception ex)
            {
                throw; 
            }
        }

    }
}
    
