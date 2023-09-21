using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Authentication.Models;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class TodoRepository : AuditableMultilingualMongoRepository<Todo>, ITodoRepository
    {
        public TodoRepository(IMongoContext context) : base(
            context,
            new CurrentUser
            {
                Id = "6492a219f14376dee6175f63",
                ProfileId = "6492a219f14376dee6175f63",
                Email = "test@test.com",
                UserName = "test",
                Language = "uk-UA",
                Roles = new List<string>()
            })
        {
        }
    }
}
