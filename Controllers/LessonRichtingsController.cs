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
    public class LessonRichtingsController : Controller
    {
        private readonly MyDBContext _context;

        public LessonRichtingsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: LessonRichtings
        public async Task<IActionResult> Index()
        {
            var mesDoigtsDeFeesContext = _context.LessonRichtings
                .Include(l => l.Lesson)
                .Include(l => l.Richting)
                .Where(l => l.Ended == DateTime.MaxValue);
            return View(await mesDoigtsDeFeesContext.ToListAsync());
        }

        // GET: LessonRichtings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LessonRichtings == null)
            {
                return NotFound();
            }

            var lessonRichting = await _context.LessonRichtings
                .Include(l => l.Lesson)
                .Include(l => l.Richting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonRichting == null)
            {
                return NotFound();
            }

            return View(lessonRichting);
        }

        // GET: LessonRichtings/Create
        public IActionResult Create()
        {
            ViewBag.LessonId = new SelectList(_context.Lessons.ToList(), "Id", "Name");
            ViewBag.RichtingId = new SelectList(_context.Richtings.ToList(), "Id", "Name");
            return View();
        }

        // POST: LessonRichtings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LessonId,LessonName,RichtingId,RichtingName")] LessonRichting lessonRichting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lessonRichting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.LessonId = new SelectList(_context.Lessons.ToList(), "Id", "Name", lessonRichting.LessonId);
            ViewBag.RichtingId = new SelectList(_context.Richtings.ToList(), "Id", "Name", lessonRichting.RichtingId);
            return View(lessonRichting);
        }

        // GET: LessonRichtings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LessonRichtings == null)
            {
                return NotFound();
            }

            var lessonRichting = await _context.LessonRichtings.FindAsync(id);
            if (lessonRichting == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", lessonRichting.LessonId);
            ViewData["RichtingId"] = new SelectList(_context.Richtings, "Id", "Id", lessonRichting.RichtingId);
            return View(lessonRichting);
        }

        // POST: LessonRichtings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LessonId,LessonName,RichtingId,RichtingName")] LessonRichting lessonRichting)
        {
            if (id != lessonRichting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lessonRichting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonRichtingExists(lessonRichting.Id))
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
            ViewData["LessonId"] = new SelectList(_context.Lessons, "Id", "Id", lessonRichting.LessonId);
            ViewData["RichtingId"] = new SelectList(_context.Richtings, "Id", "Id", lessonRichting.RichtingId);
            return View(lessonRichting);
        }

        // GET: LessonRichtings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LessonRichtings == null)
            {
                return NotFound();
            }

            var lessonRichting = await _context.LessonRichtings
                .Include(l => l.Lesson)
                .Include(l => l.Richting)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lessonRichting == null)
            {
                return NotFound();
            }

            return View(lessonRichting);
        }

        // POST: LessonRichtings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LessonRichtings == null)
            {
                return Problem("Entity set 'MesDoigtsDeFeesContext.LessonRichting'  is null.");
            }
            var lessonRichting = await _context.LessonRichtings.FindAsync(id);
            if (lessonRichting != null)
            {
                lessonRichting.Ended = DateTime.Now;
                _context.LessonRichtings.Update(lessonRichting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonRichtingExists(int id)
        {
          return (_context.LessonRichtings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
