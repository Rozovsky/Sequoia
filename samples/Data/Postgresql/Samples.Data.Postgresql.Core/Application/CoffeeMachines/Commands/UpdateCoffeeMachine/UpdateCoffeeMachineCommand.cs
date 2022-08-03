using MediatR;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Commands.UpdateCoffeeMachine
{
    public class UpdateCoffeeMachineCommand : IRequest<CoffeeMachineVm>
    {
        public long Id { get; set; }
        public CoffeeMachineToUpdateDto Dto { get; set; }
    }
}
