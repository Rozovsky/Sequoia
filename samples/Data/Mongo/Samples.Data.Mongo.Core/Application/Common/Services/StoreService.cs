using AutoMapper;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Services
{
    public class StoreService : IStoreService
    {
        //private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public StoreService(
            //IApplicationDbContext dbContext,
            IMapper mapper)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            // TODO: check if store exist
            /*var store = _mapper.Map<Store>(dto);

            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;*/

            return new Store();
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            /*var store = await this.GetStore(id, cancellationToken);

            // TODO: check if store exist // if dto.StoreId != machine.StoreId
            _mapper.Map(dto, store);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return store;*/

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
                throw new NotFoundException(nameof(Store), id);

            return store;*/

            return new Store();
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            /*var stores = await _dbContext.Stores
                .AsNoTracking()
                .Include(c => c.CoffeeMachines)
                .ToListAsync(cancellationToken);

            return stores;*/

            return new List<Store>();
        }
    }
}
