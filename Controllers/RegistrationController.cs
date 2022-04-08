using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class RegistrationController : Controller
    {

        private dbContect context { get; set; }

        public RegistrationController(dbContect ctx) => context = ctx;

        [Route("Registrations")]
        public ViewResult ListCustomers()
        {
            ViewBag.customers = context.Customers.OrderBy(p => p.firstName).ToList();
            return View();
        }

        public ViewResult CustomerRegistrations( int customerID)
        {
            Customer customer = context.Customers.FirstOrDefault(p=> p.customerID == customerID);
            ViewBag.customer = customer;
            Registration reg = context.Registrations.Where(r => r.customerId == customer.customerID).FirstOrDefault();

            return View(customer);
        }

    }
}
