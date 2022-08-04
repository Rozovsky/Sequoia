using AutoMapper;
using MediatR;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Exceptions;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommandHandler : IRequestHandler<CreateCoffeeMachineCommand, CoffeeMachineVm>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;    
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;

        public CreateCoffeeMachineCommandHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper,
            IStoreService storeService)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
            _storeService = storeService;
        }

        public async Task<CoffeeMachineVm> Handle(CreateCoffeeMachineCommand request, CancellationToken cancellationToken)
        {
            // check store exist
            var store = await _storeService.GetStore(request.Dto.StoreId, cancellationToken);
            if (store == null)
                throw new NotFoundException(nameof(Store), request.Dto.StoreId);

            var machine = await _coffeeMachineService.CreateCoffeeMachine(request.Dto, cancellationToken);

            return _mapper.Map<CoffeeMachineVm>(machine);
        }
    }
}
