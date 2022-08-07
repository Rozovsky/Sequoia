using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Abstractions;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface IStoreService
    {
        Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken);
        Task<Store> UpdateStore(string id, StoreToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteStore(string id, CancellationToken cancellationToken);
        Task<Store> GetStore(string id, CancellationToken cancellationToken);
        Task<List<Store>> GetStores(CancellationToken cancellationToken);
        Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
