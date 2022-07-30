using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuguShop.Caching.Interfaces
{
    public interface IGuguCache
    {
        string GetStatus();
        Task<bool> HealthCheck();
        Task AddAsync(string key, object value);
        Task<T> GetAsync<T>(string key) where T: class;
        Task RemoveAsync(string key);

    }
}
