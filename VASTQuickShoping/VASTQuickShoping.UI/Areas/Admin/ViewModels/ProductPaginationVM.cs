using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VASTQuickShoping.Models.DTO;
using VASTQuickShoping.UI.Common;

namespace VASTQuickShoping.UI.Areas.Admin.ViewModels
{
    public class ProductPaginationVM
    {
        public IEnumerable<ProductDTO> productsDTOMV { get; set; }

        public Pagination Pagination { get; set; }
    }
}