using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Add(T entity);
        Task Delete(Guid id);
        Task Edit(T entity);
    }
}
