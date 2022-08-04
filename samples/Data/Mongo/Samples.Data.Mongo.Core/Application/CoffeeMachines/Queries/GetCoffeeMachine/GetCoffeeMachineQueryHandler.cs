using AutoMapper;
using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine
{
    public class GetCoffeeMachineQueryHandler : IRequestHandler<GetCoffeeMachineQuery, CoffeeMachineVm>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;
        private readonly IMapper _mapper;

        public GetCoffeeMachineQueryHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
        }

        public async Task<CoffeeMachineVm> Handle(GetCoffeeMachineQuery request, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineService.GetCoffeeMachine(request.Id, cancellationToken);

            return _mapper.Map<CoffeeMachineVm>(machine);
        }
    }
}
