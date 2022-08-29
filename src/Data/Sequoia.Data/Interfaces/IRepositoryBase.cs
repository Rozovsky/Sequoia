using Sequoia.Data.Models;

namespace Sequoia.Data.Interfaces
{
    public interface IRepositoryBase<TEntity, TPrimaryKey> 
        where TEntity : class
    {
        Task<PagedWrapper<TEntity>> GetPaged(int page, int pageSize, CancellationToken cancellationToken);
    }
}
