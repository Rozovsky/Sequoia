using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Domain.Enums;
using Sequoia.Interfaces;

namespace Samples.Data.Mongo.Core.Domain.Entities
{
    [AutoMap(typeof(StoreToCreateDto))]
    [AutoMap(typeof(StoreToUpdateDto))]
    public class Store : IEntityAuditable<string, string, DateTimeOffset?>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }
        public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? DateOfCreation { get; set; }
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
