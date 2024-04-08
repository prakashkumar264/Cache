using Cache.Configuration;
using Cache.Interfaces;
using Cache.Services;


var config = new ConfigSettings
{
    Connection = "127.0.0.1:6379",
    CacheType = "Redis"
};

ICacheInterface cacheService = null;


if (config.CacheType == "Garnet")
{
    cacheService = new GarnetCacheService(config);
}
if (config.CacheType == "Redis")
{
    cacheService = new RedisCacheService(config);
}

else
{
    throw new NotSupportedException($"Cache type '{config.CacheType}' is not supported.");
}

string origValue = "abcdefg";
cacheService.Set("test", origValue);
string retValue = cacheService.Get("test");
Console.WriteLine(retValue);