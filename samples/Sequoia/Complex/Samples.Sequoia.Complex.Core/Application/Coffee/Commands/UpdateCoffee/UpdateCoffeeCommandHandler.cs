using AutoMapper;
using MediatR;
using Samples.Sequoia.Complex.Core.Application.Common.Interfaces;
using Samples.Sequoia.Complex.Core.Application.Common.ViewModels;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.UpdateCoffee
{
    public class UpdateCoffeeCommandHandler : IRequestHandler<UpdateCoffeeCommand, CoffeeVm>
    {
        private readonly ICoffeeService _coffeeService;
        private readonly IMapper _mapper;

        public UpdateCoffeeCommandHandler(
            ICoffeeService coffeeService,
            IMapper mapper)
        {
            _coffeeService = coffeeService;
            _mapper = mapper;
        }

        public async Task<CoffeeVm> Handle(UpdateCoffeeCommand request, CancellationToken cancellationToken)
        {
            // TODO: get coffee from _coffeeService
            var coffee = new CoffeeEntity { Id = 1 };

            // TODO: add to DB
            _mapper.Map(request.Dto, coffee);

            return _mapper.Map<CoffeeVm>(coffee);
        }
    }
}
