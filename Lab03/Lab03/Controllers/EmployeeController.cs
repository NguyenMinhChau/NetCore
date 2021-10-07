using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // save
            }
            return View();
        }

        [HttpGet]
        public IActionResult Generator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Generator(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // save
            }
            return View();
        }




        public IActionResult CheckEmployeeNo(string EmployeeNo)
        {
            string[] empNos = new string[] { "777", "222", "555" };
            if(empNos.Contains(EmployeeNo))
            {
                return Json(data: "Mã này đã có");
            }
            else
            {
                return Json(data: true);
            }
        }
        
        // Sync
        public IActionResult DemoSync()
        {
            var sw = new Stopwatch();
            sw.Start();
            var demo = new Employee();
            demo.Test01();
            demo.Test02();
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds}ms");
        }
        // Async
        public async Task<IActionResult> DemoAsyncs()
        {
            var sw = new Stopwatch();
            sw.Start();
            var demo = new Employee();
            var x = demo.Test01Async();
            var  y = demo.Test02Async();
            var z = demo.Test03Async();
            await x;
            await y;
            await z;
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds}ms");
        }

        //Razor: tham khảo thêm tại W3School
        public IActionResult DemoRazor()
        {
            return View();
        }
    }
}
