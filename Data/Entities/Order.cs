namespace test_proj_843823.Data.Entities
{
    public class Order
    {
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; }
        public string? OrderNumber { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ShopUser User { get; set; }
        
    }
}
