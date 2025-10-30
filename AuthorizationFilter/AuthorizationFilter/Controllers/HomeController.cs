using System.Diagnostics;
using AuthorizationFilter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Principal;


namespace AuthorizationFilter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserValidation([FromForm] UserInfo user)
        {
            if (user.UserName == "Pavan" && user.Password == "1234")
            {
                // Use a simple identity
                var identity = new GenericIdentity(user.UserName, "MyCookieAuth");
                var principal = new GenericPrincipal(identity, null);

                //Sign in user using cookie authentication
                await HttpContext.SignInAsync("MyCookieAuth", principal);

                TempData["Name"] = user.UserName;
                return RedirectToAction("Profile");
            }

            if (user.UserName == "Pavan")
            {
                return Content("Invalid Password");
            }

            return Content("Invalid User Credentials");
        }

        [Authorize(AuthenticationSchemes = "MyCookieAuth")]
        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
