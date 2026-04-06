using System.Collections.ObjectModel;

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
        public static ObservableCollection<InputManager> publicAllAccounts = new ObservableCollection<InputManager>();
        public static ObservableCollection<InputManager> privateAllAccounts = new ObservableCollection<InputManager>();
    }
}
