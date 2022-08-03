using AutoMapper;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels
{
    [AutoMap(typeof(CoffeeMachine))]
    public class CoffeeMachineVm
    {
        public long Id { get; set; }
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? DateOfCreation { get; set; }
        public DateTimeOffset? DateOfModification { get; set; }
    }
}
