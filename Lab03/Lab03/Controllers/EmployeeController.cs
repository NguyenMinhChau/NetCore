using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab03.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckEmployeeNo(string EmployeeNo)
        {
            if(EmployeeNo == "777")
            {
                return Json(data: "Mã này đã có");
            }
            else
            {
                return Json(data: true);
            }
        }
    }
}
