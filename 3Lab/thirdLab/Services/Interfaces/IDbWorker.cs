using thirdLab.Database.Entites;

namespace thirdLab.Services.Interfaces
{
    internal interface IDbWorker
    {
        public IEnumerable<Material> Materials { get; }
        public IEnumerable<Product> Products { get; }

        public void SaveChanges();
    }
}
