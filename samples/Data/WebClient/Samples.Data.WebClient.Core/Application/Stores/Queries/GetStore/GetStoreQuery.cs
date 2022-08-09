using MediatR;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQuery : IRequest<StoreVm>
    {
        public long Id { get; set; }
    }
}
