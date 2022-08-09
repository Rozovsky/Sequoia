using AutoMapper;
using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommandHandler : IRequestHandler<UpdateCoffeeMachineCommand, CoffeeMachineVm>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;
        private readonly IMapper _mapper;

        public UpdateCoffeeMachineCommandHandler(
            ICoffeeMachineService coffeeMachineService,
            IMapper mapper)
        {
            _coffeeMachineService = coffeeMachineService;
            _mapper = mapper;
        }

        public async Task<CoffeeMachineVm> Handle(UpdateCoffeeMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineService.UpdateCoffeeMachine(request.Id, request.Dto, cancellationToken);

            return _mapper.Map<CoffeeMachineVm>(machine);
        }
    }
}
