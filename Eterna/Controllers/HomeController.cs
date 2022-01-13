using Eterna.Models;
using Eterna.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeView = new HomeViewModel
            {
                Services = _context.Services.ToList()
            };

            return View(homeView);
        }
    }
}
