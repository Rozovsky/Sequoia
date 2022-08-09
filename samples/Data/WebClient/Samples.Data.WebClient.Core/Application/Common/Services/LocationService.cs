using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.WebClient.Core.Application.Common.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationService _locationService;

        public LocationService(ILocationService locationService)
        {
            _locationService = locationService;
        }
    }
}
