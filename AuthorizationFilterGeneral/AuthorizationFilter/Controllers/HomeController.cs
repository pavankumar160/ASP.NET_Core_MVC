using System.Diagnostics;
using AuthorizationFilter.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationFilter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserValidation([FromForm] UserInfo user)
        {
            if(user.UserName == "Pavan" && user.Password == "1234")
            {
                TempData["Name"] = user.UserName;

                return RedirectToAction("Profile");
            }

            if (user.UserName == "Pavan")
            {
                return Content("Invalid Password");
            }

            return Content("Invalid User Credentials");
        }
        public  IActionResult Profile()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
