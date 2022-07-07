using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KonusarakOgrenETicaret.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenETicaret.Controllers
{
    public class UrunController : Controller
    {
        private readonly UserManager<TKullanici> _userManager;
        private readonly RoleManager<TRol> _roleManager;
        UrunManager um = new UrunManager(new EFUrunDal());
        KullaniciManager km = new KullaniciManager(new EFKullaniciDal());
        YorumManager ym = new YorumManager(new EFYorumDal());

        // Identity Library Constructor

        public UrunController(UserManager<TKullanici> userManager, RoleManager<TRol> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Ürün Listeleme İşlemi
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var rol = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RolTasiyici> roller = new List<RolTasiyici>();
            foreach (var item in rol)
            {
                RolTasiyici t = new RolTasiyici();
                t.RolID = item.Id;
                t.RolAd = item.Name;
                t.RolAktif = userRoles.Contains(item.Name);
                roller.Add(t);
            }
            return View(roller);
        }

        // Yeni Ürün Ekleme İşlemi

        [Authorize(Roles = "SysAdmin,Admin")]
        public IActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniUrun(TUrun t)
        {
            var kid = km.IsımdenID(User.Identity.Name);
            t.KullaniciID = kid.Id;
            um.TEkle(t);
            return RedirectToAction("Index");
        }

        // Ürün Düzenleme İşlemi

        [Authorize(Roles = "SysAdmin,Admin")]
        public IActionResult UrunDuzenle(int id)
        {
            return View(um.IDGetir(id));
        }
        [HttpPost]
        public IActionResult UrunDuzenle(TUrun t)
        {
            var kid = km.IsımdenID(User.Identity.Name);
            t.KullaniciID = kid.Id;
            um.TGuncelle(t);
            return RedirectToAction("Index");
        }

        // Ürünlere Yorum İşlemi

        [Authorize(Roles = "SysAdmin,Customer")]
        public IActionResult UrunYorum(int id)
        {
            ViewBag.urun = id;
            return View();
        }
        [HttpPost]
        public IActionResult UrunYorum(TYorum t)
        {
            var kid = km.IsımdenID(User.Identity.Name);
            t.KullaniciID = kid.Id;
            ym.TEkle(t);
            return RedirectToAction("Index");
        }

        // Ürün Satış İşlemi
        // Migration işlemlerinde yaşadığım birkaç sorundan ötürü Satış tablosu yapılmadı.
        // Burayı kısaca yönlendiren bir bölüm olarak düşünebiliriz.
        [Authorize(Roles = "SysAdmin,Customer")]
        public IActionResult UrunSatis()
        {
            return RedirectToAction("UrunYorum");
        }

    }
}
