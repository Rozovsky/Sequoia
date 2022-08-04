using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Exceptions;

namespace Samples.Data.Postgresql.Core.Application.Common.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CoffeeMachineService(
            IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            var machine = _mapper.Map<CoffeeMachine>(dto);

            _dbContext.CoffeeMachines.Add(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return machine;
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(long id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _mapper.Map(dto, machine);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return machine;
        }

        public async Task DeleteCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _dbContext.CoffeeMachines.Remove(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(long id, CancellationToken cancellationToken)
        {
            var machine = await _dbContext.CoffeeMachines
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (machine == null)
                throw new NotFoundException(nameof(CoffeeMachine), id);

            return machine;
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            var machines = await _dbContext.CoffeeMachines
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return machines;
        }
    }
}
