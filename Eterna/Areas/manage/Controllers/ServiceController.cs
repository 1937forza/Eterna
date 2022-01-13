using Eterna.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.Areas.manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private readonly DataContext _context;

        public ServiceController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid) return View();

            _context.Services.Add(service);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null) return NotFound();

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            if (!ModelState.IsValid) return View();
            Service existServe = _context.Services.FirstOrDefault(x => x.Id == service.Id);

            if (existServe == null) return NotFound();

            existServe.Title = service.Title;
            existServe.Desc = service.Desc;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);

            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Service service)
        {
            if (!ModelState.IsValid) return View();
            Service existServ = _context.Services.FirstOrDefault(x => x.Id == service.Id);

            if (existServ == null) return NotFound();

            _context.Services.Remove(existServ);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
