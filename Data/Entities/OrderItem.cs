namespace test_proj_843823.Data.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Clothes Clothes { get; set; }
        public int Quantity { get; set; }
        public decimal UnitePrice {get;set;}   
        public Order Orders { get; set; }

    }
}
