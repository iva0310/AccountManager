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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("LoveDays.ttf", "LoveDays");
                    fonts.AddFont("RoughenCornerRegular.ttf", "RoughenCornerRegular");
                    fonts.AddFont("ShortBaby.ttf", "ShortBaby");
                    fonts.AddFont("Mefikademo.ttf", "Mefikademo");
                    fonts.AddFont("ToThePointRegular.ttf", "ToThePointRegular");
                    fonts.AddFont("TheConfessionFullRegular.ttf", "TheConfessionFullRegular");
                    fonts.AddFont("Cabal.ttf", "Cabal");
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
