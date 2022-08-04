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
            _machineCollection = _context.GetCollection<Store>(nameof(Store));
        }

        /*public async Task<Store> GetByMac(string mac, CancellationToken cancellationToken)
        {
            var data = await _machineCollection.FindAsync(
                Builders<Store>.Filter.Eq("mac", mac), cancellationToken: cancellationToken);

            return data.SingleOrDefault(cancellationToken: cancellationToken);
        }*/
    }
}
