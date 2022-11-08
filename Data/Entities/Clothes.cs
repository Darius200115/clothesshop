using System.Data;

namespace test_proj_843823.Data.Entities
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Size { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CountryManufacturer  { get; set; }   
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; }
        public int Count { get; set; }
        public DateTime DeliveryDate { get; set; }


    }
}
