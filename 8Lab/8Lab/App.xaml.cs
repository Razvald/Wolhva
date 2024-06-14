using _8Lab.View;
using _8Lab.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace _8Lab
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddSingleton<MainWindowVM>();

            serviceCollection.AddSingleton<InputDialog>();
            serviceCollection.AddSingleton<InputDialogVM>();

            serviceCollection.AddSingleton<AuthDialog>();
            serviceCollection.AddSingleton<AuthDialogVM>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            /*
            var authDialog = serviceProvider.GetRequiredService<AuthDialog>();

            authDialog.DataContext = serviceProvider.GetRequiredService<AuthDialogVM>();
            
            if (authDialog.ShowDialog() == true)
            {
            // Получение токена доступа после авторизации
            var accessToken = AuthDialogVM.AccessToken;*/
            var accessToken = "sl.B3JwpUkfBxc" +
                "TUisIa21YeWBusVhvi3aW0ixCJYe" +
                "hFEryKp78YB_oGgrUnrstWezvAqm" +
                "ljAHArRuR7KqSWBXVx4ae72GPFps" +
                "AmZGzfDcThTeKZGbiFKWWrPMoXhV" +
                "U-4sUihr24B7KI2Hnf21D38o910k";

            // Создание MainWindowVM с токеном доступа
            var mainWindowVM = new MainWindowVM(accessToken);
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = mainWindowVM;
            mainWindow.Show();
            /*}
            else
            {
                Shutdown();
            }*/
        }
    }
}
