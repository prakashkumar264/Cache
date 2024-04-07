using Cache.Configuration;
using Cache.Interfaces;
using Garnet.client;

namespace Cache.Services
{
    public class GarnetCacheService : ICacheInterface
    {
        private readonly GarnetClient _garnetClient;

        public GarnetCacheService(ConfigSettings config)
        {
            var connectionParts = config.GarnetConnection.Split(':');
            if (connectionParts.Length != 2 || !int.TryParse(connectionParts[1], out int port))
            {
                throw new ArgumentException("Invalid Garnet connection string format.");
            }
            _garnetClient = new GarnetClient(address: connectionParts[0], port: port);
            _garnetClient.ConnectAsync();
        }

        public string Get(string key)
        {
            return _garnetClient.StringGetAsync(key).Result;
        }

        public void Set(string key, string value)
        {
            _garnetClient.StringSetAsync(key, value).Wait();
        }

        public void Delete(string key)
        {
            _garnetClient.KeyDeleteAsync(key).Wait();
        }
    }
}
