using MediatR;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;
using Sequoia.Data.Abstractions;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStoresPaged
{
    public class GetStoresPagedQuery : IRequest<PagedWrapper<StoreVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
