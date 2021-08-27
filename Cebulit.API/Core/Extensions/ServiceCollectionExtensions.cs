using Cebulit.API.Repositories;
using Cebulit.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cebulit.API.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPcPartsRepository, PcPartsRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserBuildsRepository, UserBuildsRepository>();
            services.AddTransient<IBuildsRepository, BuildsRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBuildsProvider, BuildsProvider>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPriceUpdater, InflationGeneratorPriceUpdater>();
        }

        public static void AddScheduledTasks(this IServiceCollection services)
        {
            services.AddSingleton<BuildsPriceUpdateScheduler>();
        }
    }
}