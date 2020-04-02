using ContactManagement.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManagement.ApplicationCore.Repositories
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveById(long id);
        void Update(T entity);
        ValueTask<T> FindByIdAsync(long id, CancellationToken cancellationToken = default);
        ValueTask CommitAsync(CancellationToken cancellationToken = default);
        ValueTask<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        List<string> Includes { get; }
        void AddInclude(string include);
    }
}
