using _4Lab.Controls;
using _4Lab.Database;
using _4Lab.Forms;
using _4Lab.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _4Lab.FormData
{
    public class ProductsGrid : ViewModelBase
    {
        private readonly IDataService _db;
        public ObservableCollection<Product> Products { get; }

        public ProductsGrid(IDataService dataService)
        {
            _db = dataService;
            SaveCommand = new RelayCommand(SaveChanges);
            Products = new ObservableCollection<Product>(_db.Products);
        }

        public ICommand SaveCommand { get; }

        private void SaveChanges(object parameter)
        {
            _db.SaveChanges();
        }
    }
}
