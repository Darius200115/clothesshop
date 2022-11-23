using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Controllers
{
    [Route("api/[Controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly IClothesRepository _clothesRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;
        public OrdersController(ILogger<OrdersController> logger, IClothesRepository repository, IMapper mapper)
        {
            _clothesRepository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders(bool includeItems = true)
        {
            try
            {
                var result = _clothesRepository.GetAllOrders(includeItems);
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(result));
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
                    return Ok(_mapper.Map<Order, OrderViewModel>(orders));
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
                    var newOrder = _mapper.Map<OrderViewModel, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _clothesRepository.AddEntity(newOrder);
                    if (_clothesRepository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Order, OrderViewModel>(newOrder));
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
