namespace secondLab.Services.Interfaces
{
    public interface IDbWorker
    {
        public bool IsLoginAlreadyTaken(string login);
        public bool Authenticate(string login, string password);
        public void RegisterNewUser(string login, string password);
    }
}
