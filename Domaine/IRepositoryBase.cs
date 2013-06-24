using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public interface IRepositoryBase<T>
    {
        bool Save(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void DropBase();
    }
}
