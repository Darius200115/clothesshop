using System.ComponentModel.DataAnnotations;

namespace test_proj_843823.ViewModels
{
    public class ShopUserViewModel
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    


    }
}
