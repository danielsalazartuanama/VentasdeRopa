 using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.Models.Identity;

namespace VASTQuickShoping.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=miCadena", throwIfV1Schema: false)
        {
            
            
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>("miCadena"));

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
