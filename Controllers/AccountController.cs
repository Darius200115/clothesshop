using Microsoft.AspNetCore.Mvc;

namespace test_proj_843823.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
