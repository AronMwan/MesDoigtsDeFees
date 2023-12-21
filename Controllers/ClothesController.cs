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
    public class ClothesController : Controller
    {
        private readonly MyDBContext _context;

        public ClothesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Clothes
        public async Task<IActionResult> Index(string selectedSize = "Alle")
        {



            List<ListItem> list = new List<ListItem>()
    {
        new ListItem() { Text = "XS", Value = "XS" },
        new ListItem() { Text = "S", Value = "S" },
        new ListItem() { Text = "M", Value = "M" },
        new ListItem() { Text = "L", Value = "L" },
        new ListItem() { Text = "XL", Value = "XL" },
    };

            ClothesIndexViewModel viewModel = new ClothesIndexViewModel();
            viewModel.SelectedSize = selectedSize;
            viewModel.SizeList = new SelectList(list, "Value", "Text", selectedSize);

            if (selectedSize == "Alle")
            {
                viewModel.Clothes = await _context.Clothes
                    .OrderBy(g => g.Name)
                    .Where(c => c.Ended == DateTime.MaxValue)
                    .ToListAsync();
                return View(viewModel);
            }
            else
            {
                ClothesIndexViewModel viewModel2 = new ClothesIndexViewModel
                {
                    SelectedSize = selectedSize,
                    Clothes = await _context.Clothes
                            .Where(c => selectedSize == "" || c.Size == selectedSize && c.Ended == DateTime.MaxValue)
                            .OrderBy(c => c.Name)
                            .ToListAsync()
                };

                return View(viewModel2);
            }
            
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            ViewBag.SizeList = new List<string> { "XS", "S", "M", "L", "XL" };

            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Size,Started,Ended")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clothes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clothes);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }

            ViewBag.SizeList = new SelectList(new List<string> { "S", "M", "L", "XL" }, clothes.Size);
            return View(clothes);
        }


        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Started,Ended,Size")] Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clothes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.Id))
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
            return View(clothes);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clothes == null)
            {
                return NotFound();
            }

            var clothes = await _context.Clothes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clothes == null)
            {
                return Problem("Entity set 'MesDoigtsDeFeesContext.Clothes'  is null.");
            }
            var clothes = await _context.Clothes.FindAsync(id);
            if (clothes != null)
            {
                clothes.Ended = DateTime.Now;
                _context.Clothes.Update(clothes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
          return (_context.Clothes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
