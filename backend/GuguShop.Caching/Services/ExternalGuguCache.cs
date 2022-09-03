using GuguShop.Caching.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace GuguShop.Caching.Services
{
    public class ExternalGuguCache : IGuguCache
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public ExternalGuguCache(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = redis.GetDatabase();
        }

        public string GetStatus()
        {
            return _redis.GetStatus();
        }
        
        public async Task<bool> HealthCheck()
        {
            var pingResult = await _database.PingAsync();
            return true;
        }

        public async Task AddAsync(string key, object value)
        {
            var valueAsString = JsonSerializer.Serialize(value);
            await _database.SetAddAsync(key, new RedisValue(valueAsString));
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            var redisValue = await _database.StringGetAsync(key);
            return redisValue.HasValue ? JsonSerializer.Deserialize<T>(redisValue) : null;
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
