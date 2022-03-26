using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class TechnicianController : Controller
    {
        public dbContect context { get; set; }

        public TechnicianController(dbContect ctx) => context = ctx;

        public IActionResult List()
        {
            var technician = context.Technician.OrderBy(p => p.TechnicianID).ToList();
            return View(technician);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Technician.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Technician technicians)
        {
            if (ModelState.IsValid)
            {
                if (technicians.TechnicianID == 0)
                {
                    context.Technician.Add(technicians);
                }
                else
                {
                    context.Technician.Update(technicians);
                }
            }
            else
            {
                ViewBag.Action = (technicians.TechnicianID == 0) ? "Add" : "Edit";
                return View(technicians);
            }
            context.SaveChanges();
            return RedirectToAction("List");
        }

    }
}