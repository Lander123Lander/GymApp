using Microsoft.Extensions.Logging;
using GymApp_frontend.Services;
using GymApp_frontend.Pages;
using Refit;

namespace GymApp_frontend
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

            builder.Services.AddTransient<WelcomePage>();
            builder.Services.AddTransient<LoginPage>();

            builder.Services
                .AddRefitClient<IAuthService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://10.0.2.2:3000/api"));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
