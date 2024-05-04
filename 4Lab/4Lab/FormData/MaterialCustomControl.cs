using _4Lab.Database;
using _4Lab.Forms;
using _4Lab.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _4Lab.FormData
{
    public class MaterialCustomControl : ViewModelBase
    {
        private readonly IDataService _db;
        public ObservableCollection<Material> Materials { get; }

        public MaterialCustomControl(IDataService dataService)
        {
            _db = dataService;

            SaveCommand = new RelayCommand(SaveChanges);
            OpenProductsCustomRequested = new RelayCommand(OpenProductsCustom);
            Materials = new ObservableCollection<Material>(_db.Materials);
        }

        public ICommand SaveCommand { get; }
        public ICommand OpenProductsCustomRequested { get; }

        private void SaveChanges(object parameter)
        {
            _db.SaveChanges();
        }

        private void OpenProductsCustom(object parameter)
        {
            if (parameter is int materialId)
            {
                // Создайте экземпляр ProductsCustom с передачей MaterialId
                ProductsCustom productsCustom = new(_db, materialId);
                productsCustom.Show();
            }
        }
    }
}
