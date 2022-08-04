using Samples.Data.Mongo.Core.Domain.Enums;

namespace Samples.Data.Mongo.Core.Application.Stores.Dtos
{
    public class StoreToCreateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }
        //public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
