using _7Lab.Model.Database;
using _7Lab.Services.Implementations;
using _7Lab.Services.Interfaces;
using _7Lab.View;
using _7Lab.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace _7Lab
{
    public partial class App : Application
    {
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LogInView>();
            services.AddSingleton<SignInView>();
            services.AddSingleton<UserInfoView>();
            services.AddSingleton<UsersListView>();

            services.AddSingleton<LogInViewModel>();
            services.AddSingleton<SignInViewModel>();
            services.AddSingleton<UserInfoViewModel>();
            services.AddSingleton<UsersListViewModel>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IDbWorker, DbWorker>();
            services.AddScoped<IViewsManager, ViewsManager>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=helloapp.db"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            /*
            var viewsManager = serviceProvider.GetRequiredService<IViewsManager>();
            var authService = serviceProvider.GetRequiredService<IAuthorizationService>();
            var dbWorker = serviceProvider.GetRequiredService<IDbWorker>();

            viewsManager.Open<LogInView>(new LogInViewModel(authService, viewsManager, dbWorker));
            */
            var mainWindow = serviceProvider.GetRequiredService<LogInView>();
            mainWindow.DataContext = serviceProvider.GetRequiredService<LogInViewModel>();
            mainWindow.Show();
        }
    }
}
