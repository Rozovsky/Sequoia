using Samples.Data.WebClient.Core.Domain.Models.Locations;
using Sequoia.Data.Models;

namespace Samples.Data.WebClient.Core.Application.Common.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(CancellationToken cancellationToken);
        Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
