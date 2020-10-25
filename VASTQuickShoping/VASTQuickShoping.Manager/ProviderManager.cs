using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Manager.Contracts;
using VASTQuickShoping.Models;
using VASTQuickShoping.Models.Domain;

namespace VASTQuickShoping.Manager
{
    public class ProviderManager : IProviderManager
    {
        public int Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                Provider obj = context.Providers.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

        public Provider Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Providers.Where(k => k.ProviderID == id).SingleOrDefault();//busca un registrp y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public IEnumerable<Provider> GetAll(bool status)
        {
            var context = new ApplicationDbContext();
            var lista = context.Providers.ToList();
            return lista;
        }

        public int Insert(Provider obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(Provider obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
