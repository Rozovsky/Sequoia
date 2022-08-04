using MediatR;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;

namespace Samples.Data.Mongo.Core.Application.CoffeeMachines.Queries.GetCoffeeMachine
{
    public class GetCoffeeMachineQuery : IRequest<CoffeeMachineVm>
    {
        public string Id { get; set; }
    }
}
