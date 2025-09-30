using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {   
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStudents()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            // Call the static method in Student.cs
            List<Student> students = Student.GetAllStudents(connectionString);

            return View("Index", students);
        }

    //    [HttpPost]

        public IActionResult Testing()
        {
            return View();
        }
    }
}
