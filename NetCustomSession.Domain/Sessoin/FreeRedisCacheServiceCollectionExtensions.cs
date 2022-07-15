
namespace NetCustomSession.Domain.Sessoin
{
    using System;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.DependencyInjection;

    public static class FreeRedisCacheServiceCollectionExtensions
    {
        public static IServiceCollection AddFreeRedisCache(this IServiceCollection services, Action<FreeRedisCacheOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddOptions();
            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IDistributedCache, FreeRedisCache>());

            return services;
        }
    }
}
