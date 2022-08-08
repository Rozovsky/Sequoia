using Samples.Authentication.Basic.Core.Domain.Entities;
using Samples.Authentication.Basic.Core.Domain.Enums;

namespace Samples.Authentication.Basic.Core.Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        public static List<Location> Seed()
        {
            var locations = new List<Location>();

            for (int i = 1; i < 30; i++)
            {
                locations.Add(CreateLocation(i));
            }

            return locations;
        }

        private static Location CreateLocation(long  id)
        {
            var nameParts = new string[] { "oda", "lo", "ile", "klo", "nla", "nama", "pal", "den", "ben", "lu", "la" };

            var randomizer = new Random();
            var location = new Location
            {
                Id = id,
                Code = randomizer.NextInt64(0, 1000),
                IsDeleted = Convert.ToBoolean(randomizer.Next(0,1)),
                Name = nameParts[randomizer.Next(0, nameParts.Length - 1)] + nameParts[randomizer.Next(0, nameParts.Length - 1)],
                NameOld = nameParts[randomizer.Next(0, nameParts.Length - 1)] + nameParts[randomizer.Next(0, nameParts.Length - 1)],
                Type = (LocationType)randomizer.Next(0, 14),
                TypeOld = (LocationType)randomizer.Next(0, 14)
            };

            return location;
        }
    }
}
