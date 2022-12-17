using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;

namespace test_proj_843823.Controllers
{
    [Route("api/[Controller]")]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesRepository _repos;
        private readonly ILogger<ClothesController> _logger;
        private readonly IMapper _mapper;

        public ClothesController(IClothesRepository repos, ILogger<ClothesController> logger, IMapper mapper)
        {
            _repos = repos;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clothes>> GetAllClothes()
        {
            try
            {
                return Ok(_repos.GetAllClothes());
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get products: {ex}" );
                return BadRequest("Failed to get products");
            }       
        }

        [HttpGet("{category}")]
        public ActionResult<IEnumerable<Clothes>> GetClothesByCategory(string category)
        {
            try
            {
                return Ok(_repos.GetClothesByCategory(category));
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get clothes: {ex}");
                return BadRequest("Failed to get clothes");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]ClothesViewModel model)            
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newClothes = _mapper.Map<ClothesViewModel, Clothes>(model);

                    _repos.AddEntity(newClothes);
                    if (_repos.SaveAll())
                    {
                        return Created($"/api/clothes/{newClothes.ClothesId}", _mapper.Map<Clothes, ClothesViewModel>(newClothes));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to post new product!");
               
            }
            return BadRequest("Failed to post new product!");
        }
    }
}
