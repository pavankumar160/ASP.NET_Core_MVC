using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewBag.Models;

namespace ViewBag.Controllers
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
            ViewData["StudentName"] = "Pavan";
            ViewData["College"] = "VNR VJIET";
            ViewData["Marks"] = 95;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
