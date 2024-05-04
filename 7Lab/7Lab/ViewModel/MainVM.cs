using _7Lab.Model.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class MainVM : ViewModelBase
    {
        private readonly AppDbContext _dbContext;
        public ObservableCollection<User> Users { get; set; }

        public MainVM(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            SaveCommand = new RelayCommand(SaveChanges);
            Users = new ObservableCollection<User>(_dbContext.Users);
        }

        public ICommand SaveCommand { get; }

        private void SaveChanges(object parameter)
        {
            _dbContext.SaveChanges();
        }
    }
}
