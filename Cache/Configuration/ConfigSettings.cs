using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.Configuration
{
    public class ConfigSettings
    {
        public string Connection { get; set; }

        //redism
        public string CacheType { get; set; }
    }
}
