using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public long Id { get; set; }
        public CoffeeMachineToUpdateDto Dto { get; set; }
    }
}
