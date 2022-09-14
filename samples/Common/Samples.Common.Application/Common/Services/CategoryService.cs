using AutoMapper;
using Samples.Common.Application.Categories.Dtos;
using Samples.Common.Application.Interfaces;
using Samples.Common.Domain.Entities;
using Samples.Common.Infrastructure.Interfaces;
using Sequoia.Data.Models;

namespace Samples.Common.Application.Common.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        //public async Task<Category> CreateCategoryAsync(CategoryToCreateDto dto, CancellationToken cancellationToken)
        //{
        //    var category = _mapper.Map<Category>(dto);
        //    category = await _categoryRepository.CreateCategoryAsync(category, cancellationToken);

        //    return category;
        //}

        public Task DeleteCategoryAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PagedWrapper<Category>> GetCategoriesPagedAsync(int page, int limit, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(long id, Category obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /*public async Task<Store> CreateStore(StoreToCreateDto dto, CancellationToken cancellationToken)
        {
            var store = _mapper.Map<Store>(dto);

            await _dbContext.Stores.InsertOneAsync(store, cancellationToken: cancellationToken);
            return store;
        }*/

        /*public async Task<Store> UpdateStore(string id, StoreToUpdateDto dto, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            _mapper.Map(dto, store);

            await _dbContext.Stores.ReplaceOneAsync(
                c => c.Id == id, store,
                new ReplaceOptions { IsUpsert = true },
                cancellationToken: cancellationToken);

            return store;
        }*/

        /*public async Task DeleteStore(string id, CancellationToken cancellationToken)
        {
            var store = await this.GetStore(id, cancellationToken);

            await _dbContext.Stores.DeleteOneAsync(c => c.Id == id, cancellationToken);
        }*/

        /*public async Task<Store> GetStore(string id, CancellationToken cancellationToken)
        {
            var store = await _dbContext.Stores
                .AsQueryable()
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (store == null)
                throw new NotFoundException(nameof(Store), id);
            return store;
        }*/

        /*public async Task<List<Store>> GetStores(CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsQueryable()
                .ToListAsync(cancellationToken);
            return stores;
        }*/

        /*public async Task<PagedWrapper<Store>> GetStoresPaged(int page, int limit, CancellationToken cancellationToken)
        {
            var stores = await _dbContext.Stores
                .AsQueryable()
                .Where(c => c.Address.Length > 0)
                .ToPagedListAsync(page, limit, cancellationToken);

            return stores;
        }*/
    }
}
