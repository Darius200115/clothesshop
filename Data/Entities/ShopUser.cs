using Microsoft.AspNetCore.Identity;

namespace test_proj_843823.Data.Entities
{
    public class ShopUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
