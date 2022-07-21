using MediatR;
using Samples.Sequoia.Complex.Core.Application.Common.Dto;
using Samples.Sequoia.Complex.Core.Application.Common.ViewModels;

namespace Samples.Sequoia.Complex.Core.Application.Coffee.Commands.UpdateCoffee
{
    public class UpdateCoffeeCommand : IRequest<CoffeeVm>
    {
        public long Id { get; set; }
        public CoffeeToUpdateDto Dto { get; set; }
    }
}
