using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.Locations;
using Sequoia.Data.Abstractions;
using Sequoia.Data.WebClient.Enums;
using Sequoia.Data.WebClient.Extensions;
using Sequoia.Data.WebClient.Interfaces;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IWebClient _webClient;

        public LocationRepository(IWebClient webClient)
        {
            _webClient = webClient;
            _webClient.Configure(c =>
            {
                c.WebResourcePath = "sample-api/locations-service";
                c.ErrorHandlingMode = ErrorHandlingMode.Debug;
                c.IgnoreSslErrors = true;
                c.AuthenticationType = AuthenticationType.Basic;
            });
        }

        public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
        {
            var locations = await _webClient
                .Get<List<Location>>("/locations", cancellationToken);

            return locations;
        }

        public async Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var locations = await _webClient
                .WithQueryParams(new { page, limit })
                .Get<PagedWrapper<Location>>("/locations/paged", cancellationToken);

            return locations;
        }
    }
}
