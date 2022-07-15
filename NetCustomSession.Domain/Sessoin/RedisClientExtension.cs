
namespace NetCustomSession.Domain.Sessoin
{
    using System.Threading.Tasks;
    using FreeRedis;

    internal static class RedisClientExtension
    {
        private const string HmGetScript = (@"return redis.call('HMGET', KEYS[1], unpack(ARGV))");

        internal static object[] HashMemberGet(this RedisClient cli, string key, params string[] members)
        {
            var result = cli.Eval(
                HmGetScript,
                new [] { key },
                GetRedisMembers(members));

            // TODO: Error checking?
            return (object[])result;
        }

        internal static async Task<object[]> HashMemberGetAsync(
            this RedisClient cli,
            string key,
            params string[] members)
        {
            return await Task.Run(() => HashMemberGet(cli, key, members));
        }

        private static object[] GetRedisMembers(params string[] members)
        {
            var redisMembers = new object[members.Length];
            for (int i = 0; i < members.Length; i++)
            {
                redisMembers[i] = members[i];
            }

            return redisMembers;
        }
    }
}
