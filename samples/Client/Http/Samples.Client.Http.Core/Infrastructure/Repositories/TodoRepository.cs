using Samples.Client.Http.Core.Application.Common.Interfaces;
using Samples.Client.Http.Core.Domain.Entities;
using Sequoia.Client.Http;

namespace Samples.Client.Http.Core.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IClient _client;

        public TodoRepository(IClient client)
        {
            _client = client;
        }

        public async Task<Todo> GetTodo(long id, CancellationToken cancellationToken)
        {
            var result = await _client
                .Path("https://jsonplaceholder.typicode.com/todos")
                .Get<Todo>($"/{id}", cancellationToken);

            return result;
        }

        //public async Task MakeQuery()
        //{
        //    var result = await _client
        //        .Path("https://google.com")
        //        .Path("fit-api/equipments")
        //        .Query("?id=10")
        //        .Query(new { id = 10, type = 2 })
        //        .Auth("Bearer token")
        //        .Auth("Basic token")
        //        .Headers("x-client-id", 100)
        //        .Body("my payload")
        //        .Get<string>(CancellationToken.None);

        //    //_client.Configuration.Query
        //}
    }
}
