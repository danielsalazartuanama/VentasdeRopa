using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Models;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.Models.DTO;

namespace VASTQuickShoping.Manager.Contracts
{
    public class ProductManager : IProductManager
    {

        public IEnumerable<Product> GetAll(bool status)
        {
            using (var context=new ApplicationDbContext())
            {
                var lista = context.Products.Include("Category").Include("Brand")
                    .Where(k => k.State == status)
                    .ToList();
                return lista;
            }
        }

        public IEnumerable<ProductDTO> GetAllDTO(bool status)
        {
            using (var context = new ApplicationDbContext())
            {
                
                var lista = context.Products
                    .Where(k => k.State == status)
                    .Select(k => new ProductDTO
                    {
                        ProductID = k.ProductID,
                        Name = k.Name,
                        Description = k.Description,
                        SKU = k.SKU,
                        SalePrice = k.SalePrice,
                        Stock = k.Stock,
                        Discount = k.Discount,
                        Category = k.Category.Name,
                        Brand = k.Brand.Name
                    })
                    .ToList();
                return lista;
            }
        }

        public Product Get(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Where(k => k.ProductID == id).SingleOrDefault();//busca un registro y devuelve un objeto caundo no va coincidir ningun id estamos haciendo una busqueda por idpara modifi

            }
        }

        public int Insert(Product obj)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(obj).State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(Product obj)
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
                Product obj = context.Products.Find(id);
                context.Entry(obj).State = EntityState.Deleted;
                return context.SaveChanges();
            }
        }

    }
}
