using Microsoft.EntityFrameworkCore;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeEntity>().HasData(
                new CoffeeEntity
                {
                    Name = "Loar",
                    Price = 10.6M
                },
                new CoffeeEntity
                {
                    Name = "Uklo",
                    Price = 16.2M
                }
            );
        }
    }
}
