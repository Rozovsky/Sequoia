using AutoMapper;
using Samples.Authentication.Basic.Core.Domain.Entities;
using Samples.Authentication.Basic.Core.Domain.Enums;

namespace Samples.Authentication.Basic.Core.Application.Locations.ViewModels
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
