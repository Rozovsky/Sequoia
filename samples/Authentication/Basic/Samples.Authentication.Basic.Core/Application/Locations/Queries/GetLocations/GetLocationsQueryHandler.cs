using AutoMapper;
using MediatR;
using Samples.Authentication.Basic.Core.Application.Common.Interfaces;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocations
{
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, List<LocationVm>>
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public GetLocationsQueryHandler(
            ILocationService locationService,
            IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<List<LocationVm>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _locationService.GetLocations(cancellationToken);

            return _mapper.Map<List<LocationVm>>(locations);
        }
    }
}
