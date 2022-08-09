using AutoMapper;
using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachines
{
    public class GetCoffeeMachinesQueryHandler : IRequestHandler<GetCoffeeMachinesQuery, List<CoffeeMachineVm>>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;
        private readonly IMapper _mapper;

        public GetCoffeeMachinesQueryHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
        }

        public async Task<List<CoffeeMachineVm>> Handle(GetCoffeeMachinesQuery request, CancellationToken cancellationToken)
        {
            var machines = await _coffeeMachineService.GetCoffeeMachines(cancellationToken);

            return _mapper.Map<List<CoffeeMachineVm>>(machines);
        }
    }
}
