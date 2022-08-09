using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.Locations;
using Sequoia.Data.Abstractions;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
        {
            return new List<Location>();
        }

        public async Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            return new PagedWrapper<Location>();
        }
    }
}
