using System.Collections.Generic;
using VASTQuickShoping.Models.Domain;

namespace VASTQuickShoping.Manager.Contracts
{
    public interface ISizeManager: ICrud<Size>
    {
        IEnumerable<Size> GetAllSimple();
    }
}
