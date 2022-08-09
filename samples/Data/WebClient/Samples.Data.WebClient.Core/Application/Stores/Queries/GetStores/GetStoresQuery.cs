using MediatR;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Queries.GetStores
{
    public class GetStoresQuery : IRequest<List<StoreVm>>
    {
    }
}
