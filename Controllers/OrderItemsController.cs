using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Controllers
{
    [Route("api/orders/{OrderId}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IClothesRepository _repos;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IClothesRepository repos, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repos.GetOrderById(orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repos.GetOrderById(orderId);

            if (order != null)
            {
                var item = order.Items.Where(p=>p.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
                }
            }

            return NotFound();
        }
    }
}
