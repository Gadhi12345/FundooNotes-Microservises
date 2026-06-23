using System.Text.Json;
using NotesService.Application.Interfaces;
using StackExchange.Redis;

namespace NotesService.Infrastructure.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _redis;

        public RedisCacheService(
            IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value =
                await _redis.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return default;

            return JsonSerializer
    .Deserialize<T>(value.ToString());
        }

        public async Task SetAsync<T>(
            string key,
            T value,
            TimeSpan expiry)
        {
            var json =
                JsonSerializer.Serialize(value);

            await _redis.StringSetAsync(
                key,
                json,
                expiry);
        }

        public async Task RemoveAsync(string key)
        {
            await _redis.KeyDeleteAsync(key);
        }
    }
}