using MediatR;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Queries.GetCoffeeMachines
{
    public class GetCoffeeMachinesQuery : IRequest<List<CoffeeMachineVm>>
    {
    }
}
