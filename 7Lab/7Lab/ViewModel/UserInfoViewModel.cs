using _7Lab.Services.Interfaces;
using _7Lab.View;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class UserInfoViewModel : ViewModelBase
    {
        private readonly IAuthorizationService _authService;
        private readonly IViewsManager _viewsManager;
        private readonly IDbWorker _dbWorker;

        public UserInfoViewModel(IAuthorizationService authService, IViewsManager viewsManager, IDbWorker dbWorker)
        {
            _authService = authService;
            _viewsManager = viewsManager;
            _dbWorker = dbWorker;

            SignOutCommand = new RelayCommand(SignOut);
            OpenUsersListCommand = new RelayCommand(OpenUsersList);

            Login = _authService.CurrentUser.Login;
            RoleName = _authService.CurrentUser.Role.Name;
        }

        public string Login { get; }
        public string RoleName { get; }

        public ICommand SignOutCommand { get; }
        public ICommand OpenUsersListCommand { get; }

        private void SignOut(object? parameter)
        {
            _authService.LogOut();
            _viewsManager.Open<LogInView>(new LogInViewModel(_authService, _viewsManager, _dbWorker));
        }

        private void OpenUsersList(object? parameter)
        {
            _viewsManager.Open<UsersListView>(new UsersListViewModel(_authService, _viewsManager, _dbWorker));
        }
    }
}
