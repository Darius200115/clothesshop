using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_proj_843823.Data.Entities
{
    
    public class ShopUser : IdentityUser
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
