using MediatR;
using Samples.Data.Postgresql.Core.Application.Stores.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.Stores.Queries.GetStores
{
    public class GetStoresQuery : IRequest<List<StoreVm>>
    {
    }
}
