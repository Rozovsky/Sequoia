using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequoia.Data.Postgresql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgresql(this IServiceCollection services, IConfiguration configuration)
        {
            // add pgsql db
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseNpgsql(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}
