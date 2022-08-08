using Sequoia.Data.Abstractions;
using Sequoia.Data.Interfaces;
using Sequoia.Data.WebClient.Extensions;
using Sequoia.Data.WebClient.Interfaces;
using Sequoia.Data.WebClient.Models;

namespace Sequoia.Data.WebClient.Repositories
{
    public class WebRepository<TEntity, TrimaryKey> : IRepositoryBase<TEntity, TrimaryKey> where TEntity : class
    {
        private readonly IWebClient _webClient;
        private WebRepositoryConfiguration WebRepositoryConfiguration { get; set; }

        public WebRepository(Action<IWebRepositoryConfiguration> webRepositoryConfiguration)
        {
            // get configuration
            WebRepositoryConfiguration = new WebRepositoryConfiguration();
            webRepositoryConfiguration.Invoke(WebRepositoryConfiguration);

            _webClient = WebRepositoryConfiguration.WebClient;
        }

        public virtual async Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            var rows = await _webClient
                .Get<List<TEntity>>(WebRepositoryConfiguration.EndpointGetAll, cancellationToken);

            return rows;
        }

        public virtual async Task<PagedWrapper<TEntity>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var rows = await _webClient
                .WithQueryParams(new { Page = page, PageSize = pageSize })
                .Get<PagedWrapper<TEntity>>(WebRepositoryConfiguration.EndpointGetAllPaged, cancellationToken);

            return rows;
        }

        public virtual async Task<TEntity> GetById(object id, CancellationToken cancellationToken)
        {
            var row = await _webClient
               .Get<TEntity>($"{WebRepositoryConfiguration.EndpointGetById}/{id}", cancellationToken);

            return row;
        }
    }
}
