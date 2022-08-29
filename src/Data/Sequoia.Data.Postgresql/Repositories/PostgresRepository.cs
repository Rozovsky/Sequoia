using Microsoft.EntityFrameworkCore;
using Sequoia.Data.Models;
using Sequoia.Data.Postgresql.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Postgresql.Repositories
{
    public abstract class PostgresRepository<TEntity> : IPostgresRepository<TEntity>
        where TEntity : class
    {
        private DbSet<TEntity> DbSet { get; set; }

        public PostgresRepository()
        {

        }

        public Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        /*public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            var store = _mapper.Map<Store>(dto);

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;
        }*/

        /*public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);
            _mapper.Map(dto, store);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;
        }*/

        /*public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }*/

        /*public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores
                .Include(c => c.CoffeeMachines)
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);

            return store;
        }*/

        /*public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsNoTracking()
                .Include(c => c.CoffeeMachines)
                .ToListAsync(cancellationToken);

            return stores;
        }*/

        /*public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsQueryable()
                .Where(c => c.Address.Length > 0)
                .ToPagedListAsync(page, limit, cancellationToken);

            return stores;
        }*/
    }
}
