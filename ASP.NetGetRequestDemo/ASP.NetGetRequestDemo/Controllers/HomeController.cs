using System.Diagnostics;
using ASP.NetGetRequestDemo.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NetGetRequestDemo.Controllers
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
        public IActionResult GetStudents() {

            string connectionString = _config.GetConnectionString("DbConnection");


            List<Student> students = Student.getAllStudents(connectionString);

            return View("Index", students);


        }


        [HttpPost]
        public IActionResult GetStudent()
        {

            string connectionString = _config.GetConnectionString("DbConnection");


            List<Student> students = Student.getStudent(connectionString);

            return View("Index", students);


        }

    }
}
