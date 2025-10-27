using AuthorizationFilterInbuilt.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AuthorizationFilterInbuilt.Controllers
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
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> UserValidation([FromForm] UserInfo user)
        {
            if (user.UserName == "Pavan" && user.Password == "1234")
            {
                
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

               
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

               
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Profile");
            }

            if (user.UserName == "Pavan")
            {
                return Content("Invalid Password");
            }

            return Content("Invalid User Credentials");
        }

        [Authorize] 
        public IActionResult Profile()
        {
            
            var name = User.Identity?.Name;
            ViewBag.Name = name;
            return View();
        }

        public IActionResult AccessDenied()
        {
            return Content("Access Denied!");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
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
