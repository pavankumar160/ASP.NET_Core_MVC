using System.Diagnostics;
using ActionFilter_LoginExecutionTime.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter_LoginExecutionTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ActionFilter_LoginExecutionTime.Models.LogExecutionTimeFilter]
        public IActionResult Index()
        {

            return View();
        }
      //  public async Task<IActionResult> Index()
        //{
        //    await Task.Delay(5000); // Wait asynchronously for 5 seconds
        //    return View();
        //}

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
