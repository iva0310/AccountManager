namespace wake_up
{
    public partial class PrivateOrPublic : ContentPage
    {
        public PrivateOrPublic()
        {
            InitializeComponent();
        }
        private async void PublicAccClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PublicAccountsList());
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }
        private async void PrivateAccClicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PrivateAccountsList());
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }
    }
}
