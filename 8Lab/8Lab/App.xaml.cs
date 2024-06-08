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

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowVM>();
            
            mainWindow.Show();
        }
    }
}
