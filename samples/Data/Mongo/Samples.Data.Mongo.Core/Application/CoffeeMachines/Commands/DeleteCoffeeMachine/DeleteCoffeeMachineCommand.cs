using MediatR;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommand : IRequest
    {
        public long Id { get; set; }
    }
}
