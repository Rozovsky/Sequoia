using AutoMapper;
using Samples.Data.Mongo.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.Mongo.Core.Domain.Entities;
using Samples.Data.Mongo.Core.Domain.Enums;

namespace Samples.Data.Mongo.Core.Application.Stores.ViewModels
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
