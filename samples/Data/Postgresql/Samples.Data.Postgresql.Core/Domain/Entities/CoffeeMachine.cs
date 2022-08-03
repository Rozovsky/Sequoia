using Sequoia.Abstractions;

namespace Samples.Data.Postgresql.Core.Domain.Entities
{
    public class CoffeeMachine : EntityAuditable<long, string, DateTimeOffset?>
    {
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
