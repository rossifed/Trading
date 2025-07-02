using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Options
{
    internal class EmsxApiOptions
    {
        public string HistoryServiceName { get; set; }
        public string ServiceName { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string TeamName { get; set; }
        public int OpenSessionTimeout { get; set; }
    }
}
