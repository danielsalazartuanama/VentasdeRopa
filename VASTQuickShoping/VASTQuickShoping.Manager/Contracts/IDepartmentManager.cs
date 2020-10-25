using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VASTQuickShoping.Models.Domain;

namespace VASTQuickShoping.Manager.Contracts
{
   public interface IDepartmentManager : ICrud<Department>
    {
        IEnumerable<Department> GetAllSimple();

    }
}
