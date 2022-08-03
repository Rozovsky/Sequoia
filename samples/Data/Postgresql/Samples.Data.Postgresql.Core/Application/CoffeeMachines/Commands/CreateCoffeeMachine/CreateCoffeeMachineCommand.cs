using MediatR;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.CreateCoffeeMachine
{
    public class CreateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public CoffeeMachineToCreateDto Dto { get; set; }
    }
}
