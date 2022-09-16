using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.Common.Application.Common.Services;
using Samples.Common.Application.Interfaces;
using Samples.Common.Infrastructure.Interfaces;
using Samples.Data.Mongo.Core.Infrastructure;
using Samples.Data.Mongo.Core.Infrastructure.Interfaces;
using Samples.Data.Mongo.Core.Infrastructure.Repositories;
using Sequoia;
using Sequoia.Attributes;
using Sequoia.Data.Mongo;

namespace Samples.Data.Mongo.Core
{
    [SequoiaMember]
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application services
        /// </summary>
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // register common components
            services.AddSequoia();

            // add mongo db
            services.AddMongoDb<IApplicationDbContext, ApplicationDbContext>(
                configuration.GetConnectionString("MongoConnection"), "cookbook");

            // add application services (from common)
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IRecipeService, RecipeService>();

            // add application repositories (local implementation)
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            return services;
        }
    }
}
