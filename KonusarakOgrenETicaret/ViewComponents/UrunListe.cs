using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenETicaret.ViewComponents
{
    public class UrunListe:ViewComponent
    {
        UrunManager um = new UrunManager(new EFUrunDal());
        public IViewComponentResult Invoke()
        {
            return View(um.Listele());
        }
    }
}
