using Microsoft.AspNetCore.Mvc;
using System.Collections;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;

namespace test_proj_843823.Controllers
{
    [Route("api/[Controller]")]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesRepository _repos;
        private readonly ILogger<ClothesController> _logger;

        public ClothesController(IClothesRepository repos, ILogger<ClothesController> logger)
        {
            _repos = repos;
            _logger = logger;
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
    }
}
