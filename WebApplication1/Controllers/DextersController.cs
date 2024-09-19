using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DextersController : Controller
    {
        private readonly WebApplication1Context _context;

        public DextersController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: Dexters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dexter.ToListAsync());
        }

        // GET: Dexters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexter = await _context.Dexter
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dexter == null)
            {
                return NotFound();
            }

            return View(dexter);
        }

        // GET: Dexters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dexters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Gender,EntryID,ElementType")] Dexter dexter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dexter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dexter);
        }

        // GET: Dexters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexter = await _context.Dexter.FindAsync(id);
            if (dexter == null)
            {
                return NotFound();
            }
            return View(dexter);
        }

        // POST: Dexters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Gender,EntryID,ElementType")] Dexter dexter)
        {
            if (id != dexter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dexter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DexterExists(dexter.ID))
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
            return View(dexter);
        }

        // GET: Dexters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexter = await _context.Dexter
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dexter == null)
            {
                return NotFound();
            }

            return View(dexter);
        }

        // POST: Dexters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dexter = await _context.Dexter.FindAsync(id);
            if (dexter != null)
            {
                _context.Dexter.Remove(dexter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DexterExists(int id)
        {
            return _context.Dexter.Any(e => e.ID == id);
        }
    }
}
