using MediatR;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStores
{
    public class GetStoresQuery : IRequest<List<StoreVm>>
    {
    }
}
