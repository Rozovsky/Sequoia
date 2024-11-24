using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Domain.Entities;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Common.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    public async Task<List<Location>> GetLocations(CancellationToken cancellationToken)
    {
        return await locationRepository.GetLocations(cancellationToken);
    }

    public async Task<Paged<Location>> GetLocationsPaged(int page, int limit, CancellationToken cancellationToken)
    {
        return await locationRepository.GetLocationsPaged(page, limit, cancellationToken);
    }
}