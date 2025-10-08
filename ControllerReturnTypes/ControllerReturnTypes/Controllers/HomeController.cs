using System.Diagnostics;

using ControllerReturnTypes.Models;

using Microsoft.AspNetCore.Mvc;

namespace ControllerReturnTypes.Controllers
{
    class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class HomeController : Controller
    {
        public HomeController()

        {

        }


        //Redirect Result

        //Redirects to a URL.

        public IActionResult Index1()

        {

            return Redirect("https://www.youtube.com/");

        }


        //View Result(.cshtml)

        //Renders a View (.cshtml).

        public IActionResult Index()
        {
            return View();
        }


        //Content Result
        //Returns plain string/text.

        public IActionResult Index3()
        {
            return Content("Content Result Demo");
        }



        //Empty Result
        public IActionResult Index4()
        {
            return new EmptyResult();
        }



        //Status Code Result
        //Returns just an HTTP status code.

        public IActionResult Index6()
        {
            //return StatusCode(404); // Not Found

            return StatusCode(500); // Internal Server Error
        }


        //File Result

        //Returns a file (download or display).

       /* public IActionResult Index7()

        {

            var filePath = "C:\Users\Pavan Madapu\Pictures\Screenshots";

            var mimeType = "image/jpeg";

            var fileName = Path.GetFileName(filePath);

            return PhysicalFile(filePath, mimeType, fileName);

        }*/

        // PartialViewResult
        // Renders a partial view (used inside another view).

        public IActionResult Index8() {
            return PartialView("~/Views/Home/Privacy.cshtml");
        }

        
        //RedirectToActionResult
        //Redirects to another action in the same or different controller.

        public IActionResult Index9() { 
        
            return RedirectToAction("Index1", "Home");
        
        }

        //ObjectResult (commonly used in APIs)
        //Returns any object, automatically serialized.

        public IActionResult Index10() {
            return Ok(new { Message = "Success" });   // 200 OK
            //return BadRequest("Invalid request");     // 400 Bad Request
          //  return NotFound();                        // 404 Not Found

        }

        //XML

        public IActionResult Index11() {
            string xml = "<Student><Id>1</Id><Name>Pavan</Name></Student>";
            return Content(xml, "application/xml");
        }

        //JSON

        public IActionResult Index12() {

            // return Json(new {Name = "Pavan", Age = 22});// Json serializer concerts C#  object into JSON string

            //JSON inside a view

            var student = new Student { Id = 1, Name = "Pavan", Age = 22 };
            return View(student);  // passing object to view

        }

    }

}

