using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Models.Domain;
using VASTQuickShoping.Models.DTO;

namespace VASTQuickShoping.Manager.Contracts
{
    interface IProductManager:ICrud<Product>
    {
        //Funcionalidades especificas
        IEnumerable<ProductDTO> GetAllDTO(bool status);

        IEnumerable<ProductDTO> GetAllDTOPaged(int currentPage, int pageSize, bool status);

        int GedCount(bool status);
    }
}
