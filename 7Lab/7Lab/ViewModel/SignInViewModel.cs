using _7Lab.Services.Interfaces;
using _7Lab.View;
using System.Windows;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        private readonly IAuthorizationService _authService;
        private readonly IViewsManager _viewsManager;
        private readonly IDbWorker _dbWorker;

        public SignInViewModel(IAuthorizationService authService, IViewsManager viewsManager, IDbWorker dbWorker)
        {
            _authService = authService;
            _viewsManager = viewsManager;
            _dbWorker = dbWorker;

            SignInCommand = new RelayCommand(SignIn);
            GeneratePasswordCommand = new RelayCommand(GeneratePassword);
            OpenLogInCommand = new RelayCommand(OpenLogIn);
        }

        private string _login;
        private string _password;
        private string _repeatPassword;
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

        public string RepeatPassword
        {
            get => _repeatPassword;
            set { _repeatPassword = value; OnPropertyChanged(nameof(RepeatPassword)); }
        }

        public ICommand SignInCommand { get; }
        public ICommand GeneratePasswordCommand { get; }
        public ICommand OpenLogInCommand { get; }

        private void SignIn(object? parameter)
        {
            if (Password != RepeatPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (_authService.SignIn(Login, Password))
            {
                _viewsManager.Open<UserInfoView>(new UserInfoViewModel(_authService, _viewsManager, _dbWorker));
            }
            else
            {
                MessageBox.Show("Логин уже занят");
            }
        }

        private void GeneratePassword(object? parameter)
        {
            Password = Guid.NewGuid().ToString().Substring(0, 8);
            RepeatPassword = Password;
        }

        private void OpenLogIn(object? parameter)
        {
            _viewsManager.Open<LogInView>(new LogInViewModel(_authService, _viewsManager, _dbWorker));
        }
    }
}
