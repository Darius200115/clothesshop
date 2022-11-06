using test_proj_843823.Data.Entities;

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
        public bool SaveChanges()
        {
           return _ctx.SaveChanges() > 0;
        }
    }
}
