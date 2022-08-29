using MongoDB.Driver;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class CoffeeMachineRepository : MongoRepository<CoffeeMachine>, ICoffeeMachineRepository
    {
        protected IMongoCollection<CoffeeMachine> _machineCollection;

        public CoffeeMachineRepository(IMongoContext context) : base(context)
        {
            _machineCollection = MongoContext.GetCollection<CoffeeMachine>(nameof(CoffeeMachine));
        }
    }
}
