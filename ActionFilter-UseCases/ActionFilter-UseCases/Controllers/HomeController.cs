using System.Diagnostics;
using ActionFilter_UseCases.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter_UseCases.Controllers
{

    [ActionFilter_UseCases.Models.ActionFilter_UseCases]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Name = "Pavan")
        {
            int value1 = 10;
            int value2 = 0;
            int result = value1 / value2;

            return Content($"Result = {result}");
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
