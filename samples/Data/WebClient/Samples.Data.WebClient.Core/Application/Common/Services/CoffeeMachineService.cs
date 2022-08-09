using Samples.Data.WebClient.Core.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.WebClient.Core.Application.Common.Services
{
    public class CoffeeMachineService : ICoffeeMachineService
    {
        private readonly ICoffeeMachineRepository _coffeeMachineRepository;

        public CoffeeMachineService(ICoffeeMachineRepository coffeeMachineRepository)
        {
            _coffeeMachineRepository = coffeeMachineRepository;
        }
    }
}
