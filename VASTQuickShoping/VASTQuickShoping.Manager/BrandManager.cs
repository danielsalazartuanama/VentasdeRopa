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
    public class BrandManager : IBrandManager
    {
        public IEnumerable<Brand> GetAll(bool status)
        {
            var context = new ApplicationDbContext();
            var lista = context.Brands.ToList();
            return lista;
        }

        public IEnumerable<Brand> GetAllSimple()
        {
            using (var context = new ApplicationDbContext())
            {
                var lista = context.Brands
                    .Where(k => k.State == true)
                    .Select(k => new { k.BrandID, k.Name }).ToList()
                    .Select(k => new Brand { BrandID = k.BrandID, Name = k.Name });

                return lista;
            }
        }

        public Brand Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Brands.Where(k => k.BrandID == id).SingleOrDefault();//busca un registrp y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public int Insert(Brand obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(Brand obj)
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
                Brand obj = context.Brands.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

    }
}
