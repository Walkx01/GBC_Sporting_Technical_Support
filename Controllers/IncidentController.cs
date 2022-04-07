using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    public class IncidentController : Controller
    {
        private dbContect context { get; set; }

        public IncidentController(dbContect ctx) => context = ctx;

        [Route("Incidents")]
        public IActionResult List()
        {
            var incident = context.Incidents
                .Include(i => i.customer)
                .Include(i => i.product)
                .Include(i => i.technician)
                .OrderBy(i => i.IncidentID)
                .ToList();
            return View(incident);
        }

        public IActionResult ListSpecificIncdient()
        {
            var incident = context.Incidents
                .Include(i => i.customer)
                .Include(i => i.product)
                .Include(i => i.technician).Where(i => i.technicianID == 1).
                ToList();
            return View("pag1",incident);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Product = context.Products.ToList();
            ViewBag.Customer = context.Customers.ToList();
            ViewBag.Technician = context.Technician.ToList();
            return View("Edit", new Incident());
        }

        [HttpPost]
        public IActionResult Add(Incident incident)
        {
            ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
            ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.name).ToList();
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Added incident: " + incident.title + " " + incident.title;
                context.Incidents.Add(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("Edit", incident);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
            ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.name).ToList();
            var incident = context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Updated incident: " + incident.title;
                context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            //ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
            //ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
            //ViewBag.Technician = context.Technician.OrderBy(t => t.name).ToList();
            return View(incident);
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