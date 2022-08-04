using AutoMapper;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Sequoia.Abstractions;

namespace Samples.Data.Mongo.Core.Domain.Entities
{
    [AutoMap(typeof(CoffeeMachineToCreateDto))]
    [AutoMap(typeof(CoffeeMachineToUpdateDto))]
    public class CoffeeMachine : EntityAuditable<long, string, DateTimeOffset?>
    {
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
