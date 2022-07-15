
namespace NetCustomSession.Domain.Sessoin
{
    using FreeRedis;
    using Microsoft.Extensions.Options;

    public class FreeRedisCacheOptions : IOptions<FreeRedisCacheOptions>
    {
        /// <summary>
        /// The configuration used to connect to Redis.
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// The configuration used to connect to Redis.
        /// This is preferred over Configuration.
        /// </summary>
        public RedisClient Cli { get; set; }

        /// <summary>
        /// The Redis instance name.
        /// </summary>
        public string InstanceName { get; set; }

        FreeRedisCacheOptions IOptions<FreeRedisCacheOptions>.Value
        {
            get { return this; }
        }
    }
}
