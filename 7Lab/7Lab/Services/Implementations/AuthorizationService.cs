using _7Lab.Model.Database;
using _7Lab.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _7Lab.Services.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly AppDbContext _dbContext;
        private User? _currentUser;

        public AuthorizationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User CurrentUser => _currentUser ?? throw new InvalidOperationException("No user is logged in");

        public bool LogIn(string login, string password)
        {
            var user = _dbContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                _currentUser = user;
                return true;
            }
            return false;
        }

        public bool SignIn(string login, string password)
        {
            if (_dbContext.Users.Any(u => u.Login == login)) return false;

            var user = new User { Login = login, Password = password, RoleID = 1 };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            _currentUser = user;
            return true;
        }

        public void LogOut()
        {
            _currentUser = null;
        }
    }
}
