using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>();
        T Get<T>(Guid id);
        void Add<T>(T entity);
        void Delete(Guid id);
        void Edit<T>(T entity);
    }
}
