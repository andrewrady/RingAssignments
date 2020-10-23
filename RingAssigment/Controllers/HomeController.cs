using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RingAssigment.Models;

namespace RingAssigment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public  HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _context.Ring
                .OrderBy(ring => ring.RingNumber)
                .ToListAsync();
            var activeRings = list
                .FindAll(ring => ring.Status == true);
            var inactiveRings = list
                .FindAll(ring => ring.Status == false);

            ViewBag.ActiveRings = activeRings;
            ViewBag.InactiveRings = inactiveRings;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
