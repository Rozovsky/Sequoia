using MediatR;
using Samples.Data.Mongo.Core.Application.Stores.Dtos;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<StoreVm>
    {
        public StoreToCreateDto Dto { get; set; }
    }
}
