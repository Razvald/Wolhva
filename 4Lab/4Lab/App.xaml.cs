using _4Lab.Database;
using _4Lab.Forms;
using _4Lab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace _4Lab
{
    public partial class App : Application
    {
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MaterialsDataGrid>();
            services.AddSingleton<ProductsDataGrid>();
            services.AddSingleton<MaterialsCustom>();
            services.AddSingleton<ProductsCustom>();

            services.AddScoped<IDataService, DataService>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=helloapp.db"));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
