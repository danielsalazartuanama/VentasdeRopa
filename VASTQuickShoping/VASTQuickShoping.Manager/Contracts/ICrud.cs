using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VASTQuickShoping.Manager.Contracts
{
  public  interface ICrud<T> where T: class
    {
        IEnumerable<T> GetAll(bool status);
        T Get(int id);
        int Insert(T obj);
        int Update(T obj);
        int Delete(int obj);
    }
}
