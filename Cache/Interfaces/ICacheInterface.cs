using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Interfaces
{
    public interface ICacheInterface
    {
        string Get(string key);
        void Set(string key, string value);
        void Delete(string key);
    }
}
