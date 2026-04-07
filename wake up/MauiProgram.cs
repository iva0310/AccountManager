using Microsoft.Extensions.Logging;

namespace wake_up
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Pixelletters.ttf", "Pixelletters");
                    fonts.AddFont("Pixellettersfull.ttf", "Pixellettersfull");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
