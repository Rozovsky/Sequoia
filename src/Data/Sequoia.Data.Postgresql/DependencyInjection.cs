using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sequoia.Attributes;
using Sequoia.Data.Models;

namespace Sequoia.Data.Postgresql
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgresql<TContextInterface, TContext>(this IServiceCollection services, string connectionString)
            where TContext : DbContext, TContextInterface
            where TContextInterface : class
        {
            // add pgsql db
            services.AddDbContext<TContext>(options =>
                options.UseNpgsql(connectionString,
                    b => b.MigrationsAssembly(typeof(TContext).Assembly.FullName)));

            services.AddScoped<TContextInterface>(provider => provider.GetService<TContext>());

            services.AddAutoMapper(typeof(Paged<>));

            return services;
        }
    }
}
