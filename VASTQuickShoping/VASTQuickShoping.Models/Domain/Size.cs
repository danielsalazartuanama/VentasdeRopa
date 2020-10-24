using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.Domain
{
  public  class Size
    {
        public int SizeID { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(20, ErrorMessage = "No puede ingresar mas de 52 caracteres")]
        public string Name { get; set; }//el nombre de la talla
        [Required]
        public bool State { get; set; }

        //PROPIEDADES DE  NAVEGACION

        public virtual ICollection<Product> Products { get; set; }
    }
}
