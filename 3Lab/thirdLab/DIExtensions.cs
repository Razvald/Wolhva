using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using thirdLab.Database;
using thirdLab.Forms;
using thirdLab.Services.Implementations;
using thirdLab.Services.Interfaces;

namespace thirdLab
{
    internal static class DIExtensions
    {
        public static void InitServices(this ServiceCollection services)
        {
            services.AddTransient<MainForm>();
            services.AddTransient<MaterialsDataGridForm>();
            services.AddTransient<ProductsDataGridForm>();
            services.AddTransient<ProductsCustomForm>();
            services.AddTransient<MaterialsCustomForm>();

            services.AddScoped<IDbWorker, DbWorker>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data source=./app.db")
            );
        }
    }
}
