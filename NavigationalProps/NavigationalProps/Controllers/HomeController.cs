using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NavigationalProps.Models;

namespace NavigationalProps.Controllers
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
            
            var dept1 = new Department { DepartmentId = 1, DeptName = "Computer Science", students = new List<Student>()};
            var dept2 = new Department { DepartmentId = 2, DeptName = "Electrical", students = new List<Student>()};

            
            var students = new List<Student>
            {
                new Student { SId = 1, Name = "Pavan", Department = dept1 },
                new Student { SId = 2, Name = "Rahul", Department = dept1 },
                new Student { SId = 3, Name = "Arjun", Department = dept2 },
            };

            //  Add students to department (reverse link)
            dept1.students.AddRange(students.Where(s => s.Department == dept1));
            dept2.students.AddRange(students.Where(s => s.Department == dept2));

            
            return View(students);
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
