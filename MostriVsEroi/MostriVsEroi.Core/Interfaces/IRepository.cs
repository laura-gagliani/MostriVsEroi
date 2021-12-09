using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface IRepository<T>
    {
        bool Add(T item);
        bool Delete(T item);  
        
        List<T> GetAll(Func<T, bool> filter = null);

        bool Update(T item);
    }
}
