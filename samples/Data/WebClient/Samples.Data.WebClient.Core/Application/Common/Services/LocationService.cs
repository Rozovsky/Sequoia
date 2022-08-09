using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.Locations;
using Sequoia.Data.Abstractions;

namespace Samples.Data.WebClient.Core.Application.Common.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetLocations(cancellationToken);

            return locations;
        }

        public async Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var locations = await _locationRepository.GetLocationsPaged(page, limit, cancellationToken);

            return locations;
        }
    }
}
