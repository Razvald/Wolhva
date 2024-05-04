using _7Lab.Model.Database;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        private readonly AppDbContext _dbContext;

        public LoginVM(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        private void Login(object parameter)
        {
            _dbContext.SaveChanges();
        }

        private void Register(object parameter)
        {
            _dbContext.SaveChanges();
        }
    }
}
