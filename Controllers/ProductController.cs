using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class ProductController : Controller
    {
        private dbContect context { get; set; }

        public ProductController(dbContect ctx) => context = ctx;

        public IActionResult List()
        {
            List<Product> products = context.Products.OrderBy(p => p.ProductID).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product products)
        {
            if (ModelState.IsValid)
            {
                if (products.ProductID == 0)
                {
                    context.Products.Add(products);
                }
                else
                {
                    context.Products.Update(products);
                }
            }
            else
            {
                ViewBag.Action = (products.ProductID == 0) ? "Add" : "Edit";
                return View(products);
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}