using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace test_proj_843823.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }  
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
