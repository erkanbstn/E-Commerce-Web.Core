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
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _KullaniciDal;

        public KullaniciManager(IKullaniciDal KullaniciDal)
        {
            _KullaniciDal = KullaniciDal;
        }

        public TKullanici IDGetir(int id)
        {
            return _KullaniciDal.IDBul(id);
        }

        public List<TKullanici> IDListele(int id)
        {
            return _KullaniciDal.IDListele(b => b.Id == id);
        }

        public TKullanici IsımdenID(string name)
        {
            return _KullaniciDal.IsımdenIDGetir(name);
        }

        public List<TKullanici> Listele()
        {
            return _KullaniciDal.Listele();
        }

        public void TEkle(TKullanici t)
        {
            _KullaniciDal.Ekle(t);
        }

        public void TGuncelle(TKullanici t)
        {
            _KullaniciDal.Guncelle(t);
        }

        public void TSil(TKullanici t)
        {
            _KullaniciDal.Sil(t);
        }
    }
}
