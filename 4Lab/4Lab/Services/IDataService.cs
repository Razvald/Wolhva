using _4Lab.Database;

namespace _4Lab.Services
{
    public interface IDataService
    {
        public IEnumerable<Material> Materials { get; }
        public IEnumerable<Product> Products { get; }

        public void SaveChanges();
    }
}
