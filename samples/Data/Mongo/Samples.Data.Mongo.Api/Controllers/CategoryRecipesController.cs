using Microsoft.AspNetCore.Mvc;
using Samples.Common.Application.CategoryRecipes.Commands.CreateCategoryRecipe;
using Samples.Common.Application.CategoryRecipes.Commands.DeleteCategoryRecipe;
using Samples.Common.Application.CategoryRecipes.Dtos;
using Samples.Common.Application.CategoryRecipes.Queries.GetCategoryRecipesPaged;
using Samples.Common.Application.CategoryRecipes.ViewModels;
using Sequoia.Data.Models;
using Sequoia.Models;

namespace Samples.Data.Mongo.Api.Controllers
{
    [Route("api/mongo/category-recipes")]
    public class CategoryRecipesController : ApiController
    {
        [HttpPost]
        public async Task<CategoryRecipeVm> CreateCategoryRecipe([FromBody] CategoryRecipeToCreateDto dto)
        {
            return await Mediator.Send(new CreateCategoryRecipeCommand
            {
                Dto = dto
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategoryRecipe([FromRoute] string id)
        {
            await Mediator.Send(new DeleteCategoryRecipeCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedWrapper<CategoryRecipeVm>> GetCategoryRecipesPaged(
            [FromQuery] GetCategoryRecipesPagedQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
