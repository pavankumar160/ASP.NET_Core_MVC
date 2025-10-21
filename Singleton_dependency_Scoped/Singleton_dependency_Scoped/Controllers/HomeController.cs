using Microsoft.AspNetCore.Mvc;
using Singleton_dependency_Scoped.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Singleton_dependency_Scoped.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICounterService _counter;
        public HomeController(ICounterService counter)
        {
            _counter = counter;
        }

        public IActionResult Index()
        {
            _counter.Increment();
            ViewBag.Count = _counter.GetCount();
            return View();
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
