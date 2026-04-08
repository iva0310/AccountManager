using System.Collections.ObjectModel;
using System.Text.Json;
namespace wake_up
{
    public class InputManager
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public static class DataStorage
    {
        public static ObservableCollection<InputManager> PublicAllAccounts = [];
        public static ObservableCollection<InputManager> PrivateAllAccounts = [];
        public static void SaveData()
        {
            var dataToSave = new { Public = PublicAllAccounts, Private = PrivateAllAccounts };
            string json = JsonSerializer.Serialize(dataToSave);
            Preferences.Default.Set("all_account_data", json);
        }

        public static void LoadData()
        {
            string json = Preferences.Default.Get("all_account_data", "");
            if (!string.IsNullOrEmpty(json))
            {
                var savedData = JsonSerializer.Deserialize<AccountDataWrapper>(json);
                if (savedData != null)
                {
                    PublicAllAccounts.Clear();
                    foreach (var acc in savedData.Public) PublicAllAccounts.Add(acc);

                    PrivateAllAccounts.Clear();
                    foreach (var acc in savedData.Private) PrivateAllAccounts.Add(acc);
                }
            }
        }
    }
    public class AccountDataWrapper
    {
        public List<InputManager> Public { get; set; }
        public List<InputManager> Private { get; set; }
    }
}
