using System.Diagnostics;
using ASP.NetCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCodeFirst.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            StudentOperations.Operations();
            return View();
        }

        
    }
}
