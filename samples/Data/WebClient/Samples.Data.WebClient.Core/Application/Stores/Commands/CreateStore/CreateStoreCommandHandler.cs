using AutoMapper;
using MediatR;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Commands.CreateStore
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, StoreVm>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(
            IStoreService storeService,
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<StoreVm> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _storeService.CreateStore(request.Dto, cancellationToken);

            return _mapper.Map<StoreVm>(store);
        }
    }
}
