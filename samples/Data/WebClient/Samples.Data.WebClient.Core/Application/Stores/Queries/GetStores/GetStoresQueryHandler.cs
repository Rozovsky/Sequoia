using AutoMapper;
using MediatR;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Application.Stores.ViewModels;

namespace Samples.Data.WebClient.Core.Application.Stores.Queries.GetStores
{
    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, List<StoreVm>>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public GetStoresQueryHandler(
            IStoreService storeService,
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<List<StoreVm>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeService.GetStores(cancellationToken);

            return _mapper.Map<List<StoreVm>>(store);
        }
    }
}
