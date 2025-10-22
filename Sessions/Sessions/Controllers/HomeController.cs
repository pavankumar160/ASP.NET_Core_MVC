using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sessions.Models;

namespace Sessions.Controllers
{
    /*public class HomeController : Controller
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }*/

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username)
        {
            HttpContext.Session.SetString("UserName", username);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            string? user = HttpContext.Session.GetString("UserName");
            if (user == null)
            {
                return RedirectToAction("Index"); // Redirect to login if session expired
            }

            ViewBag.User = user;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

}
