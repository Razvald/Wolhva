using _7Lab.Services.Interfaces;
using _7Lab.View;
using System.Windows;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class LogInViewModel : ViewModelBase
    {
        private readonly IAuthorizationService _authService;
        private readonly IViewsManager _viewsManager;
        private readonly IDbWorker _dbWorker;

        public LogInViewModel(IAuthorizationService authService, IViewsManager viewsManager, IDbWorker dbWorker)
        {
            _authService = authService;
            _viewsManager = viewsManager;
            _dbWorker = dbWorker;
            LogInCommand = new RelayCommand(LogIn);
            OpenSignInCommand = new RelayCommand(OpenSignIn);
        }

        private string _login;
        private string _password;
        public string Login
        {
            get => _login;
            set { _login = value; OnPropertyChanged(nameof(Login)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LogInCommand { get; }
        public ICommand OpenSignInCommand { get; }

        private void LogIn(object? parameter)
        {
            if (_authService.LogIn(Login, Password))
            {
                _viewsManager.Open<UserInfoView>(new UserInfoViewModel(_authService, _viewsManager, _dbWorker));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void OpenSignIn(object? parameter)
        {
            _viewsManager.Open<SignInView>(new SignInViewModel(_authService, _viewsManager, _dbWorker));
        }
    }
}
