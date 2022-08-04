using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure
{
    public class ApplicationDbContext : MongoRepository<Store>, IApplicationDbContext
    {
        public IMongoCollection<CoffeeMachine> CoffeeMachines { get; private set; }
        public IMongoCollection<Store> Stores { get; private set; }

        public ApplicationDbContext(IMongoContext context) : base(context)
        {
            CoffeeMachines = _context.GetCollection<CoffeeMachine>(nameof(CoffeeMachine));
            Stores = _context.GetCollection<Store>(nameof(Store));
        }
    }
}
