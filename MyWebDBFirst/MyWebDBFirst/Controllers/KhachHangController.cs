﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebDBFirst.EF;
using MyWebDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWebDBFirst.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;
        public KhachHangController(eStore20Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult DangNhap( string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var kh = _context.KhachHang.SingleOrDefault(kh => kh.MaKh == model.MaKh && kh.MatKhau == model.MatKhau);
                if (kh != null)
                {
                    //Tạo thông tin đăng nhập
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim(ClaimTypes.Name, kh.HoTen),
                        new Claim("FullName", kh.HoTen),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim(ClaimTypes.Role, "Account"),
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {

                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
            }
            return View();
        }
        [Authorize]
        public IActionResult Info()
        {
            var data = HttpContext.User.Claims;

            return View();
        }
        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        [Authorize(Roles ="Quản Trị")]
        public IActionResult PhanQuyen()
        {
            return View();
        }
        [Authorize]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
