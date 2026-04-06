namespace wake_up

{

    public partial class PublicAccountsList : ContentPage
    {

        public PublicAccountsList()
        {
            InitializeComponent();
            AccountList.ItemsSource = DataStorage.publicAllAccounts;

        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.CommandParameter is InputManager accountToDelete)
            {
                // 彈出確認視窗
                bool answer = await DisplayAlert("", $"Are you sure to delete <{accountToDelete.Name}> ?", "Yes", "No");

                if (answer)
                {
                    DataStorage.publicAllAccounts.Remove(accountToDelete);
                }
            }
        }


    }
}
