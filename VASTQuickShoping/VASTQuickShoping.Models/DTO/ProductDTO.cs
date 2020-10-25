using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public float SalePrice { get; set; }
        public float Discount { get; set; } 
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Department { get; set; }
        public string Provider { get; set; }

    }
}
