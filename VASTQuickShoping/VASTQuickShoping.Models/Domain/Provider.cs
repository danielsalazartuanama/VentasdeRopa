using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Models.Domain
{
   public class Provider
    {
        public int ProviderID { get; set; }////Almacena la clave del departamento delas prendas.

        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "No puede ingresar mas de 52 caracteres")]
        public string Name { get; set; }//Almacena el nombre del proveedor.


        [Required(ErrorMessage = "El campo es obligatorio")]
        public int Phone { get; set; }

        [Required]
        public bool State { get; set; }

        //PROPIEDADES DE  NAVEGACION
        public virtual ICollection<Product> Products { get; set; }
    }
}
