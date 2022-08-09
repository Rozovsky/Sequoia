using AutoMapper;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines;

namespace Samples.Data.WebClient.Core.Application.Common.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly ICoffeeMachineRepository _coffeeMachineRepository;

        public CoffeeMachineService(ICoffeeMachineRepository coffeeMachineRepository)
        {
            _coffeeMachineRepository = coffeeMachineRepository;
        }

        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineRepository.CreateCoffeeMachine(dto, cancellationToken);

            return machine;
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineRepository.UpdateCoffeeMachine(id, dto, cancellationToken);

            return machine;
        }

        public async Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            await _coffeeMachineRepository.DeleteCoffeeMachine(id, cancellationToken);
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineRepository.GetCoffeeMachine(id, cancellationToken);

            return machine;
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            var machines = await _coffeeMachineRepository.GetCoffeeMachines(cancellationToken);

            return machines;
        }
    }
}
