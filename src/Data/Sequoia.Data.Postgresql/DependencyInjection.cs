using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sequoia.Data.Postgresql
{
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

            return services;
        }
    }
}
