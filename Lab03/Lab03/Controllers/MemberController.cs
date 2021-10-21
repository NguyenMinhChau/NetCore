using Lab03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            //Random rd = new Random();
            //int MaBaoMat = rd.Next(1000, 100000);
            //ViewBag.MaBaoMat = MaBaoMat;
            var MaBaoMat = MyTool.MaBaoMat();
            ViewBag.MaBaoMat = MyTool.MaBaoMat();
            HttpContext.Session.SetString("MaBaoMat", MaBaoMat.ToString());
            return View();
        }
        
        public string KiemTraMaBaoMat(string baomat)
        {
            string maBMServer = HttpContext.Session.GetString("MaBaoMat"); 
            return (baomat == maBMServer) ? "true" : "false";
        }
        public IActionResult CheckSV(string sv)
        {
            if(sv == "777777")
            {
                return Json(data: "Mã này đã có");
            }
            else
            {
                return Json(data: true);
            }
        }
        // ~/Member/DemoPartial
        public IActionResult DemoPartialView()
        {
            var dsLoai = new List<Loai>();
            dsLoai.Add(new Loai { MaLoai = 1, TenLoai = "Laptop" });
            dsLoai.Add(new Loai { MaLoai = 2, TenLoai = "Điện thoại" });
            dsLoai.Add(new Loai { MaLoai = 3, TenLoai = "Tablet" });
            return PartialView("~/Views/Shared/_Loai.cshtml", dsLoai);
        }
    }
}
