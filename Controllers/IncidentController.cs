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


        //[HttpGet]
        //public IActionResult Add()
        //{
        //    ViewBag.Action = "Add";
        //    var vm = new IncidentViewModel();
        //    ViewBag.Product = context.Products.ToList();
        //    ViewBag.Customer = context.Customers.ToList();
        //    ViewBag.Technician = new SelectList(context.Technician, "TechnicianID", "name");
        //    return View("Edit", new Incident());
        //}

        //[HttpPost]
        //public IActionResult Add(Incident incident)
        //{
        //    ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
        //    ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
        //    ViewBag.Technician = new SelectList(context.Technician, "TechnicianID", "name");
        //    ViewBag.Action = "Add";
        //    if (ModelState.IsValid)
        //    {
        //        TempData["message"] = "Successfully Added incident: " + incident.title + " " + incident.title;
        //        context.Incidents.Add(incident);
        //        context.SaveChanges();
        //        return RedirectToAction("List");
        //    }
        //    return View("Edit", incident);
        //}

        [HttpGet]
        public IActionResult Edit(string page = "", int? id = null)
        {
            var vm = new IncidentViewModel();

            if (page.ToLower() == "add")
            {
                TempData["action"] = "Add";
                vm.page = "add";
                ViewBag.Product = new SelectList(context.Products, "ProductID", "code");
                ViewBag.Customer = new SelectList(context.Customers, "customerID", "firstName");
                ViewBag.Technician = new SelectList(context.Technician, "TechnicianID", "name");
                return View("Edit", vm);
            }
            else
            {
                TempData["action"] = "Edit";
                vm.page = "edit";
                ViewBag.Product = new SelectList(context.Products, "ProductID", "code");
                ViewBag.Customer = new SelectList(context.Customers, "customerID", "firstName");
                ViewBag.Technician = new SelectList(context.Technician, "TechnicianID", "name");
                vm.Incident = context.Incidents.Find(id);
                return View(vm);
            }
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel vm)
        {
            TempData["product"] = vm.Incident.productID;

            if (vm.page == "add")
            {
                if (ModelState.IsValid)
                {

                    TempData["message"] = "Successfully Added incident: " + vm.Incident.title + " " + vm.Incident.title;
                    context.Incidents.Add(vm.Incident);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["action"] = "Add";
                    return View("Edit", vm);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    TempData["message"] = "Successfully Updated incident: " + vm.Incident.title;
                    context.Incidents.Update(vm.Incident);
                    context.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["action"] = "Edit";
                    return View("Edit", vm);
                }
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