using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Domain.Models.Stores;
using Sequoia.Data.Abstractions;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            /*var store = _mapper.Map<Store>(dto);

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync(cancellationToken);*/

            return new Store();
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            /*var store = await this.GetStore(id, cancellationToken);
            _mapper.Map(dto, store);

            await _dbContext.SaveChangesAsync(cancellationToken);*/

            return new Store();
        }

        public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            /*var store = await this.GetStore(id, cancellationToken);

            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync(cancellationToken);*/
        }

        public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            /*var store = await _dbContext.Stores
                .Include(c => c.CoffeeMachines)
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);*/

            return new Store();
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            /*var stores = await _dbContext.Stores
                .AsNoTracking()
                .Include(c => c.CoffeeMachines)
                .ToListAsync(cancellationToken);*/

            return new List<Store>();
        }

        public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            /*var stores = await _dbContext.Stores
                .AsQueryable()
                .Where(c => c.Address.Length > 0)
                .ToPagedWrapper(page, limit, cancellationToken);*/

            return new PagedWrapper<Store>();
        }
    }
}
