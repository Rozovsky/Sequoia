using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.WebClient.Core.Domain.Models.Locations
{
    public class Location
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
