using Microsoft.EntityFrameworkCore;

namespace _7Lab.Model.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            List<User> users =
                [
                    new() { Id = 1, Login = "1", Password = "1", RoleID = 1 },
                    new() { Id = 2, Login = "2", Password = "2", RoleID = 2 }
                ];

            List<Role> roles =
                [
                    new() { Id = 1, Name = "Worker" },
                    new() { Id = 2, Name = "Admin" }
                ];

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
