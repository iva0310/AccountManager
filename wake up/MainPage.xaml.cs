namespace wake_up
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
    }
}
