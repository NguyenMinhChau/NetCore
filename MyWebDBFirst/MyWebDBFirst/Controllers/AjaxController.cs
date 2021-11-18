﻿using Microsoft.AspNetCore.Mvc;
using MyWebDBFirst.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebDBFirst.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;
        public AjaxController(eStore20Context context)
        {
            _context = context;
        }
        public IActionResult TimKiem()
        {
            return View();
        }
        public IActionResult XuLyTimKiem(string key, double? from, double? to)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                data = data.Where(hh => hh.TenHh.Contains(key));
            }
            if (from.HasValue)
            {
                data = data.Where(hh => hh.DonGia.Value >= from.Value);
            }
            if (to.HasValue)
            {
                data = data.Where(hh => hh.DonGia.Value <= to.Value);
            }
            var result = data.Select(hh => new
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia,
                Loai = hh.MaLoaiNavigation.TenLoai,
                NhaCC = hh.MaNccNavigation.TenCongTy
            });
            return Json(result);
        }
        public IActionResult ThongKe(DateTime? from, DateTime? to)
        {
            var data = _context.ChiTietHd.AsQueryable();
            if (from.HasValue)
            {
                data = data.Where(hh => hh.MaHdNavigation.NgayDat >= from.Value);
            }
            if (to.HasValue)
            {
                data = data.Where(hh => hh.MaHdNavigation.NgayDat <= to.Value);
            }
            var result = data.GroupBy(hh => new
            {
                hh.MaHhNavigation.MaLoaiNavigation.MaLoai,
                hh.MaHhNavigation.MaLoaiNavigation.TenLoai
            }).Select(rs => new{ 
                rs.Key.MaLoai,
                rs.Key.TenLoai,
                DoanhThu = rs.Sum(ct => ct.SoLuong * ct.DonGia)
            });
            return Json(result);
        }
        public IActionResult BieuDo()
        {
            return View();
        }
    }
}
