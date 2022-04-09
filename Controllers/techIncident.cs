using A1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    public class techIncident : Controller
    {
        public dbContect context { get; set; }

        public techIncident(dbContect ctx) => context = ctx;
        public ViewResult ListTechnicians()
        {
            ViewBag.Action = "ListSpecificIncdient";
            ViewBag.technicians = context.Technician.OrderBy(p => p.TechnicianID).ToList();
            return View();
        }

        public IActionResult ListSpecificIncdient(int TechnicianId)
        {
     
            var incident = context.Incidents
                .Include(i => i.customer)
                .Include(i => i.product)
                .Include(i => i.technician).Where(i => i.technicianID == TechnicianId).
                ToList();
          
            return View("techIncident", incident);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Incident? incident = context.Incidents.Include(i => i.customer)
                            .Include(i => i.product)
                            .Include(i => i.technician).Where(i => i.technicianID == id).FirstOrDefault();
            ViewBag.Product = context.Products.ToList();
            ViewBag.Customer = context.Customers.ToList();
            ViewBag.Technician = context.Technician.ToList();

            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            ViewBag.Product = context.Products.ToList();
            ViewBag.Customer = context.Customers.ToList();
            ViewBag.Technician = context.Technician.ToList();
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Updated incident: " + incident.title;
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("ListTechnicians");
            }
          
            return View(incident);
        }
    }
}
