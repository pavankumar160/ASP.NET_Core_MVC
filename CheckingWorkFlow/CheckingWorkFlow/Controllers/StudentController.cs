using CheckingWorkFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckingWorkFlow.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _config;

        public StudentController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getStudent(int? Id) {
            string? connectionString = _config.GetConnectionString("DB_Connection");
            List<StudentDetails> students = StudentDetails.getStudent(connectionString, Id);

            return View("Index",students);
        }
    }
}
