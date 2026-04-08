namespace wake_up
{
    public partial class PrivateAccountsHiddenList : ContentPage
    {
        public PrivateAccountsHiddenList()
        {
            InitializeComponent();
            AccountList.ItemsSource = DataStorage.PrivateAllAccounts;
        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.CommandParameter is InputManager accountToDelete)
            {
                bool answer = await DisplayAlert("", $"Are you sure to delete <{accountToDelete.Name}> ?", "Yes", "No");

                if (answer)
                {
                    DataStorage.PrivateAllAccounts.Remove(accountToDelete);
                    DataStorage.SaveData();
                }
            }
        }
        private async void OnCopyClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = button.BindingContext as InputManager;

            if (item != null)
            {
                string textToCopy = item.Email;
                await Clipboard.Default.SetTextAsync(textToCopy);
            }
            if (item != null)
            {
                string textToCopy = item.Password;
                await Clipboard.Default.SetTextAsync(textToCopy);
            }
        }
    }
}
