namespace wake_up
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        [Obsolete("Obsolete")]
        private async void ChangeClicked(object sender, EventArgs e)
        {
            try
            {
                var options = new PickOptions()
                {
                    PickerTitle = "Please choose image/ gif",
                    FileTypes = FilePickerFileType.Images
                };
                var result = await FilePicker.Default.PickAsync(options);

                if (result != null)
                {
                    string extension = Path.GetExtension(result.FullPath);

                    string localFileName = "permanent_image" + extension;
                    string localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);

                    await using (var stream = await result.OpenReadAsync())
                    await using (var newStream = File.OpenWrite(localPath))
                    {
                        await stream.CopyToAsync(newStream);
                    }

                    Preferences.Default.Set("SavedImagePath", localPath);

                    MessagingCenter.Send(this, "UpdateImage", localPath);
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                throw; // TODO 处理异常
            }
        }
    }
}
