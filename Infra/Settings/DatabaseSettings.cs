using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public int Timeout { get; set; }
    }
}
