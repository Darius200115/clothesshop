using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using test_proj_843823.Data;
using test_proj_843823.Data.Entities;
using test_proj_843823.ViewModels;


namespace test_proj_843823.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<ShopUser> _signinmanager;
        private readonly UserManager<ShopUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IClothesRepository _clothesRepository;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, SignInManager<ShopUser> signinmanager,
            UserManager<ShopUser> userManager, IConfiguration config, IClothesRepository repos, IMapper mapper)
        {

            _logger = logger;
            _signinmanager = signinmanager;
            _userManager = userManager;
            _configuration = config;
            _clothesRepository = repos;
            _mapper = mapper;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] ShopUserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = new ShopUser()
                    {
                        
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Email = user.Email
                    };
                    
                    var result = await _userManager.CreateAsync(newUser, user.Password);

                    if (result != IdentityResult.Success)
                    {
                        throw new InvalidOperationException("Could not create new user!");
                    }

                    return Created($"/api/account/{newUser.Id}", _mapper.Map<ShopUser, ShopUserViewModel>(newUser));
                    

                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Failed to register new account!");
            }
            return BadRequest("Failed to register new account!");

        }


        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] ShopUserViewModel model)
        {
            if (ModelState.IsValid)       
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user!=null)
                {
                    var result = await _signinmanager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)

                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            signingCredentials: creds,
                            expires: DateTime.Now.AddMinutes(30));

                        return Created("", new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }
            }          

            return BadRequest();
        }
 
        [HttpGet]
        public ActionResult<IEnumerable<ShopUser>> GetAllUsers()
        {
            try
            {
                return Ok(_clothesRepository.GetAllUsers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get Users list: {ex}");
                return BadRequest("Failed to get Users list");
            }
        }

    }
}
