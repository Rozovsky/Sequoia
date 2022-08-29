using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Interfaces
{
    public interface ICoffeeMachineService
    {
        Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken);
        Task<CoffeeMachine> UpdateCoffeeMachine(string id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteCoffeeMachine(string id, CancellationToken cancellationToken);
        Task<CoffeeMachine> GetCoffeeMachine(string id, CancellationToken cancellationToken);
        Task<IEnumerable<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken);
    }
}
