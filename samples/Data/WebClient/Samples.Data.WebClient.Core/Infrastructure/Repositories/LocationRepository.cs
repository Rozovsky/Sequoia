using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
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
