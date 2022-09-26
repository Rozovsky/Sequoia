using Microsoft.AspNetCore.Mvc;
using Samples.Common.Application.Categories.Commands.CreateCategory;
using Samples.Common.Application.Categories.Commands.DeleteCategory;
using Samples.Common.Application.Categories.Commands.UpdateCategory;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.Queries.GetAllCategories;
using Samples.Common.Application.Categories.Queries.GetCategoriesPaged;
using Samples.Common.Application.Categories.Queries.GetCategory;
using Samples.Common.Application.Categories.ViewModels;
using Sequoia.Data.Models;
using Sequoia.Models;

namespace Samples.Data.Postgresql.Api.Controllers
{
    [Route("api/postgresql/categories")]
    public class CategoriesController : ApiController
    {
        [HttpPost]
        public async Task<CategoryVm> CreateCategory([FromBody] CategoryToCreateDto dto)
        {
            return await Mediator.Send(new CreateCategoryCommand
            {
                Dto = dto
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<CategoryVm> UpdateCategory([FromRoute] string id, [FromBody] CategoryToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateCategoryCommand
            {
                Id = id,
                Dto = dto
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string id)
        {
            await Mediator.Send(new DeleteCategoryCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<CategoryVm> GetCategory([FromRoute] string id)
        {
            return await Mediator.Send(new GetCategoryQuery
            {
                Id = id
            });
        }

        [HttpGet]
        public async Task<List<CategoryVm>> GetAllCategories()
        {
            return await Mediator.Send(new GetAllCategoriesQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<PagedWrapper<CategoryVm>> GetCategoriesPaged([FromQuery] GetCategoriesPagedQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
