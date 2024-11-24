using Microsoft.AspNetCore.Mvc;
using Samples.Data.Mongo.Core.Application.Common.Dto;
using Samples.Data.Mongo.Core.Application.Common.ViewModels;
using Samples.Data.Mongo.Core.Application.Todos.Commands.CreateTodo;
using Samples.Data.Mongo.Core.Application.Todos.Commands.DeleteTodo;
using Samples.Data.Mongo.Core.Application.Todos.Commands.UpdateTodo;
using Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodo;
using Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodos;
using Samples.Data.Mongo.Core.Application.Todos.Queries.GetTodosPaged;
using Sequoia.Data.Mongo.ViewModels;
using Sequoia.Models;
using System.ComponentModel.DataAnnotations;

namespace Samples.Data.Mongo.Api.Controllers;

[Route("api/mongo/todos")]
public class TodosController : ApiController
{
    [HttpPost]
    public async Task<TodoVm> CreateTodo([FromBody] TodoToCreateDto dto)
    {
        return await Mediator.Send(new CreateTodoCommand
        {
            Dto = dto
        });
    }

    [HttpPut("{id}")]
    public async Task<TodoVm> UpdateTodo([FromRoute] string id, [FromBody] TodoToUpdateDto dto)
    {
        return await Mediator.Send(new UpdateTodoCommand
        {
            Dto = dto,
            Id = id
        });
    }

    //[HttpPut("completed/{id}")]
    //public async Task<TodoVm> PatchCompleted([FromRoute] long id, [FromBody] TodoCompletedToPatchDto dto)
    //{
    //    return await Mediator.Send(new PatchCompletedCommand
    //    {
    //        Dto = dto,
    //        Id = id
    //    });
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(string id)
    {
        await Mediator.Send(new DeleteTodoCommand
        {
            Id = id
        });

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<TodoVm> GetTodo([FromHeader(Name = "Accept-Language")] [Required] string lang, string id)
    {
        return await Mediator.Send(new GetTodoQuery
        {
            Id = id
        });
    }

    [HttpGet]
    public async Task<List<TodoVm>> GetTodos()
    {
        return await Mediator.Send(new GetTodosQuery());
    }

    [HttpGet]
    [Route("paged")]
    public async Task<PagedVm<TodoHeaderVm>> GetTodosPaged([FromQuery] TodoToPagedDto dto)
    {
        return await Mediator.Send(new GetTodosPagedQuery
        {
            Dto = dto
        });
    }
}