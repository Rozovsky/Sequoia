using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Abstractions;

namespace Samples.Authentication.Basic.Core.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return new List<Location>();
        }

        public async Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return new PagedWrapper<Location>();
        }
    }
}
