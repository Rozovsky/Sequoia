using Microsoft.EntityFrameworkCore;
using Samples.Data.Postgresql.Core.Application.Common.Interfaces;
using Samples.Data.Postgresql.Core.Domain.Entities;
using Sequoia.Data.Postgresql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples.Data.Postgresql.Core.Infrastructure.Repositories
{
    public class StoreRepository : PostgresRepository<Store>, IStoreRepository
    {
        public StoreRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
