using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab01.Models;

namespace Lab01.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>();
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var p = products.FirstOrDefault(p => p.ID == product.ID);
            if (p == null)
            {
                products.Add(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if(product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            var p = products.FirstOrDefault(p => p.ID == product.ID);
            if(p != null)
            {
                p.Name = product.Name;
                p.SoLuong = product.SoLuong;
                p.Price = product.Price;
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var p = products.FirstOrDefault(p => p.ID == id);
            if (p != null)
            {
                products.Remove(p);
            }
            return RedirectToAction("Index");
        }
    }
}
