using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Options
{
    public class EMSXSessionConfig : IEmsxSessionSettings
    {
        public string Service { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
       
    }


}
