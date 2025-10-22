using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RequestResponseCookie.Models;

namespace RequestResponseCookie.Controllers
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
            CookieOptions options = new CookieOptions();
            options.Secure = true;
            options.Expires = DateTime.Now.AddMinutes(10);
            options.HttpOnly = true;

            Response.Cookies.Append("User", "Pavan", options);
            Response.Cookies.Append("User", "Bobby", options);

            return View();
        }

        public IActionResult NextPage()
        {
            if (Request.Cookies["User"] == "Pavan")
            { 
                ViewBag.user = Request.Cookies["user"];
                return View();
            }
            else
            {
                return Content("Invalid User...");
            }
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
