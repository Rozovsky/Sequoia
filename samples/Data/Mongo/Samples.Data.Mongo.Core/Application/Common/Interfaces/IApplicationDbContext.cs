using MongoDB.Driver;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        IMongoCollection<CoffeeMachine> CoffeeMachines { get;}
        IMongoCollection<Store> Stores { get; }
    }
}
