using LetsHackUWCMauiApp.Pages;
using LetsHackUWCMauiApp.Services;
using LetsHackUWCMauiApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace LetsHackUWCMauiApp
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IShellNavigation, MauiShellNavigation>();
            builder.Services.AddSingleton<IDatabase, JsonDatabase>();

            builder.Services.AddTransient<HackathonManagerViewModel>();
            builder.Services.AddTransient<NewHackathonViewModel>();

            builder.Services.AddTransient<HackathonsPage>();
            builder.Services.AddTransient<NewHackathonPage>();

            return builder.Build();
        }
    }
}
