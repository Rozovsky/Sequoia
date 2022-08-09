using MediatR;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommandHandler : AsyncRequestHandler<DeleteStoreCommand>
    {
        private readonly IStoreService _storeService;

        public DeleteStoreCommandHandler(IStoreService storeService)
        {
            _storeService = storeService;
        }

        protected override async Task Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            await _storeService.DeleteStore(request.Id, cancellationToken);
        }
    }
}
