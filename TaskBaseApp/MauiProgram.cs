using Microsoft.Extensions.Logging;
using TaskBaseApp.Service;
using TaskBaseApp.Views;
using TaskBaseApp.ViewModels;

namespace TaskBaseApp
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
					#region הוספת פונטים חדשים
					fonts.AddFont("MaterialSymbolsOutlined.ttf", "MaterialSymbols");
					#endregion
				});

			builder.Services.AddSingleton<Views.LoginPage>();
			builder.Services.AddTransient<ViewModels.LoginPageViewModel>();

			builder.Services.AddSingleton<ITaskServices, DBMokup>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
