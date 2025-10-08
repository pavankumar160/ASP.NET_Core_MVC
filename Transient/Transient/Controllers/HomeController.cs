using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Transient.Models;

namespace Transient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculator1;
        private readonly ICalculatorService _calculator2;

        //Service injection approches

        // 1] Constructor Injection
        public HomeController(ICalculatorService calculator1, ICalculatorService calculator2)
        {
            _calculator1 = calculator1;
            _calculator2 = calculator2;
        }

        // 2] Method Injection
        

        public IActionResult Calculate([FromServices] ICalculatorService calculator)
        {
            int result = calculator.Add(5, 4);
            return Content("Result: " + result);
        }


        // 3] Property Injection

        [FromServices]
        public ICalculatorService Calculator { get; set; }

        public IActionResult PropertyInjection()
        {
            int result = Calculator.Add(10, 15);
            return Content("Result: " + result);
        }
        public IActionResult Index()
        {
            //int result = _calculator1.Add(10, 20);
            _calculator2.data = 10;
            return Content($"{ _calculator1.data}");

          //  return Content($"Result = {result}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
