using Sequoia.Client.Http.Configuration;

namespace Sequoia.Client.Http
{
    public interface IClient
    {
        ClientConfiguration Configuration { get; }

        Task<T> Get<T>(string path, CancellationToken cancellationToken) where T : class;
        Task<T> Get<T>(CancellationToken cancellationToken) where T : class;
        Task Get(string path, CancellationToken cancellationToken);
        Task Get(CancellationToken cancellationToken);
    }
}
