using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public long Id { get; set; }
        public CoffeeMachineToUpdateDto Dto { get; set; }
    }
}
