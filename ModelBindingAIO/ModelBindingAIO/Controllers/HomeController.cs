using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelBindingAIO.Models;

namespace ModelBindingAIO.Controllers
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

        public IActionResult ModelBinding_Route([FromRoute] string Id)
        {
            //return View(model : Id);
            return Content(Id);
        }

        public IActionResult ModelBinding_Query([FromQuery]string Name, [FromQuery]string Id)
        {
            return Content($"Name : {Name}, Id : {Id}");
        }

        [HttpGet]
        public IActionResult ModelBinding_Form([FromForm] StudentData student)
        {
            return View(student);
        }

        [HttpPost]
        public IActionResult ModelBinding_Form_Bind([FromForm][Bind("sd")] sdData data)
        {
            return View(data);
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
