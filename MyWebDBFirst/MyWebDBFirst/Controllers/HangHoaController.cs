using Microsoft.AspNetCore.Mvc;
using MyWebDBFirst.EF;
using MyWebDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebDBFirst.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly eStore20Context _context;

        public HangHoaController(eStore20Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsHangHoa = _context.HangHoa.AsQueryable();
            var result = dsHangHoa.Select(hh => new HangHoaVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                Hinh = hh.Hinh,
                DonGia = hh.DonGia.Value,
                Mota = hh.MoTa
            });
            return View(result);
        }
        public IActionResult Details(int id)
        {
            var hangHoa = _context.HangHoa.SingleOrDefault(hh => hh.MaHh == id);

            return View(hangHoa);
        }
    }
}
