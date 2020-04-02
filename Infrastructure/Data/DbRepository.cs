using ContactManagement.ApplicationCore.Entities;
using ContactManagement.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.Infrastructure.Data
{
    [ExcludeFromCodeCoverage]
    public class DbRepository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        protected readonly DbContext DbContext;
        private readonly DbSet<T> _dbSet;

        protected DbRepository(DbContext context)
        {
            DbContext = context;
            _dbSet = context.Set<T>();
        }

        public List<string> Includes { get; private set; }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async ValueTask CommitAsync(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask<T> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            // manage include
            if (Includes != null) { 
                var result = ApplySpecification();
                return result.FirstOrDefault();
            }
            return await _dbSet.FindAsync(id);
        }

        public async ValueTask<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveById(long id) => Remove(_dbSet.Find(id));

        public void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void AddInclude(string include)
        {
            if (Includes == null) Includes = new List<string>();
            Includes.Add(include);
        }

        private IQueryable<T> ApplySpecification()
        {
            var query = DbContext.Set<T>().AsQueryable();
            if (Includes != null)
            {
                query = Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
