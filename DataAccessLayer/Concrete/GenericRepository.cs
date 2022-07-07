using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Ekle(T t)
        {
            _object.Add(t);
            c.SaveChanges();
        }

        public void Guncelle(T t)
        {
            _object.Update(t);
            c.SaveChanges();
        }

        public T IDBul(int id)
        {
            return _object.Find(id);
        }

        public List<T> IDListele(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public List<T> Listele()
        {
            return _object.ToList();
        }

        public void Sil(T t)
        {
            _object.Remove(t);
            c.SaveChanges();
        }
    }
}
