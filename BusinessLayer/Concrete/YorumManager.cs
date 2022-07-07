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
    public class YorumManager : IYorumService
    {
        IYorumDal _YorumDal;

        public YorumManager(IYorumDal YorumDal)
        {
            _YorumDal = YorumDal;
        }

        public TYorum IDGetir(int id)
        {
            return _YorumDal.IDBul(id);
        }

        public List<TYorum> IDListele(int id)
        {
            return _YorumDal.IDListele(b => b.YorumID == id);
        }

        public List<TYorum> Listele()
        {
            return _YorumDal.Listele();
        }

        public void TEkle(TYorum t)
        {
            _YorumDal.Ekle(t);
        }

        public void TGuncelle(TYorum t)
        {
            _YorumDal.Guncelle(t);
        }

        public void TSil(TYorum t)
        {
            _YorumDal.Sil(t);
        }
    }
}
