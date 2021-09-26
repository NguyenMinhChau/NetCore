using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01.Controllers
{
    public class HCMUEController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult random()
        {
            var ds = new List<int>();
            var rd = new Random();
            for(int i = 0; i < 6; i++)
            {
                ds.Add(rd.Next(0, 55));
            }
            int hour = DateTime.Now.Hour;
            ViewBag.LoiChao = hour < 12 ? "Chào buổi sáng" : "Chào buổi chiều";
            return View("random");
        }
    }
}
