﻿using Samples.Data.Postgresql.Core.Application.Stores.Dtos;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
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