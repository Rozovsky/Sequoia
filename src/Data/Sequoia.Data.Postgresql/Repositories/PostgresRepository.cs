using Microsoft.EntityFrameworkCore;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Extensions;
using Sequoia.Data.Postgresql.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Postgresql.Repositories;

public abstract class PostgresRepository<TEntity>(IPostgresContext postgresContext) : IPostgresRepository<TEntity>
    where TEntity : class
{
    public virtual async Task<TEntity> Create(TEntity obj, CancellationToken cancellationToken)
    {
        postgresContext
            .Set<TEntity>()
            .Add(obj);

        await postgresContext.SaveChangesAsync(cancellationToken);

        return obj;
    }

    public virtual async Task<TEntity> Update(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
    {
        var entity = await postgresContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(predicate, cancellationToken);

        if (entity != null)
        {
            postgresContext.Entry(entity).CurrentValues.SetValues(obj);
            await postgresContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }

    public virtual async Task Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await postgresContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(predicate, cancellationToken);
            
        if (entity != null)
        {
            postgresContext.Set<TEntity>().Remove(entity);
            await postgresContext.SaveChangesAsync(cancellationToken);
        }            
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        var entities = await postgresContext
            .Set<TEntity>()
            .ToListAsync(cancellationToken);

        return entities;
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await postgresContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(predicate, cancellationToken);

        return entity;
    }

    public virtual async Task<Paged<TEntity>> GetPaged(int page, int limit, CancellationToken cancellationToken)
    {
        var entities = await postgresContext
            .Set<TEntity>()
            .ToPagedListAsync(page, limit, cancellationToken);

        return entities;
    }

    public async Task<TEntity> MarkAsDeleted(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await postgresContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(predicate, cancellationToken);

        if (entity != null)
        {
            //if (entity is not IBaseEntity)
            //    throw new Exception("The specified entry does not implement the IBaseEntity interface");

            //var baseEntity = entity as IBaseEntity;

            //baseEntity.IsDeleted = true;
            //await _postgresContext.SaveChangesAsync(cancellationToken);

            entity = SetDeletedEntityValue(entity, true);
            await postgresContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }

    public async Task<TEntity> MarkAsRestored(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        var entity = await postgresContext
            .Set<TEntity>()
            .SingleOrDefaultAsync(predicate, cancellationToken);

        if (entity != null)
        {
            entity = SetDeletedEntityValue(entity, false);
            await postgresContext.SaveChangesAsync(cancellationToken);
        }

        return entity;
    }

    private TEntity SetDeletedEntityValue(TEntity obj, bool isDeleted)
    {
        if (obj is not IBaseEntity)
            throw new Exception("The specified entry does not implement the IBaseEntity interface");

        var baseEntity = obj as IBaseEntity;

        baseEntity.IsDeleted = isDeleted;

        return obj;
    }
}