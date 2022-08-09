using MediatR;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommand : IRequest
    {
        public long Id { get; set; }
    }
}
