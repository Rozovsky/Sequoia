using Microsoft.AspNetCore.Mvc;
using Samples.Client.Http.Core.Application.Common.Dto;
using Samples.Client.Http.Core.Application.Common.ViewModels;
using Samples.Client.Http.Core.Application.Todos.Commands.CreateTodo;
using Samples.Client.Http.Core.Application.Todos.Commands.DeleteTodo;
using Samples.Client.Http.Core.Application.Todos.Commands.PatchCompleted;
using Samples.Client.Http.Core.Application.Todos.Commands.UpdateTodo;
using Samples.Client.Http.Core.Application.Todos.Queries.GetTodo;
using Samples.Client.Http.Core.Application.Todos.Queries.GetTodos;
using Sequoia.Models;

namespace Samples.Client.Http.Api.Controllers
{
    [Route("api/http/todos")]
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
        public async Task<TodoVm> UpdateTodo([FromRoute] long id, [FromBody] TodoToUpdateDto dto)
        {
            return await Mediator.Send(new UpdateTodoCommand
            {
                Dto = dto,
                Id = id
            });
        }

        [HttpPut("completed/{id}")]
        public async Task<TodoVm> PatchCompleted([FromRoute] long id, [FromBody] TodoCompletedToPatchDto dto)
        {
            return await Mediator.Send(new PatchCompletedCommand
            {
                Dto = dto,
                Id = id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(long id)
        {
            await Mediator.Send(new DeleteTodoCommand
            {
                Id = id
            });

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<TodoVm> GetTodo(long id)
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
    }
}
