using Cache.Configuration;
using Cache.Interfaces;
using Cache.Services;


var config = new ConfigSettings
{
    GarnetConnection = "127.0.0.1:3278",
    CacheType = "Garnet"
};

ICacheInterface cacheService = null;

if (config.CacheType == "Garnet")
{
    cacheService = new GarnetCacheService(config);
}
else
{
    throw new NotSupportedException($"Cache type '{config.CacheType}' is not supported.");
}

string origValue = "abcdefg";
cacheService.Set("test", origValue);
string retValue = cacheService.Get("test");
Console.WriteLine(retValue);