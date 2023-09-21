using Samples.Data.Mongo.Core.Domain;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces
{
    public interface ITodoRepository : IMongoRepository<Todo>
    {
    }
}
