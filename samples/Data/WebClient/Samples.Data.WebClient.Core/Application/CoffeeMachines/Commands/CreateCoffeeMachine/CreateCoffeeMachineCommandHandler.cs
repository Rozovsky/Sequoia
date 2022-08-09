using AutoMapper;
using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommandHandler : IRequestHandler<CreateCoffeeMachineCommand, CoffeeMachineVm>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;
        private readonly IMapper _mapper;

        public CreateCoffeeMachineCommandHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
        }

        public async Task<CoffeeMachineVm> Handle(CreateCoffeeMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineService.CreateCoffeeMachine(request.Dto, cancellationToken);

            return _mapper.Map<CoffeeMachineVm>(machine);
        }
    }
}
