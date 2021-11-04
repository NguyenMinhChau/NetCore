using Microsoft.AspNetCore.Mvc;
using MyWebDBFirst.EF;
using MyWebDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebDBFirst.Controllers
{
    public class TimKiemController : Controller
    {
        private readonly eStore20Context _context;
        const int PAGE_SIZE = 3;

        public TimKiemController(eStore20Context context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Trang = page;
            var danhsach = _context.HangHoa.AsQueryable();
            //Filter


            //Phân trang
            ViewBag.TongSoTrang =Math.Ceiling( danhsach.Count() * 1.0 / PAGE_SIZE);
            var result = danhsach.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE)
                .Select(hh => new TimKiemVM
                {
                    MaHh = hh.MaHh,
                    Tenhh = hh.TenHh,
                    DonGia = hh.DonGia.Value,
                    NgaySx = hh.NgaySx,
                    Loai = hh.MaLoaiNavigation.TenLoai,
                });
       
            return View(result);
        }


        [HttpGet("/tim-kiem")]
        public IActionResult TimKiem()
        {
            return View();
        }
        [HttpPost("/tim-kiem")]
        public IActionResult TimKiem(string KeyWord, double? From, double? To, string sortBy = "TenHh", string sortType = "asc")
        {
            ViewBag.KeyWord = KeyWord;
            ViewBag.From = From;
            ViewBag.To = To;
            //Tìm kiếm
            var result = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(KeyWord))
            {
                 result = result.Where(hh => hh.TenHh.Contains(KeyWord));
            }
            if (From.HasValue)
            {
                result = result.Where(hh => hh.DonGia.Value >= From);
            }
            if (To.HasValue)
            {
                result = result.Where(hh => hh.DonGia.Value <= To);
            }
            //ViewBag.DanhSach = result;
            //Sắp xếp
            if (sortType == "asc")
            {
                switch (sortBy)
                {
                    case "TenHh": result = result.OrderBy(hh => hh.TenHh); break;
                    case "DonGia": result = result.OrderBy(hh => hh.DonGia); break;
                    case "NgaySx": result = result.OrderBy(hh => hh.NgaySx); break;
                }
            }
            else
            {
                switch (sortBy)
                {
                    case "TenHh": result = result.OrderByDescending(hh => hh.TenHh); break;
                    case "DonGia": result = result.OrderByDescending(hh => hh.DonGia); break;
                    case "NgaySx": result = result.OrderByDescending(hh => hh.NgaySx); break;
                }
            }

            //Phân trang
            var data = result.Select(hh => new TimKiemVM
            {
                MaHh = hh.MaHh,
                Tenhh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySx = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai,
            }).ToList();
            return View(data);
        }
    }
}
