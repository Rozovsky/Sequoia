using MediatR;
using Samples.Data.WebClient.Core.Application.Locations.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : IRequest<List<LocationVm>>
    {
    }
}
