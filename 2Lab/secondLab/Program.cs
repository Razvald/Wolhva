using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using secondLab.Database;
using secondLab.Forms;
using secondLab.Services.Implementations;
using secondLab.Services.Interfaces;

namespace secondLab
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider = null!;

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            services.InitServices();
            _serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(_serviceProvider.GetRequiredService<MainForm>());
        }
    }
}