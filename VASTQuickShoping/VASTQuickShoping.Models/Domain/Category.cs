using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.Domain
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        [StringLength(50, ErrorMessage ="No puede ingresar mas de 52 caracteres")]
        public string Name { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required]
        public bool State { get; set; }

        public virtual ICollection<Product>Products { get; set; }
    }
}
