using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStore
{
    public class GetStoreQueryHandler : IRequestHandler<GetStoreQuery, StoreVm>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public GetStoreQueryHandler(
            IStoreService storeService,
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<StoreVm> Handle(GetStoreQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeService.GetStore(request.Id, cancellationToken);

            return _mapper.Map<StoreVm>(store);
        }
    }
}
