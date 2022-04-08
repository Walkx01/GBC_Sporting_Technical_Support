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
            List<Customer> customers = context.Customers.OrderBy(p => p.firstName).ToList();
            return View(customers);
        }

        public ViewResult CustomerRegistrations( Customer customer)
        {
            Registration reg = context.Registrations.Where(r => r.customerId == customer.customerID).Single();

            return View(reg);
        }

    }
}
