using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuguShop.Caching.Models
{
    public class GuguCacheConfiguration
    {
        public string RedisConnectionString { get; set; }
        public bool IsEnable { get; set; }
    }
}
