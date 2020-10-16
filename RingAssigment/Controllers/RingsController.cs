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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ring.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ring = await _context.Ring.FindAsync(id);
            if(ring == null)
            {
                return NotFound();
            }

            return View(ring);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ring ring)
        {
            if(id != ring.Id)
            {
                return NotFound(); 
            }
            if(ModelState.IsValid)
            {
                 _context.Update(ring);
                 await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Edit));
            }

            return RedirectToAction(nameof(Edit));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ring ring)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            _context.Ring.Add(ring);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var ring = await _context.Ring.FindAsync(id);

            if(ring == null)
            {
                return NotFound();
            }

            _context.Remove(ring);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }

    }
}
