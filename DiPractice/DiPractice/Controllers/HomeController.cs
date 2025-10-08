using System.Diagnostics;
using DiPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculatorService1;
        private readonly ICalculatorService _calculatorService2;
       
        public HomeController(ICalculatorService calculator1, ICalculatorService calculator2)
        {
            _calculatorService1 = calculator1;
            _calculatorService2 = calculator2;
           
        }
         
        public IActionResult Index()
        {
            // int Sum = _calculatorService1.Add(2, 3);
            _calculatorService1.Data = 10;
            return View();
           // return Content(_calculatorService2.Data.ToString());
        }

        [HttpGet]
        public IActionResult Privacy()
        {

            return Content(_calculatorService2.Data.ToString());
        }

    }
}
