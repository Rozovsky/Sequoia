using AutoMapper;
using MediatR;
using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged
{
    public class GetLocationsPagedQueryHandler : IRequestHandler<GetLocationsPagedQuery, Paged<LocationVm>>
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public GetLocationsPagedQueryHandler(
            ILocationService locationService,
            IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<Paged<LocationVm>> Handle(GetLocationsPagedQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetLocations(cancellationToken);

            return _mapper.Map<Paged<LocationVm>>(locations);
        }
    }
}
