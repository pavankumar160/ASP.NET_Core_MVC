using System.Diagnostics;
using Cookies.Models;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Opening()
        {
           
            return View();

        }

        public IActionResult Index(string? Name)
        {
            //Creating Cookie

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(3),
                HttpOnly = true
            };

            Response.Cookies.Append("User", "Pavan", options);


            if (Request.Cookies["User"] == "Pavan")
            {
                TempData["Item1"] = "Phone";
                TempData["Item2"] = "TV";
                TempData["Item3"] = "Washing Machine";
                TempData.Peek("Item1");
                TempData.Peek("Item2");
                TempData.Peek("Item3");

                return View();
            }

            else
            {
                return Content($"Invalid User");
            }

            //Response.Cookies.Append("Theme", "Dark", options);

        }

        public IActionResult NextPage()
        {
            if (Request.Cookies["User"] == "Pavan")
            {
                TempData["Item4"] = "Laptop";
                return View();
            }
            else
            {
                return Content($"Invalid User");
            }

               
            
        }
        public IActionResult ReadCookie()
        {
            // Read cookies
            var user = Request.Cookies["User"];
            var theme = Request.Cookies["Theme"];

            ViewBag.User = user;
            ViewBag.Theme = theme;

            return View();
        }

        public IActionResult DeleteCookie()
        {
            // Delete cookie
            Response.Cookies.Delete("User");
            Response.Cookies.Delete("Theme");

            ViewBag.Message = "Cookies Deleted!";
            return View("ReadCookie");
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
