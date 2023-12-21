using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MesDoigtsDeFees.Data;
using MesDoigtsDeFees.Models;

namespace MesDoigtsDeFees.Controllers
{
    public class TrajectsController : Controller
    {
        private readonly MyDBContext _context;

        public TrajectsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Trajects
        public async Task<IActionResult> Index()
        {
              return _context.Richtings != null ? 
                          View(await _context.Richtings
                          .Where(t => t.Ended == DateTime.MaxValue)
                          .ToListAsync()) :
                          Problem("Entity set 'MesDoigtsDeFeesContext.Traject'  is null.");
        }

        // GET: Trajects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Richtings == null)
            {
                return NotFound();
            }

            var traject = await _context.Richtings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traject == null)
            {
                return NotFound();
            }

            return View(traject);
        }

        // GET: Trajects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trajects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Started,Ended")] Richting traject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traject);
        }

        // GET: Trajects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Richtings == null)
            {
                return NotFound();
            }

            var traject = await _context.Richtings.FindAsync(id);
            if (traject == null)
            {
                return NotFound();
            }
            return View(traject);
        }

        // POST: Trajects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Started,Ended")] Richting traject)
        {
            if (id != traject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrajectExists(traject.Id))
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
            return View(traject);
        }

        // GET: Trajects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Richtings == null)
            {
                return NotFound();
            }

            var traject = await _context.Richtings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (traject == null)
            {
                return NotFound();
            }

            return View(traject);
        }

        // POST: Trajects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Richtings == null)
            {
                return Problem("Entity set 'MesDoigtsDeFeesContext.Traject'  is null.");
            }
            var traject = await _context.Richtings.FindAsync(id);
            if (traject != null)
            {
                traject.Ended = DateTime.Now;
                _context.Richtings.Update(traject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrajectExists(int id)
        {
          return (_context.Richtings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
