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
    public class CategoryManager : ICategoryManager
    {
       

        public IEnumerable<Category> GetAll(bool status)
        {
            var context = new ApplicationDbContext();
            var lista = context.Categories
                .Where(k => k.State == status)
                .ToList();
            return lista;
        }

        public IEnumerable<Category> GetAllSimple()
        {
            using (var context=new ApplicationDbContext())
            {
                var lista = context.Categories
                    .Where(k => k.State == true)
                    .Select(k => new {k.CategoryID,k.Name }).ToList()
                    .Select(k => new Category {CategoryID=k.CategoryID,Name=k.Name });

                return lista;
            }
        }

        public Category Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Categories.Where(k => k.CategoryID == id).SingleOrDefault();//busca un registrp y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public int Insert(Category obj)
        {
            using(var context=new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }

        }

        public int Update(Category obj)
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
                Category obj = context.Categories.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

    }
}
