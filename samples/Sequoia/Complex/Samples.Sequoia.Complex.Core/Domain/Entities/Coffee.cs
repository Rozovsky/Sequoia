using AutoMapper;
using Samples.Sequoia.Complex.Core.Application.Common.Dto;

namespace Samples.Sequoia.Complex.Core.Domain.Entities
{
    [AutoMap(typeof(CoffeeToCreateDto))]
    [AutoMap(typeof(CoffeeToUpdateDto))]
    public class Coffee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
