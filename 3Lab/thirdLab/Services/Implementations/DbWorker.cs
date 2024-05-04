using Microsoft.EntityFrameworkCore;
using thirdLab.Database;
using thirdLab.Database.Entites;
using thirdLab.Services.Interfaces;

namespace thirdLab.Services.Implementations
{
    internal class DbWorker : IDbWorker
    {
        private readonly AppDbContext _dbContext;

        public DbWorker(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            _dbContext.Materials.Load();
            _dbContext.Products.Load();
        }
        
        public IEnumerable<Material> Materials => _dbContext.Materials.ToList();
        public IEnumerable<Product> Products => _dbContext.Products.ToList();
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
                MessageBox.Show("Сохранение выполнено успешно");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.InnerException.Message}");
                }
                else
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }
    }
}
