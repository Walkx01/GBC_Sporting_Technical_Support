using A1.Models;
using Microsoft.AspNetCore.Mvc;

namespace A1.Controllers
{
    public class TechnicianController : Controller
    {
        public dbContect context { get; set; }

        public TechnicianController(dbContect ctx) => context = ctx;


        public ViewResult ListTechnicians()
        {
            List<Technician> technician = context.Technician.OrderBy(p => p.TechnicianID).ToList();
            return View("page1" ,technician);
        }

        [Route("Technicians")]
        public ViewResult List()
        {
            List<Technician> technician = context.Technician.OrderBy(p => p.TechnicianID).ToList();
            return View(technician);
        }

      

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpPost]
        public IActionResult Add(Technician technician)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Added: " + technician.name;
                context.Technician.Add(technician);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("Edit", technician);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technician.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Successfully Updated: " + technician.name;
                context.Technician.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var technicians = context.Technician.FirstOrDefault(c => c.TechnicianID == id);
            TempData["name"] = technicians.name;
            return View(technicians);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Technician technician)
        {
            TempData["message"] = "Successfully Deleted: " + technician.name;
            TempData["name"] = technician.name;
            context.Technician.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}