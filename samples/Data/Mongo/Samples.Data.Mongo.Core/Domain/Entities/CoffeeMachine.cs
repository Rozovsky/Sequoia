using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Sequoia.Interfaces;

namespace Samples.Data.Mongo.Core.Domain.Entities
{
    [AutoMap(typeof(CoffeeMachineToCreateDto))]
    [AutoMap(typeof(CoffeeMachineToUpdateDto))]
    public class CoffeeMachine : IEntityAuditable<string, string, DateTimeOffset?>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? DateOfCreation { get; set; }
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
