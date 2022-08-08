using Microsoft.AspNetCore.Mvc;
using Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocations;
using Samples.Authentication.Basic.Core.Application.Locations.Queries.GetLocationsPaged;
using Samples.Authentication.Basic.Core.Application.Locations.ViewModels;
using Sequoia.Abstractions;
using Sequoia.Data.Abstractions;

namespace Samples.Authentication.Basic.Api.Controllers
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
