using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using secondLab.Database.Entities;

namespace secondLab.Database
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Login = "1",
                Password = "1"
            });

            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .HasConversion(new ValueConverter<UserPassword, string>(
                    val => val,
                    val => val
                    ));
        }
    }
}
