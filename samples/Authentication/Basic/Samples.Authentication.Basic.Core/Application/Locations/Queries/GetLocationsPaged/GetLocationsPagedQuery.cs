using MediatR;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;
using Sequoia.Data.Abstractions;

namespace Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged
{
    public class GetLocationsPagedQuery : IRequest<PagedWrapper<LocationVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
