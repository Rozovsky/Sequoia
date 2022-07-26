﻿using Microsoft.AspNetCore.Mvc;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachines;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;
using Sequoia.Models;

namespace Samples.Data.WebClient.Api.Controllers
{
    [Route("api/coffee-machines")]
    public class CoffeeMachinesController : ApiController
    {
        [HttpPost]
        public async Task<CoffeeMachineVm> CreateCoffeeMachine([FromBody] CoffeeMachineToCreateDto dto)
        {
            return await Mediator.Send(new CreateCoffeeMachineCommand
            {
                Dto = dto
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CoffeeMachineVm> UpdateCoffeeMachine([FromRoute] long id, [FromBody] CoffeeMachineToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateCoffeeMachineCommand
            {
                Id = id,
                Dto = dto
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCoffeeMachine([FromRoute] long id)
        {
            await Mediator.Send(new DeleteCoffeeMachineCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CoffeeMachineVm> GetCoffeeMachine([FromRoute] long id)
        {
            return await Mediator.Send(new GetCoffeeMachineQuery
            {
                Id = id
            });
        }

        [HttpGet]
        public async Task<List<CoffeeMachineVm>> GetCoffeeMachines()
        {
            return await Mediator.Send(new GetCoffeeMachinesQuery());
        }
    }
}
