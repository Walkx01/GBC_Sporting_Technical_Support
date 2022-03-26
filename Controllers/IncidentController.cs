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


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
            ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
            ViewBag.Technician = context.Technician.OrderBy(t => t.name).ToList();
            return View("Edit", new Incident());
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
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
            }
            else
            {
                ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";
                ViewBag.Product = context.Products.OrderBy(p => p.name).ToList();
                ViewBag.Customer = context.Customers.OrderBy(c => c.firstName).ToList();
                ViewBag.Technician = context.Technician.OrderBy(t => t.name).ToList();
                return View(incident);
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}