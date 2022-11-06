using Microsoft.EntityFrameworkCore;
using test_proj_843823.Data.Entities;

namespace test_proj_843823.Data
{
    public class ShopDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ShopDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<Order> Order { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:ShopDbContext"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clothes>().HasData(
                new Clothes { Id = 1 , Category = "Jacket" , Brand = "Nike" , Count = 20 , CountryManufacturer = "Poland" , DeliveryDate = "01/11/2022", Description="", Price = 200.00m, Size = "M", PictureUrl = "~/img/nike-jacket-1.jpeg" },
                new Clothes { Id = 2, Category = "Shoes", Brand = "Nike", Count = 7, CountryManufacturer = "Ukraine", DeliveryDate = "06/10/2022", Description = "", Price = 160.00m, Size = "42", PictureUrl = "~/img/nike-shoes-1.jpeg" },
                new Clothes { Id = 3, Category = "Shoes", Brand = "Puma", Count = 3, CountryManufacturer = "Poland", DeliveryDate = "25/10/2022", Description = "", Price = 175.00m, Size = "43", PictureUrl = "~/img/puma-shoes-1.jpeg" }
                );
        }

    }
}
