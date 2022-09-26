using Microsoft.AspNetCore.Mvc;
using Samples.Common.Application.Recipes.Commands.CreateRecipe;
using Samples.Common.Application.Recipes.Commands.DeleteRecipe;
using Samples.Common.Application.Recipes.Commands.UpdateRecipe;
using Samples.Common.Application.Recipes.Dtos;
using Samples.Common.Application.Recipes.Queries.GetAllRecipes;
using Samples.Common.Application.Recipes.Queries.GetRecipe;
using Samples.Common.Application.Recipes.Queries.GetRecipesPaged;
using Samples.Common.Application.Recipes.ViewModels;
using Sequoia.Data.Models;
using Sequoia.Models;

namespace Samples.Data.Mongo.Api.Controllers
{
    [Route("api/mongo/recipes")]
    public class RecipesController : ApiController
    {
        [HttpPost]
        public async Task<RecipeVm> CreateRecipe([FromBody] RecipeToCreateDto dto)
        {
            return await Mediator.Send(new CreateRecipeCommand
            {
                Dto = dto
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<RecipeVm> UpdateRecipe([FromRoute] string id, [FromBody] RecipeToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateRecipeCommand
            {
                Id = id,
                Dto = dto
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] string id)
        {
            await Mediator.Send(new DeleteRecipeCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<RecipeVm> GetRecipe([FromRoute] string id)
        {
            return await Mediator.Send(new GetRecipeQuery
            {
                Id = id
            });
        }

        [HttpGet]
        public async Task<List<RecipeVm>> GetAllRecipes()
        {
            return await Mediator.Send(new GetAllRecipesQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedWrapper<RecipeVm>> GetRecipesPaged([FromQuery] GetRecipesPagedQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
