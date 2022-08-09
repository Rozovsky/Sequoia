using MediatR;
using Samples.Data.WebClient.Core.Application.Stores.Dtos;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest<StoreVm>
    {
        public long Id { get; set; }
        public StoreToUpdateDto Dto { get; set; }
    }
}
