using Samples.Common.Domain.Entities;
using Sequoia.Data.Mongo.Interfaces;

namespace Samples.Data.Mongo.Core.Infrastructure.Interfaces
{
    public interface IIngredientRepository : IMongoRepository<Ingredient>
    {
    }
}
