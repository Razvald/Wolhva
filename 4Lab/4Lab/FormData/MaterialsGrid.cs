using _4Lab.Database;
using _4Lab.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _4Lab.FormData
{
    public class MaterialsGrid : ViewModelBase
    {
        private readonly IDataService _db;
        public ObservableCollection<Material> Materials { get; set; }

        public MaterialsGrid(IDataService dataService)
        {
            _db = dataService;
            SaveCommand = new RelayCommand(SaveChanges);
            Materials = new ObservableCollection<Material>(_db.Materials);
        }

        public ICommand SaveCommand { get; }

        private void SaveChanges(object parameter)
        {
            _db.SaveChanges();
        }
    }
}
