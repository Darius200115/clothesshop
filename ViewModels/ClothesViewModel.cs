using System.ComponentModel.DataAnnotations;

namespace test_proj_843823.ViewModels
{
    public class ClothesViewModel
    {
        public int ClothesId { get; set; }     
        public string Brand { get; set; } = string.Empty;       
        public string Category { get; set; }
        public string Size { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CountryManufacturer { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; }
        public int Count { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
