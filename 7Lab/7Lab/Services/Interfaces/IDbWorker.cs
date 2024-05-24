using _7Lab.Model;

namespace _7Lab.Services.Interfaces
{
    public interface IDbWorker
    {
        IEnumerable<UserModel> GetUsers();
    }
}
