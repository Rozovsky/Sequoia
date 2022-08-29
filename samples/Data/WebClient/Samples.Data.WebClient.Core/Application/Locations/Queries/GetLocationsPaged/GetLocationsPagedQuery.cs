using MediatR;
using Samples.Data.WebClient.Core.Application.Locations.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Data.WebClient.Core.Application.Locations.Queries.GetLocationsPaged
{
    public class GetLocationsPagedQuery : IRequest<PagedWrapper<LocationVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
