using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceInjectionAIO.Models;

namespace ServiceInjectionAIO.Controllers
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
            var result = _calculatorService1.Add(10, 15);
            _calculatorService1.Data = 10;
            return View(_calculatorService1);
            //return View();

        }

        [HttpPost]
        public IActionResult Scoped([FromServices] ICalculatorService calculator)
        {
            return View(_calculatorService1);
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
