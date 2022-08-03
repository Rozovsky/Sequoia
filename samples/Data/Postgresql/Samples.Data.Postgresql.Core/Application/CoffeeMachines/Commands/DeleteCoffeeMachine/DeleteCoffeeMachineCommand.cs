using MediatR;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommand : IRequest
    {
        public long Id { get; set; }
    }
}
