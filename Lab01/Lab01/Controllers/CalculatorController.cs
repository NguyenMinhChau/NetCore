using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calculated(double a = 0, double b = 0, char op = '+')
        {
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case '*':
                    ViewBag.KetQua = a * b;
                    break;
                case '/':
                    ViewBag.KetQua = a / b;
                    break;
                case '%':
                    ViewBag.KetQua = a % b;
                    break;
                case '^':
                    ViewBag.KetQua = Math.Pow(a, b);
                    break;

            }
            return View("Index");
        }
        
    }
}
