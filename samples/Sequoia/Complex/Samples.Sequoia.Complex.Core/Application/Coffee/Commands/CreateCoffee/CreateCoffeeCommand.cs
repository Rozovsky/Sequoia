using MediatR;
using Samples.Sequoia.Complex.Core.Application.Common.Dto;
using Samples.Sequoia.Complex.Core.Application.Common.ViewModels;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.CreateCoffee
{
    public class CreateCoffeeCommand : IRequest<CoffeeVm>
    {
        public CoffeeToCreateDto Dto { get; set; }
    }
}
