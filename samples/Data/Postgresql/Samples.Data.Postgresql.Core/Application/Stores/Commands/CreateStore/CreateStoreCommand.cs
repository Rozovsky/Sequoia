using MediatR;
using Samples.Data.Postgresql.Core.Application.Stores.Dtos;
using Samples.Data.Postgresql.Core.Application.Stores.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommand : IRequest<StoreVm>
    {
        public StoreToCreateDto Dto { get; set; }
    }
}
