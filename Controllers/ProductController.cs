using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class ProductController : Controller
    {
        private dbContect context { get; set; }

        public ProductController(dbContect ctx) => context = ctx;

        [Route("Products")]
        public ViewResult List()
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

        [HttpPost]
        public IActionResult Add(Product product)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Added: " + product.name;
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("Edit", product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Updated: " + product.name;
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var products = context.Products.FirstOrDefault(c => c.ProductID == id);
            TempData["name"] = products.name;
            return View(products);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            TempData["message"] = "Successfully Deleted: " + product.name;
            TempData["name"] = product.name;
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

