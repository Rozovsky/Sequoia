using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.Postgresql.Core.Application.CoffeeMachines.Dtos
{
    public class CoffeeMachineToCreateDto
    {
        public long StoreId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
