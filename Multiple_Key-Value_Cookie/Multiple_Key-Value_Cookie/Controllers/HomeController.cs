using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Multiple_Key_Value_Cookie.Models;
using System.Text.Json;

namespace Multiple_Key_Value_Cookie.Controllers
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
            var KeyValuePairs = new Dictionary<string, string>() {
                {"User", "Pavan"},
                {"Theme", "Dark"}
            };
            string jsonString = JsonSerializer.Serialize(KeyValuePairs);
            Response.Cookies.Append("UserSettings", jsonString);
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
