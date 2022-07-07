using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TYorum
    {
        [Key]
        public int YorumID { get; set; }
        public string YorumIcerik { get; set; }
        public int? KullaniciID { get; set; }
        public virtual TKullanici Kullanici { get; set; }
        public int? UrunID { get; set; }
        public virtual TUrun Urun{ get; set; }
    }
}
