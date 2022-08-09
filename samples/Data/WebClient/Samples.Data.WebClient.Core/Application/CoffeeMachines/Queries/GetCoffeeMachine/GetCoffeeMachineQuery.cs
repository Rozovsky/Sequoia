using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine
{
    public class GetCoffeeMachineQuery : IRequest<CoffeeMachineVm>
    {
        public long Id { get; set; }
    }
}
