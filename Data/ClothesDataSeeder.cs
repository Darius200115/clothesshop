    using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;

namespace test_proj_843823.Data
{
    public class ClothesDataSeeder
    {
        private readonly ShopDbContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<ShopUser> _userManager;

        public ClothesDataSeeder(ShopDbContext ctx,
          IWebHostEnvironment hosting,
          UserManager<ShopUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            ShopUser user = await _userManager.FindByEmailAsync("svenpauxis@gmail.com");

            if (user == null)
            {
                user = new ShopUser()
                {
                    FirstName = "Vetal",
                    LastName = "Lushchevskiy",
                    Email = "svenpauxis@gmail.com",
                    UserName = "svenpauxis@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder"); 
                }
            }

            if (!_ctx.Clothes.Any())
            {
                // Need to create the Sample Data
                var file = Path.Combine(_hosting.ContentRootPath, "Data/datalist.json");
                var json = File.ReadAllText(file);
                var products = JsonSerializer.Deserialize<IEnumerable<Clothes>>(json);
                _ctx.Clothes.AddRange(products);

                var order = _ctx.Order.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
          {
            new OrderItem()
            {
              Clothes = products.First(),
              Quantity = 5,
              UnitePrice = products.First().Price
            }
          };
                }

                _ctx.SaveChanges();
            }
        }
    }
}
