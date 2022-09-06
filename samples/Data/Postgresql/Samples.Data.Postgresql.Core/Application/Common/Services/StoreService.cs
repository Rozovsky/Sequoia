using AutoMapper;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Application.Stores.Dtos;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Data.Models;
using Sequoia.Exceptions;

namespace Samples.Data.Postgresql.Core.Application.Common.Services
{
    public class StoreService : IStoreService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IStoreRepository _storeRepository;

        public StoreService(
            IApplicationDbContext dbContext,
            IMapper mapper,
            IStoreRepository storeRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _storeRepository = storeRepository;
        }

        public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            var store = _mapper.Map<Store>(dto);

            store = await _storeRepository.CreateAsync(store, cancellationToken);

            return store;
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = new Store();
            _mapper.Map(dto, store);

            store = await _storeRepository.UpdateAsync(c => c.Id == id, store, cancellationToken);

            return store;
        }

        public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            await _storeRepository.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetAllAsync(cancellationToken);

            return stores.ToList();
        }

        public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetPagedAsync(page, limit, cancellationToken);

            return stores;
        }

        #region DBContext realization

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

        #endregion
    }
}
