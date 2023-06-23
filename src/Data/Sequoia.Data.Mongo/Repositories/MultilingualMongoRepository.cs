using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Sequoia.Data.Interfaces;
using Sequoia.Data.Models;
using Sequoia.Data.Mongo.Entities;
using Sequoia.Data.Mongo.Extensions;
using Sequoia.Data.Mongo.Interfaces;
using System.Linq.Expressions;

namespace Sequoia.Data.Mongo.Repositories
{
    public abstract class MultilingualMongoRepository<TEntity> : MongoRepository<TEntity>, IMongoRepository<TEntity> 
        where TEntity : class
    {
        private string CurrentLanguage { get; set; }

        protected MultilingualMongoRepository(IMongoContext context, string language) : base(context)
        {
            CurrentLanguage = language;
        }

        private IEnumerable<TEntity> SetMultilingualEntityValues(IEnumerable<TEntity> objs)
        {
            if (CurrentLanguage == null)
                return objs;

            var first = objs.FirstOrDefault();

            if (first == null || first is not IMultilingual<Translation>)
                return objs;

            foreach (var obj in objs)
            {
                SetMultilingualEntityValues(obj);
            }

            return objs;
        }

        private TEntity SetMultilingualEntityValues(TEntity obj)
        {
            if (CurrentLanguage == null)
                return obj;

            if (obj is not IMultilingual<Translation>)
                return obj;

            var multilingual = obj as IMultilingual<Translation>;
            if (multilingual.Translations == null || multilingual.Translations.Count == 0)
                return obj;

            var properties = obj.GetType().GetProperties();
            var translations = multilingual.Translations
                .Where(c => c.Language == CurrentLanguage)
                .ToList();

            foreach (var translation in translations)
            {
                var property = properties.FirstOrDefault(c => c.Name.ToLower() == translation.Field.ToLower());
                if (property == null)
                    continue;

                property.SetValue(obj, translation.Value);
            }

            return obj;
        }

        public override async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            var entity = await MongoCollection
                .AsQueryable()
                .SingleOrDefaultAsync(predicate, cancellationToken);

            SetMultilingualEntityValues(entity);

            return entity;
        }

        public override async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await MongoCollection
                .AsQueryable()
                .ToListAsync(cancellationToken);

            SetMultilingualEntityValues(entities);

            return entities;
        }

        public override async Task<PagedWrapper<TEntity>> GetPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            var entities = await MongoCollection
                .AsQueryable()
                .ToPagedListAsync(page, limit, cancellationToken);

            SetMultilingualEntityValues(entities.Items);

            return entities;
        }
    }
}
