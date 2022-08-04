using AutoMapper;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Enums;
using Sequoia.Abstractions;

namespace Samples.Data.Mongo.Core.Domain.Entities
{
    [AutoMap(typeof(StoreToCreateDto))]
    [AutoMap(typeof(StoreToUpdateDto))]
    public class Store : EntityAuditable<long, string, DateTimeOffset?>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }
        public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
