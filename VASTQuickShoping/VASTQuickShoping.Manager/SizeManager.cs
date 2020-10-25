using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VASTQuickShoping.Manager.Contracts;
using VASTQuickShoping.Models;
using VASTQuickShoping.Models.Domain;

namespace VASTQuickShoping.Manager
{
    public class SizeManager : ISizeManager
    {
       

        public Size Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Sizes.Where(k => k.SizeID == id).SingleOrDefault();//busca un registrp y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public IEnumerable<Size> GetAll(bool status)
        {
            var context = new ApplicationDbContext();
            var lista = context.Sizes.ToList();
            return lista;
        }

       

       

        public int Update(Size obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                 Size obj = context.Sizes.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

        public int Insert(Size obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }
        }
    }
}
