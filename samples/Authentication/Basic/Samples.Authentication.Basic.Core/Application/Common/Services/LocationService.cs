using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Common.Services
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
            return await _locationRepository.GetLocations(cancellationToken);
        }

        public async Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetLocationsPaged(page, limit, cancellationToken);
        }
    }
}
