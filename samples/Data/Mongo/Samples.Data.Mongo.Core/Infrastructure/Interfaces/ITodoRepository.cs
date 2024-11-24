using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces;

public interface ITodoRepository : IMongoRepository<Todo>
{
}