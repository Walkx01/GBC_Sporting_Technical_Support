using A1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    public class IncidentController : Controller
    {
        private dbContect context { get; set; }

        public IncidentController(dbContect ctx) => context = ctx;

        [Route("Incident")]
        public IActionResult List(string filter = "all")
        {
            if (filter.ToLower() == "all")
            {
                var inci = context.Incidents
                    .Include(i => i.customer)
                    .Include(i => i.product)
                    .Include(i => i.technician)
                    .OrderBy(i => i.IncidentID)
                    .ToList();
                return View(inci);
            }
            else if (filter.ToLower() == "unassigned")
            {
                var inci = context.Incidents
                    .Include(i => i.customer)
                    .Include(i => i.product)
                    .Include(i => i.technician).Where(t => t.technicianID == null)
                    .OrderBy(i => i.IncidentID)
                    .ToList();
                return View(inci);
            }
            else
            {
                var inci = context.Incidents
                    .Include(i => i.customer)
                    .Include(i => i.product)
                    .Include(i => i.technician)
                    .OrderBy(i => i.IncidentID).Where(i => i.dateClosed == null)
                    .ToList();
                return View(inci);
            }
        }

        [HttpGet]
        public IActionResult Edit(string page = "", int? id = null)
        {
            if (page.ToLower() == "add")
            {
                TempData["action"] = "Add";
                var vm = new IncidentViewModel()
                {
                    Customer = context.Customers.ToList(),
                    Products = context.Products.ToList(),
                    Technicians = context.Technician.ToList(),
                    Incident = new Incident()
                };

                ViewBag.Customer = new SelectList(vm.Customer, "customerID", "firstName");
                ViewBag.Product = new SelectList(vm.Products, "ProductID", "name", vm.Incident.productID.ToString());
                ViewBag.Technician = new SelectList(vm.Technicians, "TechnicianID", "name", vm.Incident.technicianID.ToString());


                return View("Edit", vm);
            }
            else
            {
                TempData["action"] = "Edit";
                var vm = new IncidentViewModel()
                {
                    Customer = context.Customers.ToList(),
                    Products = context.Products.ToList(),
                    Technicians = context.Technician.ToList(),
                    Incident = context.Incidents.Find(id)
                };

                ViewBag.Customer = new SelectList(vm.Customer, "customerID", "firstName");
                ViewBag.Product = new SelectList(vm.Products, "ProductID", "name", vm.Incident.productID.ToString());
                ViewBag.Technician = new SelectList(vm.Technicians, "TechnicianID", "name", vm.Incident.technicianID.ToString());

                return View("Edit", vm);
            }
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel vm)
        {
            

            ViewBag.Customer = new SelectList(vm.Customer, "customerID", "firstName", selectedValue:vm.Incident.customerID.ToString());
            ViewBag.Product = new SelectList(vm.Products, "ProductID", "name", vm.Incident.productID.ToString());
            ViewBag.Technician = new SelectList(vm.Technicians, "TechnicianID", "name", vm.Incident.technicianID.ToString());
            if (ModelState.IsValid)
            {
                TempData["message"] = (vm.page == "add") ? "Successfully Added" + vm.Incident.title : "Successfully Updated" + vm.Incident.title;

                if (vm.page == "add")
                    context.Incidents.Add(vm.Incident);
                else
                    context.Incidents.Update(vm.Incident);

                context.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                TempData["action"] = (vm.page == "add") ? "Add" : "Edit";

                return View("Edit", vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var incident = context.Incidents.FirstOrDefault(c => c.IncidentID == id);
            TempData["title"] = incident.title;
            return View(incident);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Incident incident)
        {
            TempData["message"] = "Successfully Deleted incident: " + incident.title;
            TempData["title"] = incident.title;
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}