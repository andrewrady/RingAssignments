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
            var activeRings = await _context.Ring
                .Where(ring => ring.Status == true)
                .OrderBy(ring => ring.RingNumber)
                .ToListAsync();
            var inactiveRings = await _context.Ring
                .Where(ring => ring.Status == false)
                .OrderBy(ring => ring.RingNumber)
                .ToListAsync();
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
