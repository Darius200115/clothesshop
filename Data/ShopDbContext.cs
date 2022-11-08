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
       

    }
}
