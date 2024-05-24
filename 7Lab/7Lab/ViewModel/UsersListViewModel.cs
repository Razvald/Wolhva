using _7Lab.Model;
using _7Lab.Services.Interfaces;
using _7Lab.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace _7Lab.ViewModel
{
    public class UsersListViewModel : ViewModelBase
    {
        private readonly IAuthorizationService _authService;
        private readonly IViewsManager _viewsManager;
        private readonly IDbWorker _dbWorker;

        public UsersListViewModel(IAuthorizationService authService, IViewsManager viewsManager, IDbWorker dbWorker)
        {
            _authService = authService;
            _viewsManager = viewsManager;
            _dbWorker = dbWorker;

            ReturnToUserInfoCommand = new RelayCommand(ReturnToUserInfo);

            Users = new ObservableCollection<UserModel>(_dbWorker.GetUsers());
        }

        public ObservableCollection<UserModel> Users { get; }

        public ICommand ReturnToUserInfoCommand { get; }

        private void ReturnToUserInfo(object? parameter)
        {
            _viewsManager.Open<UserInfoView>(new UserInfoViewModel(_authService, _viewsManager, _dbWorker));
        }
    }
}
