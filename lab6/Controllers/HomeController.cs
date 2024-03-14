using Microsoft.AspNetCore.Mvc;
using lab6.Models;

namespace lab6.Controllers
{
    public class HomeController : Controller
    {
        public List<Product> products = new List<Product>
        {
            new Product { Name = "Freddy's pizza", Price = 10.0f },
            new Product { Name = "Chica's pizza", Price = 20.0f },
            new Product { Name = "Bonny's pizza", Price = 30.0f }
        };
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int number)
        {
            if (number > 0)
            {
                ViewData["Products"] = products;
                ViewData["Number"] = number;
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Please enter a value greater than zero.");
                return View("Amount");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else if (!model.IsAgeAcceptable())
            {
                ModelState.AddModelError("Age", "You must be 16 y.o. at least");
                return View(model);
            }
            else if (model.IsAgeAcceptable())
            {
                return RedirectToAction("Amount", "Home");
            }
            return View(model);
        }
        public IActionResult Amount()
        {
            return View();
        }
        public IActionResult Final()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Final1(IFormCollection form)
        {
            var numberOfForms = Convert.ToInt32(form["num"]);
            List<Product> orderProducts = new List<Product>();

            for (int i = 0; i < numberOfForms; i++)
            {
                int index = Convert.ToInt32(form["prodName"][i]);
                int amount = Convert.ToInt32(form["amount"][i]);

                Product product = new Product
                {
                    Name = products[index].Name,
                    Price = products[index].Price,
                    Amount = amount
                };

                orderProducts.Add(product);
            }
            
            ViewData["Order"] = orderProducts;
            return View("Final");
        }
    }
}
