using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Queries.GetCoffeeMachines
{
    public class GetCoffeeMachinesQuery : IRequest<List<CoffeeMachineVm>>
    {
    }
}
