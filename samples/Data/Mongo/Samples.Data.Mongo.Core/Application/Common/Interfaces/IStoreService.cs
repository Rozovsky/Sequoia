using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface IStoreService
    {
        Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken);
        Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteStore(long id, CancellationToken cancellationToken);
        Task<Store> GetStore(long id, CancellationToken cancellationToken);
        Task<List<Store>> GetStores(CancellationToken cancellationToken);
    }
}
