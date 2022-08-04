using AutoMapper;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.Dtos;
using Samples.Data.Mongo.Core.Application.Common.Interfaces;
using Samples.Data.Mongo.Core.Domain.Entities;
using Sequoia.Exceptions;

namespace Samples.Data.Mongo.Core.Application.Common.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        //private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICoffeeMachineRepository _coffeeMachineRepository;

        public CoffeeMachineService(
            //IApplicationDbContext dbContext,
            IMapper mapper, 
            ICoffeeMachineRepository coffeeMachineRepository)
        {
            //_dbContext = dbContext;
            _mapper = mapper;
            _coffeeMachineRepository = coffeeMachineRepository;
        }

        public async Task<CoffeeMachine> CreateCoffeeMachine(CoffeeMachineToCreateDto dto, CancellationToken cancellationToken)
        {
            var machine = _mapper.Map<CoffeeMachine>(dto);

            machine = await _coffeeMachineRepository.AddAsync(machine, cancellationToken);

            return machine;
        }

        public async Task<CoffeeMachine> UpdateCoffeeMachine(string id, CoffeeMachineToUpdateDto dto, CancellationToken cancellationToken)
        {
            var machine = await this.GetCoffeeMachine(id, cancellationToken);
            _mapper.Map(dto, machine);

            machine = await _coffeeMachineRepository.UpdateAsync(c => c.Id == id, machine, cancellationToken);

            return machine;
        }

        public async Task DeleteCoffeeMachine(string id, CancellationToken cancellationToken)
        {
            var machine = await this.GetCoffeeMachine(id, cancellationToken);

            await _coffeeMachineRepository.DeleteAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<CoffeeMachine> GetCoffeeMachine(string id, CancellationToken cancellationToken)
        {
            var machine = await _coffeeMachineRepository.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (machine == null)
                throw new NotFoundException(nameof(CoffeeMachine), id);

            return machine;
        }

        public async Task<List<CoffeeMachine>> GetCoffeeMachines(CancellationToken cancellationToken)
        {
            var machines = _coffeeMachineRepository.AsQueryable().ToList();

            return machines;
        }
    }
}
