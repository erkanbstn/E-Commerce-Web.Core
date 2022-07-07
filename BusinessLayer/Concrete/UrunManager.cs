using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public TUrun IDGetir(int id)
        {
            return _urunDal.IDBul(id);
        }

        public List<TUrun> IDListele(int id)
        {
            return _urunDal.IDListele(b => b.UrunID == id);
        }

        public List<TUrun> Listele()
        {
            return _urunDal.Listele();
        }

        public void TEkle(TUrun t)
        {
            _urunDal.Ekle(t);
        }

        public void TGuncelle(TUrun t)
        {
            _urunDal.Guncelle(t);
        }

        public void TSil(TUrun t)
        {
            _urunDal.Sil(t);
        }
    }
}
