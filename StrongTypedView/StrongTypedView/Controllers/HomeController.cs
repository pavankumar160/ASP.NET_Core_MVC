using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StrongTypedView.Models;

namespace StrongTypedView.Controllers
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
            var student = new Student
            {
                Id = 1,
                Name = "Pavan",
                Age = 21
            };

            ViewData["Id"] = 1;
            ViewData["Name"] = "Pavan";
            ViewData["Age"] = 21;

            ViewBag.Id = 1;
            ViewBag.Name = "Pavan";
            ViewBag.Age = 21;

            return View(student);
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