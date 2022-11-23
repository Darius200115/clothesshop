using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Data
{
    public interface IClothesRepository
    {
        IEnumerable<Clothes> GetAllClothes();
        IEnumerable<Clothes> GetClothesByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        void AddEntity(object model);
        bool SaveAll();
        IEnumerable<ShopUser> GetAllUsers();
    }
}