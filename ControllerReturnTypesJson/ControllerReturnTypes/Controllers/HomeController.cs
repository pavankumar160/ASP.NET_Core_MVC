using ControllerReturnTypes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ControllerReturnTypes.Controllers
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
            //var student = new { Name = "Pavan", Age = 22 };
            //string jsonData = JsonSerializer.Serialize(student);
            // return View("Index", jsonData);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetStudentJson()
        {
            return Json(new { Name = "Pavan", Age = 22 });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
