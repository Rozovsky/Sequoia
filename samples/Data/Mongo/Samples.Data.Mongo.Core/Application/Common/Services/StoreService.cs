using AutoMapper;
using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Exceptions;

namespace Samples.Data.Mongo.Core.Application.Common.Services
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

            await _dbContext.Stores.InsertOneAsync(store, cancellationToken: cancellationToken);

            return store;
        }

        public async Task<Store> UpdateStore(string id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            _mapper.Map(dto, store);

            await _dbContext.Stores.ReplaceOneAsync(
                c => c.Id == id, store,
                new ReplaceOptions { IsUpsert = true },
                cancellationToken: cancellationToken);

            return store;
        }

        public async Task DeleteStore(string id, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            await _dbContext.Stores.DeleteOneAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Store> GetStore(string id, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (store == null)
                throw new NotFoundException(nameof(Store), id);

            //var storeFirst = await _dbContext.Stores
            //    .FirstOrDefaultAsync(c => !string.IsNullOrEmpty(c.Id), c => c.DateOfCreation, cancellationToken);

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = _dbContext.Stores.AsQueryable().ToList();

            return stores;
        }

        #region With repositories

        //public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        //{
        //    var store = _mapper.Map<Store>(dto);

        //    store = await _storeRepository.AddAsync(store, cancellationToken);

        //    return store;
        //}

        //public async Task<Store> UpdateStore(string id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        //{
        //    var store = await this.GetStore(id, cancellationToken);

        //    _mapper.Map(dto, store);

        //    await _storeRepository.UpdateAsync(c => c.Id == id, store, cancellationToken);

        //    return store;
        //}

        //public async Task DeleteStore(string id, CancellationToken cancellationToken)
        //{
        //    var store = await this.GetStore(id, cancellationToken);

        //    await _storeRepository.DeleteAsync(c => c.Id == id, cancellationToken);
        //}

        //public async Task<Store> GetStore(string id, CancellationToken cancellationToken)
        //{
        //    var store = await _storeRepository.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

        //    if (store == null)
        //        throw new NotFoundException(nameof(Store), id);

        //    return store;
        //}

        //public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        //{
        //    var stores = _storeRepository.AsQueryable().ToList();

        //    return stores;
        //}

        #endregion
    }
}
