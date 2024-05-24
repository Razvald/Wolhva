using _7Lab.Model.Database;

namespace _7Lab.Services.Interfaces
{
    public interface IAuthorizationService
    {
        User CurrentUser { get; }
        bool LogIn(string login, string password);
        bool SignIn(string login, string password);
        void LogOut();
    }
}
