using BookEcommerceWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll(string? includeProperty = null);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter, string? includeProperty = null);
        Task<T?> GetById(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<bool> IsExists(int id);
    }
}
