using MediatR;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : IRequest<List<LocationVm>>
    {
    }
}
