using BookEcommerceWeb.DataAccess.Data;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter, string? includeProperty = null)
        {
            var query = _dbSet.Where(filter);
            return GetIncludeProperty(includeProperty, query).ToList();
        }

        public IEnumerable<T> GetAll(string? includeProperty = null)
        {
            IQueryable<T> query = _dbSet;
            return GetIncludeProperty(includeProperty, query).ToList();
        }

        public async Task<T?> GetById(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity != null;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<T> GetIncludeProperty(string? includeProperty, IQueryable<T>? query)
        {
            if (!string.IsNullOrEmpty(includeProperty))
            {
                var includeProperties = includeProperty.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var inclideProp in includeProperties)
                {
                    query = query.Include(inclideProp);
                }
            }
            return query;
        }
    }
}
