using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.Domain
{
   public class Brand
    {

        public int BrandID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public bool State { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
