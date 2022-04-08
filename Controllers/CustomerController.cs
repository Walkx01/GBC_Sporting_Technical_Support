using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class CustomerController : Controller
    {
        private dbContect context { get; set; }

        public CustomerController(dbContect ctx) => context = ctx;

        [Route("Customers")]
        public IActionResult List()
        {
            var customer = context.Customers.OrderBy(c => c.customerID).ToList();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Countries"] = context.Countries.OrderBy(c => c.Name).ToList();
            ViewBag.Action = "Add";
            return View("Edit", new Customer());
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
          
            ViewBag.Action = "Add";
            ViewData["Countries"] = context.Countries.OrderBy(c => c.Name).ToList();
            if (ModelState.IsValid)
            {
                if (context.Customers.Any(c => c.email == customer.email)) {
                    TempData["error"]  = " this email is arealdy registered: ";
                    return View("Edit", customer);
                }
                else
                {
                    TempData["message"] = "Successfully Added: " + customer.firstName + " " + customer.lastName;
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }

               
            }
            return View("Edit", customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Countries"] = context.Countries.OrderBy(c => c.Name).ToList();
            ViewBag.Action = "Edit";
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {

            ViewBag.Action = "Edit";
            if (ModelState.IsValid)
            {

                TempData["message"] = "Successfully Updated: " + customer.firstName + " " + customer.lastName;
                context.Customers.Update(customer);
                context.SaveChanges();
                return RedirectToAction("List");
            }
           
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var customers = context.Customers.FirstOrDefault(c => c.customerID == id);
            TempData["name"] = customers.firstName + " " + customers.lastName;
            return View(customers);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Customer customer)
        {
            TempData["message"] = "Successfully Deleted: " + customer.firstName + " " + customer.lastName;
            TempData["name"] = customer.firstName + " " + customer.lastName;
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

