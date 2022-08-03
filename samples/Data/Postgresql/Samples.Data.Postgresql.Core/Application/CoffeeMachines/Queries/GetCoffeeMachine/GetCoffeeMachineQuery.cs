using MediatR;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine
{
    public class GetCoffeeMachineQuery : IRequest<CoffeeMachineVm>
    {
        public long Id { get; set; }
    }
}
