using Microsoft.AspNetCore.Mvc;
using Samples.Sequoia.Complex.Core.Application.Coffee.Commands.CreateCoffee;
using Samples.Sequoia.Complex.Core.Application.Coffee.Commands.UpdateCoffee;
using Samples.Sequoia.Complex.Core.Application.Common.Dto;
using Samples.Sequoia.Complex.Core.Application.Common.ViewModels;
using Sequoia.Abstractions;

namespace Samples.Sequoia.Complex.Api.Controllers
{
    [Route("api/coffee")]
    public class CoffeeController : ApiController
    {
        [HttpPost]
        public async Task<CoffeeVm> CreateCoffee([FromBody] CoffeeToCreateDto dto)
        {
            return await Mediator.Send(new CreateCoffeeCommand 
            { 
                Dto = dto 
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CoffeeVm> UpdateCoffee([FromRoute] long id, [FromBody] CoffeeToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateCoffeeCommand 
            { 
                Id = id, 
                Dto = dto 
            });
        }
    }
}
