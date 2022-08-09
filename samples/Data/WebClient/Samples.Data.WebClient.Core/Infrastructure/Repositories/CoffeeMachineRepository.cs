using Samples.Data.WebClient.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using Samples.Data.WebClient.Core.Domain.Models.CoffeeMachines;

namespace Samples.Data.WebClient.Core.Infrastructure.Repositories
{
    public class CoffeeMachineRepository : ICoffeeMachineRepository
    {
        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            /*var machine = _mapper.Map<CoffeeMachine>(dto);

            _dbContext.CoffeeMachines.Add(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);*/

            return new CoffeeMachine();
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            /*var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _mapper.Map(dto, machine);

            await _dbContext.SaveChangesAsync(cancellationToken);*/

            return new CoffeeMachine();
        }

        public async Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            /*var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _dbContext.CoffeeMachines.Remove(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);*/
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            /*var machine = await _dbContext.CoffeeMachines
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (machine == null)
                throw new NotFoundException(nameof(CoffeeMachine), id);*/

            return new CoffeeMachine();
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            /*var machines = await _dbContext.CoffeeMachines
                .AsNoTracking()
                .ToListAsync(cancellationToken);*/

            return new List<CoffeeMachine>();
        }

        // TODO: add paged
    }
}
