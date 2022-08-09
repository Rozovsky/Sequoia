using MediatR;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<StoreVm>
    {
        public StoreToCreateDto Dto { get; set; }
    }
}
