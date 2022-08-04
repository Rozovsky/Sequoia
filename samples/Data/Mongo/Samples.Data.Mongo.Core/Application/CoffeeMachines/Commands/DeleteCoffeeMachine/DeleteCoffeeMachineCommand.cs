using MediatR;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.DeleteCoffeeMachine
{
    public class DeleteCoffeeMachineCommand : IRequest
    {
        public string Id { get; set; }
    }
}
