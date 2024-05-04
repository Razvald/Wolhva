using Microsoft.EntityFrameworkCore;
using thirdLab.Database.Entites;

namespace thirdLab.Database
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }

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
            List<Material> materials =
                [
                    new() { Id = 1, Name = "Bronse" },
                    new() { Id = 2, Name = "Silver" },
                    new() { Id = 3, Name = "Platinum" },
                    new() { Id = 4, Name = "Gold" }
                ];

            List<Product> products =
                [
                    new() { Id = 1, Name = "Beads", Price = 50, MaterialId = 1 },
                    new() { Id = 2, Name = "Amulet", Price = 80, MaterialId = 1 },
                    new() { Id = 3, Name = "Beads", Price = 50, MaterialId = 2 },
                    new() { Id = 4, Name = "Amulet", Price = 80, MaterialId = 2 },
                    new() { Id = 5, Name = "Necklace", Price = 100, MaterialId = 3 },
                    new() { Id = 6, Name = "Ring", Price = 130, MaterialId = 3 },
                    new() { Id = 7, Name = "Necklace", Price = 100, MaterialId = 4 },
                    new() { Id = 8, Name = "Ring", Price = 130, MaterialId = 4 }
                ];

            modelBuilder.Entity<Material>().HasData(materials);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}