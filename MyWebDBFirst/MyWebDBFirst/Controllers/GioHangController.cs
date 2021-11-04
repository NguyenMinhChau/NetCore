using Microsoft.AspNetCore.Mvc;
using MyWebDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebDBFirst.Helper;
using MyWebDBFirst.EF;

namespace MyWebDBFirst.Controllers
{
    public class GioHangController : Controller
    {
        const string SESSION_CART = "GioHang";
        private readonly eStore20Context _context;

        public GioHangController(eStore20Context context)
        {
            _context = context;
        }
        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>(SESSION_CART);
                if(carts == null)
                {
                    carts = new List<CartItem>();
                }
                return carts;
            }
        }
        public IActionResult Index()
        {
            return View(Carts);
        }  
        public IActionResult AddToCart(int id, int SoLuong = 1)
        {
            //giỏ hàng hiện tại
            var carts = Carts;
            //Kiếm xem có hàng hóa với d này chưa
            var cartItem = carts.SingleOrDefault(item => item.MaHh == id);
            if(cartItem == null) //chưa có
            {
                var hangHoa = _context.HangHoa.SingleOrDefault(hh => hh.MaHh == id);
                cartItem = new CartItem
                {
                    MaHh = id,
                    TenHh = hangHoa.TenHh,
                    SoLuong = 1,
                    DonGia = hangHoa.DonGia.Value,
                    Hinh = hangHoa.Hinh
                };
                carts.Add(cartItem);
            }
            else
            {
                cartItem.SoLuong += SoLuong;
            }
            //Cập nhật giỏ hàng (lưu session)
            HttpContext.Session.Set(SESSION_CART, carts);
            return RedirectToAction("Index");
        }
    }
}
