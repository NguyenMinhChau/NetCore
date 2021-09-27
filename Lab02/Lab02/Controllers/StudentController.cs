using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab02.Models;
using System.IO;

namespace Lab02.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Manage(StudentInfo model, String command)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student.txt");
            if(command == "Lưu")
            {
                String[] lines = { model.Id, model.Name, model.Marks.ToString() };
                System.IO.File.WriteAllLines(path, lines);
                ViewBag.Messeage = "Đã ghi vào file";
            }else if(command == "Mở")
            {
                String[] lines = System.IO.File.ReadAllLines(path);
                ViewBag.Id = lines[0];
                ViewBag.Name = lines[1];
                ViewBag.Marks = Convert.ToDouble(lines[2]);
                ViewBag.Message = "Đã đọc từ file";
            }
            return View("Index");
        }
    }
}
