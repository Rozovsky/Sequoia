using Sequoia.Data.Interfaces;

namespace Sequoia.Data.Postgresql.Interfaces
{
    public interface IPostgresRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
    }
}
