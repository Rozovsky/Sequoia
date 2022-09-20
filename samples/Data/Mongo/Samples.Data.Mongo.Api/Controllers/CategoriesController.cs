using Microsoft.AspNetCore.Mvc;
using Samples.Common.Application.Categories.Commands.CreateCategory;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Categories.ViewModels;
using Samples.Common.Domain.Entities;
using Sequoia.Models;

namespace Samples.Data.Mongo.Api.Controllers
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
    }
}
