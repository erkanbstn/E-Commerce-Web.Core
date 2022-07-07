using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TKullanici : IdentityUser<int>
    {
        public string Isim { get; set; }
        public string Sifre { get; set; }

    }
}
