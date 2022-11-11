using System.ComponentModel.DataAnnotations;

namespace test_proj_843823.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitePrice { get; set; }

        [Required]
        public int ClothesId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; }       
        public decimal Price { get; set; }      
        public int Count { get; set; }     
    }
}