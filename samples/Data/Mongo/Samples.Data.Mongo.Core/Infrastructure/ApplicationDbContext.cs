using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<CoffeeMachine> CoffeeMachines { get; private set; }
        public IMongoCollection<Store> Stores { get; private set; }

        public ApplicationDbContext(IMongoContext context)
        {
            CoffeeMachines = context.GetCollection<CoffeeMachine>(nameof(CoffeeMachine));
            Stores = context.GetCollection<Store>(nameof(Store));
        }
    }
}
