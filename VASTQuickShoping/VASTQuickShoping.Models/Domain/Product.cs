using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.Domain
{
    public class Product
    {
        public int ProductID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Brand")]
        public int BrandID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(20)]
        public string SKU { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float CostPrice { get; set; }
        [Required]
        public float SalePrice { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int StockMin { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public bool State { get; set; }


        //Propiedades de navegación
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
