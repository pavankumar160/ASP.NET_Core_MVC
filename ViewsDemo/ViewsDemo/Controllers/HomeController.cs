using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers
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
            
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Pavan" },
                new Student { Id = 2, Name = "Ravi" },
                new Student { Id = 3, Name = "Sita" }
            };

            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
