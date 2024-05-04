using secondLab.Database;
using secondLab.Services.Interfaces;

namespace secondLab.Services.Implementations
{
    internal class RealDbWorker : IDbWorker
    {
        private readonly AppDbContext _dbContext;

        public RealDbWorker(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Authenticate(string login, string password)
        {
            return _dbContext.Users
                .Where(x => x.Login == login && x.Password == password)
                .Any();
        }

        public bool IsLoginAlreadyTaken(string login)
        {
            return _dbContext.Users
                .Where(x => x.Login == login)
                .Any();
        }

        public void RegisterNewUser(string login, string password)
        {
            _dbContext.Users.Add(new()
            {
                Login = login,
                Password = password
            });
            _dbContext.SaveChanges();
        }
    }
}
