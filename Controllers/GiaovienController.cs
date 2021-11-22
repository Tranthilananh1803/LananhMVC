using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Data;
using NetCoreDemo.Models;

namespace NetCoreDemo.Controllers
{
    public class GiaovienController : Controller
    {
        private readonly NetCoreDbContext _context;

        public GiaovienController(NetCoreDbContext context)
        {
            _context = context;
        }

        // GET: Giaovien
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giaovien.ToListAsync());
        }

        // GET: Giaovien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaovien = await _context.Giaovien
                .FirstOrDefaultAsync(m => m.GiaovienID == id);
            if (giaovien == null)
            {
                return NotFound();
            }

            return View(giaovien);
        }

        // GET: Giaovien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Giaovien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiaovienID,Tengiaovien")] Giaovien giaovien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaovien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaovien);
        }

        // GET: Giaovien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaovien = await _context.Giaovien.FindAsync(id);
            if (giaovien == null)
            {
                return NotFound();
            }
            return View(giaovien);
        }

        // POST: Giaovien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GiaovienID,Tengiaovien")] Giaovien giaovien)
        {
            if (id != giaovien.GiaovienID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaovien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaovienExists(giaovien.GiaovienID))
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
            return View(giaovien);
        }

        // GET: Giaovien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaovien = await _context.Giaovien
                .FirstOrDefaultAsync(m => m.GiaovienID == id);
            if (giaovien == null)
            {
                return NotFound();
            }

            return View(giaovien);
        }

        // POST: Giaovien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var giaovien = await _context.Giaovien.FindAsync(id);
            _context.Giaovien.Remove(giaovien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaovienExists(string id)
        {
            return _context.Giaovien.Any(e => e.GiaovienID == id);
        }
    }
}
