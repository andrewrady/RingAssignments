using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RingAssigment.Models;

namespace RingAssigment.Controllers
{
    public class RingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ring.ToListAsync());
        }

    }
}
