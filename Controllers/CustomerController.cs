using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class CustomerController : Controller
    {
        private dbContect context { get; set; }

        public CustomerController(dbContect ctx) => context = ctx;

        public IActionResult List()
        {
            var customer = context.Customers.OrderBy(c => c.customerID).ToList();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.customerID == 0)
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
            }
            else
            {
                ViewBag.Action = (customer.customerID == 0) ? "Add" : "Edit";
                return View(customer);
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}