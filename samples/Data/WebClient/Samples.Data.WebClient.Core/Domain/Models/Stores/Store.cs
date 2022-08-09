using Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines;
using Sequoia.Abstractions;

namespace Samples.Data.WebClient.Core.Domain.Models.Stores
{
    public class Store : EntityAuditable<long, string, DateTimeOffset?>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public StoreType Type { get; set; }
        public IEnumerable<CoffeeMachine> CoffeeMachines { get; set; }
    }
}
