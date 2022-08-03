using AutoMapper;
using Samples.Data.Postgresql.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Samples.Data.Postgresql.Core.Domain.Enums;

namespace Samples.Data.Postgresql.Core.Application.Stores.ViewModels
{
    [AutoMap(typeof(Store))]
    public class StoreVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType Type { get; set; }
        public IEnumerable<CoffeeMachineVm> CoffeeMachines { get; set; }
    }
}
