using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Application.Stores.ViewModels;
using Sequoia.Data.Abstractions;

namespace Samples.Data.Mongo.Core.Application.Stores.Queries.GetStoresPaged
{
    public class GetStoresPagedQueryHandler : IRequestHandler<GetStoresPagedQuery, PagedWrapper<StoreVm>>
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public GetStoresPagedQueryHandler(
            IStoreService storeService,
            IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        public async Task<PagedWrapper<StoreVm>> Handle(GetStoresPagedQuery request, CancellationToken cancellationToken)
        {
            var stores = await _storeService.GetStoresPaged(request.Page, request.Limit, cancellationToken);
            
            return _mapper.Map<PagedWrapper<StoreVm>>(stores);
        }
    }
}
