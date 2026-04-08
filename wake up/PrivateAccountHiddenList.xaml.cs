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
            var combinedText = $"{item?.Email}\n{item?.Password}";
            await Clipboard.SetTextAsync(combinedText);
            var normalText = button.Text;
            button.Text = "✓";
            await Task.Delay(3000);
            button.Text = normalText;
        }
        private async void OnEditClicked(object sender, EventArgs e)
        {
            var element = sender as Element;

            if (element?.BindingContext is not InputManager item) return;

            var newName = await DisplayPromptAsync("", "Edit Name:", "Save", "Cancel", initialValue: item.Name);
            if (newName == null) return; // Cancel

            var newEmail = await DisplayPromptAsync("", "Edit Email:", "Save", "Cancel", initialValue: item.Email);
            if (newEmail == null) return;

            var newPassword = await DisplayPromptAsync("", "Edit Password:", "Save", "Cancel", initialValue: item.Password);
            if (newPassword == null) return;

            item.Name = newName;
            item.Email = newEmail;
            item.Password = newPassword;

            /*
            int index = DataStorage.PrivateAllAccounts.IndexOf(item);
            if (index != -1)
            {
                DataStorage.PrivateAllAccounts.RemoveAt(index);
                DataStorage.PrivateAllAccounts.Insert(index, item);
            }
            */
            DataStorage.SaveData();
        }
    }
}
