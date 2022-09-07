using MongoDB.Driver;
using Samples.Common.Domain.Entities;
using Samples.Data.Mongo.Core.Infrastructure.Configurations;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
    {
        protected IMongoCollection<Category> _categoryCollection;

        public CategoryRepository(IMongoContext context) : base(context)
        {
            _categoryCollection = MongoContext.GetCollection<Category>(CategoryConfig.GetCollectionName());
        }
    }
}
