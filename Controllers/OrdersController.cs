using Microsoft.AspNetCore.Mvc;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IClothesRepository _clothesRepository;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(ILogger<OrdersController> logger, IClothesRepository repository)
        {
            _clothesRepository = repository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return Ok(_clothesRepository.GetAllOrders());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get orders {ex}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpGet("{id:int}")] 
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var orders = _clothesRepository.GetOrderById(id);
                if (orders != null)
                    return Ok(orders);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order {ex}");
                return BadRequest("Failed to get order");
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderDate = model.OrderDate,
                        OrderNumber = model.OrderNumber,
                        Id = model.OrderId                   
                    };

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _clothesRepository.AddEntity(newOrder);
                    if (_clothesRepository.SaveAll())
                    {
                        var vm = new OrderViewModel()
                        {
                            OrderId = newOrder.Id,
                            OrderDate = newOrder.OrderDate,
                            OrderNumber = newOrder.OrderNumber
                        };

                        return Created($"/api/orders/{vm.OrderId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order {ex}");

            }
            return BadRequest("Failed to save a new order");
        }
    }
}
