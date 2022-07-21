using AutoMapper;
using CoffeeEntity = Samples.Sequoia.Complex.Core.Domain.Entities.Coffee;

namespace Samples.Sequoia.Complex.Core.Application.Common.ViewModels
{
    [AutoMap(typeof(CoffeeEntity))]
    public class CoffeeVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
