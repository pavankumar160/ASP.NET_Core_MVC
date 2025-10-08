using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pratice.Models;

namespace Pratice.Controllers
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
            ViewData["Title"] = "Student List";
         //   ViewData["Total Students"] = 2;
            ViewBag.TotalStudents = 2;
            var student = new List<Student>()
            {
                new Student { Id = 1, Name = "Pavan", Marks = 90 },
                new Student { Id = 2, Name = "Bobby", Marks = 85 },
                new Student { Id = 3, Name = "Vishnu", Marks = 80 }

            };

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
