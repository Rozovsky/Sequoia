using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public CoffeeMachineToCreateDto Dto { get; set; }
    }
}
