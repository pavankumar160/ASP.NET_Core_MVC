using Microsoft.AspNetCore.Mvc;

namespace DynamicRendering.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
          return View();
        }

        public IActionResult LoadStudents() {

            var studentDetails = DynamicRendering.Models.Student.getStudents();
            return PartialView("StudentList", studentDetails);
        }
    }
}
