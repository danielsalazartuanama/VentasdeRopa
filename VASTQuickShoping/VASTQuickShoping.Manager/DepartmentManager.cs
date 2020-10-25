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
    public class DepartmentManager : IDepartmentManager
    {
      

        public Department Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Departments.Where(k => k.DepartmentID == id).SingleOrDefault();//busca un registrp y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public IEnumerable<Department> GetAll(bool status)
        {
            var context = new ApplicationDbContext();
            var lista = context.Departments.ToList();
            return lista;
        }

        public int Insert(Department obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(Department obj)
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
                Department obj = context.Departments.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }
    }
}
