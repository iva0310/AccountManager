namespace wake_up
{
    public partial class PrivateAccountsHiddenList : ContentPage
    {
        public PrivateAccountsHiddenList()
        {
            InitializeComponent();
            AccountList.ItemsSource = DataStorage.privateAllAccounts;
        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.CommandParameter is InputManager accountToDelete)
            {
                bool answer = await DisplayAlert("", $"Are you sure to delete <{accountToDelete.Name}> ?", "Yes", "No");

                if (answer)
                {
                    DataStorage.privateAllAccounts.Remove(accountToDelete);
                }
            }
        }
    }
}
