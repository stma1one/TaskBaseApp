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

			#region Add Pages, ViewModels and Services
			builder.AddPages()
                   .AddViewModels()
                   .AddServices();
			#endregion

#if DEBUG
			builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder AddPages(this MauiAppBuilder builder)
        {
            // Add any additional pages here if needed
            builder.Services.AddSingleton<Views.LoginPage>();
            builder.Services.AddTransient<Views.UserTasksPage>();
            builder.Services.AddTransient<Views.AddTaskPage>();
            builder.Services.AddTransient<TaskDetailsPage>();

            return builder;

        }
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            // Add any additional view models here if needed
            builder.Services.AddSingleton<ViewModels.LoginPageViewModel>();
            builder.Services.AddTransient<ViewModels.UserTasksPageViewModel>();
            builder.Services.AddTransient<ViewModels.AddTaskPageViewModel>();
            builder.Services.AddTransient<ViewModels.TaskDetailsPageViewModel>();
            return builder;
        }
        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            // Add any additional services here if needed
            builder.Services.AddSingleton<ITaskServices, DBMokup>();
            return builder;
        }
    }
}
