using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    internal interface IEmsxSessionSettings
    {
       public string Service { get;  }

        public string Host { get;}

        public int Port { get;  }
    }
}
