using Microsoft.AspNetCore.Http;
using Samples.Data.Mongo.Core.Domain;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Sequoia.Data.Mongo.Interfaces;
using Sequoia.Data.Mongo.Repositories;

namespace Samples.Data.Mongo.Core.Infrastructure.Repositories
{
    public class TodoRepository : MultilingualMongoRepository<Todo>, ITodoRepository
    {
        public TodoRepository(
            IMongoContext context, 
            IHttpContextAccessor httpContextAccessor) : base(
                context, 
                language: httpContextAccessor.HttpContext?.Request?.Headers.FirstOrDefault(c => c.Key == "Accept-Language").Value)
        {
        }

        public async Task<Todo> CreateTodo(Todo obj, CancellationToken cancellationToken)
        {
            return await base.CreateAsync(obj, cancellationToken);
        }

        //public async Task DeleteCategoryAsync(string id, CancellationToken cancellationToken)
        //{
        //    await base.DeleteAsync(c => c.Id == id, cancellationToken);
        //}

        //public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        //{
        //    return await base.GetAllAsync(cancellationToken);
        //}

        //public async Task<PagedWrapper<Category>> GetCategoriesPagedAsync(int page, int limit, CancellationToken cancellationToken)
        //{
        //    return await base.GetPagedAsync(page, limit, cancellationToken);
        //}

        public async Task<Todo> GetTodo(string id, CancellationToken cancellationToken)
        {
            return await base.GetAsync(c => c.Id == id, cancellationToken);
        }

        //public async Task<Category> UpdateCategoryAsync(string id, Category obj, CancellationToken cancellationToken)
        //{
        //    return await base.UpdateAsync(c => c.Id == id, obj, cancellationToken);
        //}
    }
}
