using Sequoia.Abstractions;

namespace Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines
{
    public class CoffeeMachine : EntityAuditable<long, string, DateTimeOffset?>
    {
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
