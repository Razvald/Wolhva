using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using secondLab.Database;
using secondLab.Forms;
using secondLab.Services.Implementations;
using secondLab.Services.Interfaces;

namespace secondLab
{
    internal static class DIExtensions
    {
        public static void InitServices(this ServiceCollection services)
        {
            services.AddTransient<MainForm>();
            services.AddTransient<LoginDialog>();
            services.AddTransient<RegisterDialog>();

            services.AddScoped<IDbWorker, RealDbWorker /*FakeDbWorker*/ /*ListDbWorker*/>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data source=./app.db")
            );
        }
    }
}
