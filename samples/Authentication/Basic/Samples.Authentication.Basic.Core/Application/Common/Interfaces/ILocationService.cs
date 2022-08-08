using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Abstractions;

namespace Samples.Authentication.Basic.Core.Application.Common.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocations(CancellationToken cancellationToken);
        Task<PagedWrapper<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken);
    }
}
