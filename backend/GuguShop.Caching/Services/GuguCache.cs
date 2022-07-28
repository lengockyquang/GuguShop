using GuguShop.Caching.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuguShop.Caching.Services
{
    public class GuguCache : IGuguCache
    {
        private readonly IConnectionMultiplexer _redis;
        public GuguCache(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public string GetStatus()
        {
            var info = _redis.GetStatus();
            return info;
        }
    }
}
