using Microsoft.EntityFrameworkCore;

namespace _4Lab.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            List<Material> materials =
                [
                    new() { Id = 1, Title = "Bronse" },
                    new() { Id = 2, Title = "Silver" },
                    new() { Id = 3, Title = "Platinum" },
                    new() { Id = 4, Title = "Gold" }
                ];

            List<Product> products =
                [
                    new() { Id = 1, Title = "Beads", Price = 50, MaterialId = 1 },
                    new() { Id = 2, Title = "Amulet", Price = 80, MaterialId = 1 },
                    new() { Id = 3, Title = "Beads", Price = 50, MaterialId = 2 },
                    new() { Id = 4, Title = "Amulet", Price = 80, MaterialId = 2 },
                    new() { Id = 5, Title = "Necklace", Price = 100, MaterialId = 3 },
                    new() { Id = 6, Title = "Ring", Price = 130, MaterialId = 3 },
                    new() { Id = 7, Title = "Necklace", Price = 100, MaterialId = 4 },
                    new() { Id = 8, Title = "Ring", Price = 130, MaterialId = 4 }
                ];

            modelBuilder.Entity<Material>().HasData(materials);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
