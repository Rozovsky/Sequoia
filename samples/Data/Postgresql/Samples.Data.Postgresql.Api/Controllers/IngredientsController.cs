using Microsoft.AspNetCore.Mvc;
using Samples.Common.Application.Ingredients.Commands.CreateIngredient;
using Samples.Common.Application.Ingredients.Commands.DeleteIngredient;
using Samples.Common.Application.Ingredients.Commands.UpdateIngredient;
using Samples.Common.Application.Ingredients.Dtos;
using Samples.Common.Application.Ingredients.Queries.GetAllIngredients;
using Samples.Common.Application.Ingredients.Queries.GetIngredient;
using Samples.Common.Application.Ingredients.Queries.GetIngredientsPaged;
using Samples.Common.Application.Ingredients.ViewModels;
using Sequoia.Data.Models;
using Sequoia.Models;

namespace Samples.Data.Postgresql.Api.Controllers;

[Route("api/postgresql/ingredients")]
public class IngredientsController : ApiController
{
    [HttpPost]
    public async Task<IngredientVm> CreateIngredient([FromBody] IngredientToCreateDto dto)
    {
        return await Mediator.Send(new CreateIngredientCommand
        {
            Dto = dto
        });
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IngredientVm> UpdateIngredient([FromRoute] string id, [FromBody] IngredientToUpdateDto dto)
    {
        return await Mediator.Send(new UpdateIngredientCommand
        {
            Id = id,
            Dto = dto
        });
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteIngredient([FromRoute] string id)
    {
        await Mediator.Send(new DeleteIngredientCommand
        {
            Id = id
        });

        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IngredientVm> GetIngredient([FromRoute] string id)
    {
        return await Mediator.Send(new GetIngredientQuery
        {
            Id = id
        });
    }

    [HttpGet]
    public async Task<List<IngredientVm>> GetAllIngredients()
    {
        return await Mediator.Send(new GetAllIngredientsQuery());
    }

    [HttpGet]
    [Route("paged")]
    public async Task<Paged<IngredientVm>> GetIngredientsPaged([FromQuery] GetIngredientsPagedQuery query)
    {
        return await Mediator.Send(query);
    }
}