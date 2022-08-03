using Sequoia.Abstractions;

namespace Samples.Data.Postgresql.Core.Domain.Entities
{
    public class Shop : EntityAuditable<long, string, DateTimeOffset?>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
