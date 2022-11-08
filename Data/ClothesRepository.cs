using Microsoft.EntityFrameworkCore;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Data
{
    public class ClothesRepository : IClothesRepository
    {
        private readonly ShopDbContext _ctx;

        public ClothesRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Clothes> GetAllClothes()
        {
            return _ctx.Clothes
                .OrderBy(p => p.Brand)
                .ToList();
        }


        public IEnumerable<Clothes> GetClothesByCategory(string category)
        {
            return _ctx.Clothes.Where(p => p.Category == category).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Order
                .Include(p=>p.Items)
                .ThenInclude(p=>p.Clothes)
                .ToList();
        }

        
        public bool SaveAll()
        {
           return _ctx.SaveChanges() > 0;
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Order
               .Include(p => p.Items)
               .ThenInclude(p => p.Clothes)
               .Where(p => p.Id == id)
               .FirstOrDefault();

        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }
    }
}
