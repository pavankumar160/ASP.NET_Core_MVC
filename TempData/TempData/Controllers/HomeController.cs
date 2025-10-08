using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TempData.Models;

namespace TempData.Controllers
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
            TempData["Message"] = "Testing";
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
            var msg = TempData["Message"];
            //var msg2 = TempData.peek("Message");
            TempData.Keep("Message");
            ViewBag.Message = msg;
            return RedirectToAction("Display");
        }

        public IActionResult Display()
        {
            var msg = TempData["Message"];
            TempData.Keep("Message");
            ViewBag.Message = msg;
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
