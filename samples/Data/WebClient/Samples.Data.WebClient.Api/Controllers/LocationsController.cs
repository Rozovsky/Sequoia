using Microsoft.AspNetCore.Mvc;
using Samples.Data.WebClient.Core.Application.Locations.Queries.GetLocations;
using Samples.Data.WebClient.Core.Application.Locations.Queries.GetLocationsPaged;
using Samples.Data.WebClient.Core.Application.Locations.ViewModels;
using Sequoia.Abstractions;
using Sequoia.Data.Models;

namespace Samples.Data.WebClient.Api.Controllers
{
    [Route("api/locations")]
    public class LocationsController : ApiController
    {

        [HttpGet]
        public async Task<List<LocationVm>> GetLocations()
        {
            return await Mediator.Send(new GetLocationsQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedWrapper<LocationVm>> GetLocationsPaged([FromQuery] GetLocationsPagedQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
