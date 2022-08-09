using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Domain.Models.Stores;
using Sequoia.Data.Abstractions;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Extensions;
using Sequoia.Data.WebClient.Interfaces;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IWebClient _webClient;

        public StoreRepository(IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(c =>
            {
                c.WebResourcePath = "sample-api/stores-service";
                c.ErrorHandlingMode = ErrorHandlingMode.Debug;
                c.IgnoreSslErrors = true;
                c.AuthenticationType = AuthenticationType.Basic;
            });
        }

        public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            var store = await _webClient
                .WithStringContent(dto)
                .Post<Store>("/stores", cancellationToken);

            return store;
        }

        public async Task<Store> UpdateStore(long id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await _webClient
                .WithStringContent(dto)
                .Put<Store>($"/stores/{id}", cancellationToken);

            return store;
        }

        public async Task DeleteStore(long id, CancellationToken cancellationToken)
        {
            await _webClient.Delete($"/stores/{id}", cancellationToken);
        }

        public async Task<Store> GetStore(long id, CancellationToken cancellationToken)
        {
            var store = await _webClient
                 .Get<Store>($"/stores/{id}", cancellationToken);

            return store;
        }

        public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _webClient
              .Get<List<Store>>("/stores", cancellationToken);

            return stores;
        }

        public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _webClient
                .WithQueryParams(new { page, limit })
                .Get<PagedWrapper<Store>>("/stores/paged", cancellationToken);

            return stores;
        }
    }
}
