using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public CoffeeMachineToCreateDto Dto { get; set; }
    }
}
