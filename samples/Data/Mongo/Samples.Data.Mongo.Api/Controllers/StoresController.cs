﻿using Microsoft.AspNetCore.Mvc;
using Samples.Data.Mongo.Core.Application.Stores.Commands.CreateStore;
using Samples.Data.Mongo.Core.Application.Stores.Commands.DeleteStore;
using Samples.Data.Mongo.Core.Application.Stores.Commands.UpdateStore;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Application.Stores.Queries.GetStore;
using Samples.Data.Mongo.Core.Application.Stores.Queries.GetStores;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;
using Sequoia.Abstractions;

namespace Samples.Data.Postgresql.Api.Controllers
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
    }
}