using Samples.Client.Http.Core.Application.Common.Interfaces;
using Sequoia.Client.Http;

namespace Samples.Client.Http.Core.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IClient _client;

        public StoreRepository(IClient client)
        {
            _client = client;
        }

        public async Task MakeQuery()
        {
            var result = await _client
                .Path("https://google.com")
                .Path("fit-api/equipments")
                .Query("?id=10")
                .Query(new { id = 10, type = 2 })
                .Auth("Bearer token")
                .Auth("Basic token")
                .Auth()
                .Headers("x-client-id", 100)
                .Body("my payload")
                .Get<string>(CancellationToken.None);

            //_client.Configuration.Query
        }
    }
}
