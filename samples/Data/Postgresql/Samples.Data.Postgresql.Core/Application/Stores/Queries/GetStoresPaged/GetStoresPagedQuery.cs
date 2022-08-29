using MediatR;
using Samples.Data.Postgresql.Core.Application.Stores.ViewModels;
using Sequoia.Data.Models;

namespace Samples.Data.Postgresql.Core.Application.Stores.Queries.GetStoresPaged
{
    public class GetStoresPagedQuery : IRequest<PagedWrapper<StoreVm>>
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
