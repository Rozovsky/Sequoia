using AutoMapper;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels
{
    [AutoMap(typeof(CoffeeMachine))]
    public class CoffeeMachineVm
    {
        public string Id { get; set; }
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? DateOfCreation { get; set; }
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
