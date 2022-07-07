using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFKullaniciDal : GenericRepository<TKullanici>, IKullaniciDal
    {
        public TKullanici IsımdenIDGetir(string name)
        {
            using (var c = new Context())
            {
                return c.Kullanicis.Where(b => b.UserName == name).FirstOrDefault();
            }
        }
    }
}
