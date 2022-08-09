using MediatR;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommandHandler : AsyncRequestHandler<DeleteCoffeeMachineCommand>
    {
        private readonly ICoffeeMachineService _coffeeMachineService;

        public DeleteCoffeeMachineCommandHandler(ICoffeeMachineService coffeeMachineService)
        {
            _coffeeMachineService = coffeeMachineService;
        }

        protected override async Task Handle(DeleteCoffeeMachineCommand request, CancellationToken cancellationToken)
        {
            await _coffeeMachineService.DeleteCoffeeMachine(request.Id, cancellationToken);
        }
    }
}
