
namespace wake_up
{
    public partial class PrivateAccountsList : ContentPage
    {
        public PrivateAccountsList()
        {
            InitializeComponent();
        }

        private async void EnterPrivate(object sender, EventArgs e)
        {
            // 從手機儲存空間抓取密碼，預設為空字串
            string savedPass = Preferences.Default.Get("PrivateLockPassword", "");

            if (string.IsNullOrEmpty(savedPass))
            {
                string newPass = await DisplayPromptAsync("", "Set password", "OK", "Cancel");
                if (!string.IsNullOrWhiteSpace(newPass))
                {
                    Preferences.Default.Set("PrivateLockPassword", newPass); // 永久儲存
                    await DisplayAlert("", "Lock Password has been set", "OK");
                }
            }
            else
            {
                // 驗證密碼
                string inputPass = await DisplayPromptAsync("", "Please enter password", "OK", "Cancel");
                if (inputPass == savedPass)
                {
                    await Navigation.PushAsync(new PrivateAccountsHiddenList());
                }
                else if (inputPass != null)
                {
                    await DisplayAlert("", "Wrong password", "OK");
                }
            }
        }
        private async void ForgotPass(object sender, EventArgs e)
        {
            string savedPass = Preferences.Default.Get("PrivateLockPassword", "");

            if (string.IsNullOrEmpty(savedPass))
            {
                string newPass = await DisplayPromptAsync("", "Set password", "OK", "Cancel");
                if (!string.IsNullOrWhiteSpace(newPass))
                {
                    Preferences.Default.Set("PrivateLockPassword", newPass);
                    await DisplayAlert("", "Lock Password has been set", "OK");
                }
                return;
            }

            string oldPassInput = await DisplayPromptAsync("", "Please enter old password", "Next", "Cancel");

            if (oldPassInput == savedPass)
            {
                string newPass = await DisplayPromptAsync("", "Please enter new password", "Save", "Cancel");

                if (!string.IsNullOrWhiteSpace(newPass))
                {
                    Preferences.Default.Set("PrivateLockPassword", newPass);
                    await DisplayAlert("", "Lock Password has been reset", "OK");
                }
            }
            else if (oldPassInput != null)
            {
                await DisplayAlert("", "Wrong old password", "OK");
            }
        }

    }
}
