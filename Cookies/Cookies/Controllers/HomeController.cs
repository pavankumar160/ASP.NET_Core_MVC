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

        public IActionResult Index()
        {
            //Creating Cookie

            CookieOptions options = new CookieOptions { 
                Expires = DateTime.Now.AddMinutes(3),
                HttpOnly = true
                };
            Response.Cookies.Append("User", "Pavan", options);
            Response.Cookies.Append("Theme", "Dark", options);
            return View();
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
