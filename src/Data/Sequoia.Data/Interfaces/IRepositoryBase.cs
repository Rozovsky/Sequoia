using Sequoia.Data.Abstractions;

namespace Sequoia.Data.Interfaces
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> 
        where TEntity : class
    {
        Task<PagedWrapper<TEntity>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken);
    }
}
