using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class StoreRepository : MongoRepository<Store>, IStoreRepository
    {
        protected IMongoCollection<Store> _machineCollection;

        public StoreRepository(IMongoContext context) : base(context)
        {
            _machineCollection = MongoContext.GetCollection<Store>(nameof(Store));
        }
    }
}
