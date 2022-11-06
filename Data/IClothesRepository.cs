using test_proj_843823.Data.Entities;

namespace test_proj_843823.Data
{
    public interface IClothesRepository
    {
        IEnumerable<Clothes> GetAllClothes();
        IEnumerable<Clothes> GetClothesByCategory(string category);
        bool SaveChanges();
    }
}