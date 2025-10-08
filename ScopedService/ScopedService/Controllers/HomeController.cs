using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScopedService.Models;

namespace ScopedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cart;
        public HomeController(ICartService cart)
        {
            _cart = cart;
        }

        public IActionResult Index()
        {
            _cart.AddToCart("Laptop");
            _cart.AddToCart("Phone");
            _cart.AddToCart("Washing Machine");
            var r = _cart.GetCart();
            return View(r);
        }

        [HttpGet]
        public IActionResult Index2([FromServices] ICartService _cart2)
        {
            _cart2.AddToCart("Pen");
            _cart2.AddToCart("Pencil");

            var r2 = _cart2.GetCart();

            return View(r2);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
