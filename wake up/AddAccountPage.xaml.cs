namespace wake_up
{
    public partial class AddAccountPage : ContentPage
    {
        public AddAccountPage()
        {
            InitializeComponent();
        }
        public async void AddPublicAcc(object sender, EventArgs e)
        {
            try
            {
                string userNameInput = EnterName.Text;
                string userEmailInput = EnterEmail.Text;
                string userPasswordInput = EnterPass.Text;

                if (!string.IsNullOrWhiteSpace(userEmailInput) && !string.IsNullOrWhiteSpace(userPasswordInput) && !string.IsNullOrWhiteSpace(userNameInput))
                {
                    await DisplayAlert("Account has been added to public list", $"Name: {userNameInput}\nAccount: {userEmailInput}\nPassword: {userPasswordInput}", "OK");
                        DataStorage.publicAllAccounts.Add(new InputManager
                        {
                            Name = userNameInput,
                            Email = userEmailInput,
                            Password = userPasswordInput,
                        });
                    EnterName.Text = "";
                    EnterEmail.Text = "@gmail.com / @outlook.com";
                    EnterPass.Text = "";
                }
                else
                {
                    await DisplayAlert("Error", "You didn't enter right word.", "OK");
                }
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }

        public async void AddPrivateAcc(object sender, EventArgs e)
        {
            try
            {
                string userEmailInput = EnterEmail.Text;
                string userPasswordInput = EnterPass.Text;
                string userNameInput = EnterName.Text;
                

                if (!string.IsNullOrWhiteSpace(userEmailInput) && !string.IsNullOrWhiteSpace(userPasswordInput) && !string.IsNullOrWhiteSpace(userNameInput))
                {
                    await DisplayAlert("Account has been added to private list", $"Name: {userNameInput}\nAccount: {userEmailInput}\nPassword: {userPasswordInput}", "OK");
                    DataStorage.privateAllAccounts.Add(new InputManager
                    {
                        Name = userNameInput,
                        Email = userEmailInput,
                        Password = userPasswordInput,
                    });
                    EnterName.Text = "";
                    EnterEmail.Text = "@gmail.com / @outlook.com";
                    EnterPass.Text = "";
                }
                else
                {
                    await DisplayAlert("Error", "You didn't enter right word.", "OK");
                }
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }
    }
}
