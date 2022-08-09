using AutoMapper;
using Samples.Data.WebClient.Core.Application.CoffeeMachines.ViewModels;
using Samples.Data.WebClient.Core.Domain.Models.Stores;

namespace Samples.Data.WebClient.Core.Application.Stores.ViewModels
{
    [AutoMap(typeof(Store))]
    public class StoreVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public StoreType Type { get; set; }
        public IEnumerable<CoffeeMachineVm> CoffeeMachines { get; set; }
    }
}
