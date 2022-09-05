using Microsoft.EntityFrameworkCore;

namespace Sequoia.Data.Postgresql.Interfaces
{
    public interface IPostgresContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
