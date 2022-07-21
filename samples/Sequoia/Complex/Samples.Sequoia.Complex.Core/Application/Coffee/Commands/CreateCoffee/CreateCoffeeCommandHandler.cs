using AutoMapper;
using MediatR;
using Samples.Sequoia.Complex.Core.Application.Common.Interfaces;
using Samples.Sequoia.Complex.Core.Application.Common.ViewModels;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.CreateCoffee
{
    public class CreateCoffeeCommandHandler : IRequestHandler<CreateCoffeeCommand, CoffeeVm>
    {
        private readonly ICoffeeService _coffeeService;
        private readonly IMapper _mapper;

        public CreateCoffeeCommandHandler(
            ICoffeeService coffeeService,
            IMapper mapper)
        {
            _coffeeService = coffeeService;
            _mapper = mapper;
        }

        public async Task<CoffeeVm> Handle(CreateCoffeeCommand request, CancellationToken cancellationToken)
        {
            var coffee = _mapper.Map<CoffeeEntity>(request.Dto);

            // TODO: add to DB
            coffee.Id = 1;

            return _mapper.Map<CoffeeVm>(coffee);
        }
    }
}
