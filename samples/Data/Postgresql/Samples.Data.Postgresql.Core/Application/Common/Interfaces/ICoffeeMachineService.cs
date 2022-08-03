using Samples.Data.Postgresql.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Postgresql.Core.Domain.Entities;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
{
    public interface ICoffeeMachineService
    {
        Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken);
        Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken);
        Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken);
        Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken);
        Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken);
    }
}
