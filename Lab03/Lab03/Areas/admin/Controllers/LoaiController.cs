using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Areas.admin.Controllers
{
    public class LoaiController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
