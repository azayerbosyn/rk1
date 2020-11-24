using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mid.Models;

namespace mid.Controllers
{
    public class CalculationsController : Controller
    {
        private readonly ApplicationContext _context;

        public CalculationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Calculations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Calculations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.Categories
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculation == null)
            {
                return NotFound();
            }

            return View(calculation);
        }

        // GET: Calculations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calculations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,decision,dateTime")] Calculation calculation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculation);
        }

        // GET: Calculations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.Categories.FindAsync(id);
            if (calculation == null)
            {
                return NotFound();
            }
            return View(calculation);
        }

        // POST: Calculations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,decision,dateTime")] Calculation calculation)
        {
            if (id != calculation.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculationExists(calculation.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calculation);
        }

        // GET: Calculations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculation = await _context.Categories
                .FirstOrDefaultAsync(m => m.id == id);
            if (calculation == null)
            {
                return NotFound();
            }

            return View(calculation);
        }

        // POST: Calculations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var calculation = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(calculation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculationExists(long id)
        {
            return _context.Categories.Any(e => e.id == id);
        }
    }
}
