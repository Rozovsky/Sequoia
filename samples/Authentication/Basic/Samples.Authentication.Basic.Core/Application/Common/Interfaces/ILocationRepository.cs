using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Common.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocations(CancellationToken cancellationToken);
        Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
