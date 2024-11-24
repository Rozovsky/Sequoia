using AutoMapper;
using MediatR;
using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged;

public class GetLocationsPagedQueryHandler(
    ILocationService locationService,
    IMapper mapper) : IRequestHandler<GetLocationsPagedQuery, Paged<LocationVm>>
{
    public async Task<Paged<LocationVm>> Handle(GetLocationsPagedQuery request, CancellationToken cancellationToken)
    {
        var locations = await locationService.GetLocations(cancellationToken);

        return mapper.Map<Paged<LocationVm>>(locations);
    }
}