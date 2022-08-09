using AutoMapper;
using Samples.Data.WebClient.Core.Domain.Models.Locations;

namespace Samples.Data.WebClient.Core.Application.Locations.ViewModels
{
    [AutoMap(typeof(Location))]
    public class LocationVm
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }
        public string NameOld { get; set; }
        public LocationType? TypeOld { get; set; }
        public bool IsDeleted { get; set; }
    }
}
