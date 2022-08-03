using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Interfaces
{
    public interface IMongoRepository<TEntity>
    {
        Task<TEntity> AddAsync(TEntity obj, CancellationToken cancellationToken);
        Task AddRangeAsync(ICollection<TEntity> documents, CancellationToken cancellationToken);
        Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string sortBy = null, bool isSortDesc = false, CancellationToken cancellationToken = default);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, string sortBy = null, bool isSortDesc = false, CancellationToken cancellationToken = default);
        IQueryable<TEntity> AsQueryable();
    }
}
