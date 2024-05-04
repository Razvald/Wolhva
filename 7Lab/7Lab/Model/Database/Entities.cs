namespace _7Lab.Model.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public int RoleID { get; set; } = 1;
        public virtual Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<User> Users { get; set; }
    }
}
