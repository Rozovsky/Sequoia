using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Abstractions;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Exceptions;

namespace Samples.Data.Mongo.Core.Application.Common.Services
{
    public class StoreService : IStoreService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public StoreService(
            IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var store = await _dbContext.Stores
                .AsQueryable()
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);             

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsQueryable()
                .ToListAsync(cancellationToken);

            return stores;
        }

        public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsQueryable()
                .Where(c => c.Address.Length > 0)
                .ToPagedListAsync(page, limit, cancellationToken);

            return stores;
        }
    }
}
