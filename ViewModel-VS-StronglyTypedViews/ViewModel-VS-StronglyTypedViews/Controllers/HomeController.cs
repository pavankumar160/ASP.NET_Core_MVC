using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_VS_StronglyTypedViews.Models;

namespace ViewModel_VS_StronglyTypedViews.Controllers
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

        public IActionResult Dashboard()
        {
            var student = new Student
            {
                Name = "Pavan",
                Age = 22
            };
            var course = new Course { CName = "Data Science" };
            var vm = new StudentDashboardViewModel
            {
                StudentName = student.Name,
                CourseTitle = course.CName
            };

            return View(vm);

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
