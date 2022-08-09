using Samples.Data.WebClient.Core.Domain.Models.Stores;

namespace Samples.Data.WebClient.Core.Application.Stores.Dtos
{
    public class StoreToUpdateDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public StoreType Type { get; set; }
        //public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
