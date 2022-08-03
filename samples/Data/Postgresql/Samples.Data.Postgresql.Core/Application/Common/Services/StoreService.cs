using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Application.Stores.Dtos;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Exceptions;

namespace Samples.Data.Postgresql.Core.Application.Common.Services
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
            // TODO: check if store exist
            var store = _mapper.Map<Store>(dto);

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            // TODO: check if store exist // if dto.StoreId != machine.StoreId
            _mapper.Map(dto, store);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;
        }

        public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores
                .Include(c => c.CoffeeMachines)
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsNoTracking()
                .Include(c => c.CoffeeMachines)
                .ToListAsync(cancellationToken);

            return stores;
        }
    }
}
