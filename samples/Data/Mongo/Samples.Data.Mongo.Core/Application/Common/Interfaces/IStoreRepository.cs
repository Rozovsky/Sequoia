using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface IStoreRepository : IMongoRepository<Store>
    {
    }
}
