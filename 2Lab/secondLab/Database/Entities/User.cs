using secondLab.Extensions;

namespace secondLab.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public UserPassword Password { get; set; } = null!;
    }

    public record class UserPassword
    {
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => _password = value.ToHash();
        }

        public UserPassword() { }
        public UserPassword(string password) => Password = password;

        public static implicit operator string(UserPassword password) => password.Password;
        public static implicit operator UserPassword(string password) => new() { Password = password };
    }
}
