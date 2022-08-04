using MediatR;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQuery : IRequest<StoreVm>
    {
        public long Id { get; set; }
    }
}
