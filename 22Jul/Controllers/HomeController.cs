using _22JUL.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22JUL.Controllers
{
    public class HomeController : Controller
    {
        // Display form
        public IActionResult Index()
        {
            return View();
        }

        // Receive form data
        [HttpPost]
        public IActionResult Index(Product product)
        {
            if (ModelState.IsValid)
            {
                return Content(
                    $"Stationaryitem : {product.Stationaryitem}, " +
                    $"Price : {product.Price}, " +
                    $"Category : {product.Category}, " +
                    $"Stock : {product.Stock}"
                );
            }

            return View(product);
        }
    }
}
