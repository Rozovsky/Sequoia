using Microsoft.EntityFrameworkCore;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Extensions;
using Sequoia.Data.Postgresql.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Postgresql.Repositories
{
    public abstract class PostgresRepository<TEntity> : IPostgresRepository<TEntity>
        where TEntity : class
    {
        private readonly IPostgresContext _postgresContext;

        public PostgresRepository(IPostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
        {
            _postgresContext
                .Set<TEntity>()
                .Add(obj);

            await _postgresContext.SaveChangesAsync(cancellationToken);

            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            var entity = await _postgresContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(predicate, cancellationToken);

            if (entity != null)
            {
                _postgresContext.Entry(entity).CurrentValues.SetValues(obj);
                await _postgresContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await _postgresContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(predicate, cancellationToken);
            
            if (entity != null)
            {
                _postgresContext.Set<TEntity>().Remove(entity);
                await _postgresContext.SaveChangesAsync(cancellationToken);
            }            
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _postgresContext
                .Set<TEntity>()
                .ToListAsync(cancellationToken);

            return entities;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await _postgresContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(predicate, cancellationToken);

            return entity;
        }

        public virtual async Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            var entities = await _postgresContext
                .Set<TEntity>()
                .ToPagedListAsync(page, limit, cancellationToken);

            return entities;
        }
    }
}
