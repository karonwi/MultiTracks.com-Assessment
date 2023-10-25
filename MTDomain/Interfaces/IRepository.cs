using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDomain.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> ListAllAsync();

        public Task<int> AddAsync(T entity);
        Task<T> GetByNameAsync(string name);

        Task<IEnumerable<T>> ListPaginatedAsync(int pageSize, int pageNumber);
    }
}
