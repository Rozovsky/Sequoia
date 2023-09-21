using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Common.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(CancellationToken cancellationToken);
        Task<Paged<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
