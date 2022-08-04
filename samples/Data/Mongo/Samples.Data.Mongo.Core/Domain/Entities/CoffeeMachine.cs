using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Sequoia.Abstractions;

namespace Samples.Data.Mongo.Core.Domain.Entities
{
    [AutoMap(typeof(CoffeeMachineToCreateDto))]
    [AutoMap(typeof(CoffeeMachineToUpdateDto))]
    public class CoffeeMachine : EntityAuditable<string, string, DateTimeOffset?>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public override string Id { get; set; }
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
