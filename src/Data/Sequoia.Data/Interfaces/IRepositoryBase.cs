using System.Linq.Expressions;

namespace Sequoia.Data.Interfaces;

public interface IRepositoryBase<TEntity> 
    where TEntity : class
{
    Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken);
    Task<TEntity> Update(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken);
    Task Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> MarkAsDeleted(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> MarkAsRestored(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
}