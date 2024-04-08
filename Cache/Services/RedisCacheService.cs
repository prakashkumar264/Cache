using Cache.Configuration;
using Cache.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Cache.Services
{
    public class RedisCacheService : ICacheInterface
    {
        private readonly ConnectionMultiplexer _redisClient;

        public RedisCacheService(ConfigSettings config)
        {
            var connectionParts = config.Connection.Split(':');
            if (connectionParts.Length != 2 || !int.TryParse(connectionParts[1], out int port))
            {
                throw new ArgumentException("Invalid Garnet connection string format.");
            }
            
            _redisClient = ConnectionMultiplexer.Connect($"{connectionParts[0]}:{port}");
        }

        public string Get(string key)
        {
            return _redisClient.GetDatabase().StringGet(key);   
        }

        public void Set(string key, string value)
        {
            _redisClient.GetDatabase().StringSet(key, value);
        }

        public void Delete(string key)
        {
           // _redisClient.KeyDeleteAsync(key).Wait();
        }
    }
}
