using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TUrun
    {
        [Key]
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public string Renk { get; set; }
        public string Boyut { get; set; }
        public int Indirim { get; set; }
        public decimal Fiyat { get; set; }
        public int KullaniciID { get; set; }
        public virtual TKullanici Kullanici { get; set; }
    }
}
