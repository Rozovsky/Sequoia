using Microsoft.AspNetCore.Mvc;
using Samples.Data.WebClient.Core.Application.Stores.Commands.CreateStore;
using Samples.Data.WebClient.Core.Application.Stores.Commands.DeleteStore;
using Samples.Data.WebClient.Core.Application.Stores.Commands.UpdateStore;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Application.Stores.Queries.GetStore;
using Samples.Data.WebClient.Core.Application.Stores.Queries.GetStores;
using Samples.Data.WebClient.Core.Application.Stores.Queries.GetStoresPaged;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;
using Sequoia.Data.Models;
using Sequoia.Models;

namespace Samples.Data.WebClient.Api.Controllers
{
    [Route("api/stores")]
    public class StoresController : ApiController
    {
        [HttpPost]
        public async Task<StoreVm> CreateStore([FromBody] StoreToCreateDto dto)
        {
            return await Mediator.Send(new CreateStoreCommand
            {
                Dto = dto
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<StoreVm> UpdateStore([FromRoute] long id, [FromBody] StoreToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateStoreCommand
            {
                Id = id,
                Dto = dto
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStore([FromRoute] long id)
        {
            await Mediator.Send(new DeleteStoreCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<StoreVm> GetStore([FromRoute] long id)
        {
            return await Mediator.Send(new GetStoreQuery
            {
                Id = id
            });
        }

        [HttpGet]
        public async Task<List<StoreVm>> GetStores()
        {
            return await Mediator.Send(new GetStoresQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedWrapper<StoreVm>> GetStoresPaged([FromQuery] GetStoresPagedQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
