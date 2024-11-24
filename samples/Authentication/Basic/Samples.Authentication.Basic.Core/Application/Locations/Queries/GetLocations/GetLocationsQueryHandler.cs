using AutoMapper;
using MediatR;
using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocations;

public class GetLocationsQueryHandler(
    ILocationService locationService,
    IMapper mapper) : IRequestHandler<GetLocationsQuery, List<LocationVm>>
{
    public async Task<List<LocationVm>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = await locationService.GetLocations(cancellationToken);

        return mapper.Map<List<LocationVm>>(locations);
    }
}