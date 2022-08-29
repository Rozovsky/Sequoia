using Sequoia.Data.Models;
using System.Linq.Expressions;

namespace Sequoia.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> 
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken);
    }
}
