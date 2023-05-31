using Microsoft.AspNetCore.Mvc;
using Samples.Client.Http.Core.Application.Common.ViewModels;
using Samples.Client.Http.Core.Application.Todos.Queries.GetTodo;
using Sequoia.Models;

namespace Samples.Client.Http.Api.Controllers
{
    [Route("api/http/todos")]
    public class TodosController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<TodoVm> GetTodo(long id)
        {
            return await Mediator.Send(new GetTodoQuery
            {
                Id = id
            });
        }
    }
}
