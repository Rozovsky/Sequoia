using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Domain.Models.Stores;
using Sequoia.Data.Models;

namespace Samples.Data.WebClient.Core.Application.Common.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.CreateStore(dto, cancellationToken);

            return store;
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.UpdateStore(id, dto, cancellationToken);

            return store;
        }

        public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            await _storeRepository.DeleteStore(id, cancellationToken);
        }

        public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetStore(id, cancellationToken);

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStores(cancellationToken);

            return stores;
        }

        public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetStoresPaged(page, limit, cancellationToken);

            return stores;
        }
    }
}
