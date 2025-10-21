using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;
using System.Diagnostics;

namespace StateManagement.Controllers
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
            // ViewData
            ViewData["Course"] = "ASP.NET Core MVC";

            // ViewBag
            ViewBag.Student = "Pavan";

            // TempData
            TempData["Message"] = "Welcome back!";

            // Session
            HttpContext.Session.SetString("User", "Pavan123");


            // Cookies
            Response.Cookies.Append("UserCity", "Hyderabad");

            return View();
        }

        public IActionResult NextPage()
        {
            // Accessing TempData (persists across redirect)
            ViewBag.TempMessage = TempData["Message"];

            // Accessing session and cookie
            ViewBag.SessionUser = HttpContext.Session.GetString("User");
            ViewBag.CookieCity = Request.Cookies["UserCity"];

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
