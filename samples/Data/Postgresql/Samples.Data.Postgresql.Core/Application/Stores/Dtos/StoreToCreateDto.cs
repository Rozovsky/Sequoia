using Samples.Data.Postgresql.Core.Domain.Enums;

namespace Samples.Data.Postgresql.Core.Application.Stores.Dtos
{
    public class StoreToCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public StoreType Type { get; set; }
        //public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
