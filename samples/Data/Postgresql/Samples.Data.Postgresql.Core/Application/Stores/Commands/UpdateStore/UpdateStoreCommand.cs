using MediatR;
using Samples.Data.Postgresql.Core.Application.Stores.Dtos;
using Samples.Data.Postgresql.Core.Application.Stores.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommand : IRequest<StoreVm>
    {
        public long Id { get; set; }
        public StoreToUpdateDto Dto { get; set; }
    }
}
