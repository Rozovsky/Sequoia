using MediatR;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged
{
    public class GetLocationsPagedQuery : IRequest<Paged<LocationVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
