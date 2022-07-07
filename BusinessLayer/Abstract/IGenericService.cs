using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TEkle(T t);
        void TSil(T t);
        void TGuncelle(T t);
        List<T> Listele();
        List<T> IDListele(int id);
        T IDGetir(int id);
    }
}
