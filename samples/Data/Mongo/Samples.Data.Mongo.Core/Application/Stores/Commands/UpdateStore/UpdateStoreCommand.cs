using MediatR;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest<StoreVm>
    {
        public string Id { get; set; }
        public StoreToUpdateDto Dto { get; set; }
    }
}
