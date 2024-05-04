using _4Lab.Database;
using _4Lab.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _4Lab.FormData
{
    public class ProductsCustomControl : ViewModelBase
    {
        private readonly IDataService _db;
        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Material> Materials { get; }

        public ProductsCustomControl(IDataService dataService, int materialId)
        {
            _db = dataService;

            SaveCommand = new RelayCommand(SaveChanges);

            if (materialId > 0)
            {
                Products = new ObservableCollection<Product>(_db.Products.Where(p => p.MaterialId == materialId));
            }
            else
            {
                Products = new ObservableCollection<Product>(_db.Products);
            }
            Materials = new ObservableCollection<Material>(_db.Materials);
        }

        public ICommand SaveCommand { get; }

        private void SaveChanges(object parameter)
        {
            _db.SaveChanges();
        }
    }
}
