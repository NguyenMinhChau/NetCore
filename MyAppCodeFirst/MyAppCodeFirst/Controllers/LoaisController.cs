using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAppCodeFirst.EF;

namespace MyAppCodeFirst.Controllers
{
    public class LoaisController : Controller
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Loais
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Loais.Include(l => l.LoaiTruoc);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Loais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiTruoc)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // GET: Loais/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiTruoc"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            //ViewBag.MaLoaiTruoc = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        // POST: Loais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MoTa,MaLoaiTruoc")] Loai loai, IFormFile MyFile)
        {
            if (ModelState.IsValid)
            {
                //Upload File
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", MyFile.FileName);
                using (var file = new FileStream(path, FileMode.CreateNew))
                {
                    MyFile.CopyTo(file);
                }
                //Update trường hình
                loai.Hinh = MyFile.FileName;

                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiTruoc"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiTruoc);
            return View(loai);
        }

        // GET: Loais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiTruoc"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiTruoc);
            return View(loai);
        }

        // POST: Loais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MoTa,Hinh,MaLoaiTruoc")] Loai loai, IFormFile MyFile)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(MyFile != null)
                    {
                        //Upload File
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", MyFile.FileName);
                        using (var file = new FileStream(path, FileMode.CreateNew))
                        {
                            MyFile.CopyTo(file);
                        }
                        //Update trường hình
                        loai.Hinh = MyFile.FileName;
                    }
                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiExists(loai.MaLoai))
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
            ViewData["MaLoaiTruoc"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiTruoc);
            return View(loai);
        }

        // GET: Loais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiTruoc)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // POST: Loais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loai = await _context.Loais.FindAsync(id);
            _context.Loais.Remove(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiExists(int id)
        {
            return _context.Loais.Any(e => e.MaLoai == id);
        }
    }
}
