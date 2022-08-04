using AutoMapper;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;

namespace Samples.Data.Mongo.Core.Application.Common.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        //private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CoffeeMachineService(
            //IApplicationDbContext dbContext,
            IMapper mapper)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            /*var machine = _mapper.Map<CoffeeMachine>(dto);

            _dbContext.CoffeeMachines.Add(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return machine;*/

            return new CoffeeMachine();
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(string id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            /*var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _mapper.Map(dto, machine);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return machine;*/

            return new CoffeeMachine();
        }

        public async Task DeleteCoffeeMachine(string id, CancellationToken cancellationToken)
        {
            /*var machine = await this.GetCoffeeMachine(id, cancellationToken);

            _dbContext.CoffeeMachines.Remove(machine);
            await _dbContext.SaveChangesAsync(cancellationToken);*/
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(string id, CancellationToken cancellationToken)
        {
            /*var machine = await _dbContext.CoffeeMachines
                .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (machine == null)
                throw new NotFoundException(nameof(CoffeeMachine), id);

            return machine;*/

            return new CoffeeMachine();
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            /*var machines = await _dbContext.CoffeeMachines
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return machines;*/

            return new List<CoffeeMachine>();
        }
    }
}
