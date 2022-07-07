using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using KonusarakOgrenETicaret.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KonusarakOgrenETicaret.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<TKullanici> _signInManager;
        private readonly UserManager<TKullanici> _userManager;

        public LoginController(SignInManager<TKullanici> signInManager, UserManager<TKullanici> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(TKullanici u)
        {
            TKullanici app = new TKullanici()
            {
                Sifre = u.Sifre,
                UserName = u.UserName,
            };
            if (u.Sifre.Length > 5)
            {
                var result = await _userManager.CreateAsync(app, u.Sifre);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return View();
                }
            }
            return View(u);
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(TKullanici w)
        {
            var result = await _signInManager.PasswordSignInAsync(w.UserName, w.Sifre, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Urun");
            }
            else
            {
                ViewBag.islem = "Giriş Yapılamadı Lütfen Tekrar Deneyin.";
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
    }
}
