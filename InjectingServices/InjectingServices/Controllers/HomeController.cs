using System.Diagnostics;
using InjectingServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace InjectingServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculator1;
        private readonly ICalculatorService _calculator2;

        public HomeController(ICalculatorService calculator1, ICalculatorService calculator2)
        {
            _calculator1 = calculator1;
            _calculator2 = calculator2;
            
        }

        public IActionResult Index()
        {
            int result = _calculator1.Add(5, 7);
            _calculator1.data = 10;
            _calculator2.data = 20;
             return Content("Result = " + _calculator1.data);
            //  return View("Index", result);
        }

        public IActionResult Privacy()
        {
           
           // return Content("Result = " +  _calculator1.data);
             return View();
        }

       
    }
}
