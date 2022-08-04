using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Commands.UpdateStore
{
    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, StoreVm>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(
            IStoreService storeService,
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<StoreVm> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _storeService.UpdateStore(request.Id, request.Dto, cancellationToken);

            return _mapper.Map<StoreVm>(store);
        }
    }
}
