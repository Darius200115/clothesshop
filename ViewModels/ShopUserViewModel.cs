using System.ComponentModel.DataAnnotations;

namespace test_proj_843823.ViewModels
{
    public class ShopUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
