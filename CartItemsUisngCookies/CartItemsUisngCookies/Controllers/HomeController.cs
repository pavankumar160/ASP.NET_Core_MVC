using System.Diagnostics;
using CartItemsUisngCookies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CartItemsUisngCookies.Controllers
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
            var Items = new Dictionary<string, string>()
            {
                {"Item1", "Phone"},
                {"Item2", "TV"}
            };

            CookieOptions options = new CookieOptions();

            options.Secure = true;
            options.HttpOnly = true;
            options.Expires = DateTime.Now.AddDays(1);

            string jsonString = JsonSerializer.Serialize(Items);
            Response.Cookies.Append("PavanCart", jsonString);

            return View();
        }

        public IActionResult NextPage()
        {
            if(Request.Cookies.TryGetValue("PavanCart", out string? CookieValue))
            {

                return View(model : CookieValue);
            }

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
