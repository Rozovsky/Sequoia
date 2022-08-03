using MediatR;
using Samples.Data.Postgresql.Core.Application.Stores.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQuery : IRequest<StoreVm>
    {
        public long Id { get; set; }
    }
}
