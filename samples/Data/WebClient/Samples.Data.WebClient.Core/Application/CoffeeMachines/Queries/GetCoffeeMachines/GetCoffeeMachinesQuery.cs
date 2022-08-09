using MediatR;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.WebClient.Core.Application.CoffeeMachines.Queries.GetCoffeeMachines
{
    public class GetCoffeeMachinesQuery : IRequest<List<CoffeeMachineVm>>
    {
    }
}
