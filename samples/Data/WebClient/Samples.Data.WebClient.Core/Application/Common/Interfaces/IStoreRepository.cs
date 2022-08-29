using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Domain.Models.Stores;
using Sequoia.Data.Abstractions;
using Sequoia.Data.Models;

namespace Samples.Data.WebClient.Core.Application.Common.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken);
        Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteStore(long id, CancellationToken cancellationToken);
        Task<Store> GetStore(long id, CancellationToken cancellationToken);
        Task<List<Store>> GetStores(CancellationToken cancellationToken);
        Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
