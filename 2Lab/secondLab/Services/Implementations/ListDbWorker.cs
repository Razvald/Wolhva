using secondLab.Services.Interfaces;

namespace secondLab.Services.Implementations
{
    internal class ListDbWorker : IDbWorker
    {
        private static List<(int id, string login, string password)> _users =
        [(1, "admin", "admin")];

        private static int _idCount = 2;

        public bool Authenticate(string login, string password)
        {
            return _users
                .Where(x => x.login == login && x.password == password)
                .Any();
        }

        public bool IsLoginAlreadyTaken(string login)
        {
            return _users
                .Where(x => x.login == login)
                .Any();
        }

        public void RegisterNewUser(string login, string password)
        {
            _users.Add((_idCount++, login, password));
        }
    }
}
