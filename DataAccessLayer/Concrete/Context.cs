using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<TKullanici, TRol, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KonusarakTicaret;Integrated Security=True;");
        }
        public DbSet<TKullanici> Kullanicis { get; set; }
        public DbSet<TUrun> Uruns { get; set; }
        public DbSet<TYorum> Yorums { get; set; }
        public DbSet<TRol> Rols{ get; set; }
    }
}
