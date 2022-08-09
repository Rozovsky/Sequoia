using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines;

namespace Samples.Data.WebClient.Core.Application.Common.Interfaces
{
    public interface ICoffeeMachineRepository
    {
        Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken);
        Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken);
        Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken);
        Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken);
    }
}
