using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Location> _locations;

        public LocationRepository()
        {
            // seed static data
            _locations = ApplicationDbContextSeed.Seed();
        }

        public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return _locations;
        }

        // TODO: add mapings and paged processing
        public async Task<Paged<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return new Paged<Location>();
        }
    }
}
