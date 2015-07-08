using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenjiePetCare.Core.Abstracts
{
    public interface IController<T>        
        where T : class
    {
        T Get(int id);
        IEnumerable<T> Get();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(int id);
    }
}
