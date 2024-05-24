using _7Lab.Model;
using _7Lab.Model.Database;
using _7Lab.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _7Lab.Services.Implementations
{
    public class DbWorker : IDbWorker
    {
        private readonly AppDbContext _dbContext;

        public DbWorker(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dbContext.Users.Include(u => u.Role)
                .Select(u => new UserModel { Login = u.Login, RoleName = u.Role.Name })
                .ToList();
        }
    }
}
