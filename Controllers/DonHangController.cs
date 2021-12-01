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
    public class DonHangController : Controller
    {
        private readonly NetCoreDbContext _context;
        private readonly Process strPro =new Process();


        public DonHangController(NetCoreDbContext context)
        {
            _context = context;
        }

        // GET: DonHang
       public async Task<IActionResult> Index(string DonHangDC, string SearchString)
        {
            IQueryable<string> genreQuery = from m in _context.DonHang
                                    orderby m.DiaChi
                                    select m.DiaChi;
            var DC = from m in _context.DonHang
                        select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                DC = DC.Where(m => m.PersonName.Contains(SearchString));
            }
        if (!string.IsNullOrEmpty(DonHangDC))
            {
               DC = DC.Where(x => x.DiaChi == DonHangDC);
            }

            var diachi = new DonhangDiachi
            {
                Diachis = new SelectList(await genreQuery.Distinct().ToListAsync()),
                DonHang = await DC.ToListAsync()
            };

            return View(diachi);
   
         }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
            var model = _context.DonHang.ToList();
            if (model.Count()==0)ViewBag.MaDonHang="A01";
            else {
                var newKey = model.OrderByDescending(m => m.MaDonHang).FirstOrDefault().MaDonHang;
                ViewBag.MaDonHang= strPro.GenerateKey (newKey);
            }
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDonHang,SoDienThoai,DiaChi,PersonID,PersonName,Tenhang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDonHang,SoDienThoai,DiaChi,PersonID,PersonName,Tenhang")] DonHang donHang)
        {
            if (id != donHang.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.PersonID))
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
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHang
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donHang = await _context.DonHang.FindAsync(id);
            _context.DonHang.Remove(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
            return _context.DonHang.Any(e => e.PersonID == id);
        }
    }
}
