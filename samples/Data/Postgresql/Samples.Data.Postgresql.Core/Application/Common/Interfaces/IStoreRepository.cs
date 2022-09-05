using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Data.Postgresql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.Postgresql.Core.Application.Common.Interfaces
{
    public interface IStoreRepository : IPostgresRepository<Store>
    {
    }
}
