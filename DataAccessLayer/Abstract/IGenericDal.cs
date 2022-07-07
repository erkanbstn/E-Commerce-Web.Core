using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> Listele();
        void Ekle(T t);
        void Guncelle(T t);
        void Sil(T t);
        T IDBul(int id);
        List<T> IDListele(Expression<Func<T, bool>> filter);
    }
}
