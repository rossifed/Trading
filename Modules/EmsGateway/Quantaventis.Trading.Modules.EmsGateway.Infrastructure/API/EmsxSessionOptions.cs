using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class EmsxSessionOptions
    {
        public string Service { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public int ResponseTimeOut { get; set; }
        public EmsxSessionOptions() { 
        
        }
        public EmsxSessionOptions(string service, string host, int port, int responseTimeOut = 0)
        {
            Service = service;
            Host = host;
            Port = port;
            ResponseTimeOut = responseTimeOut;
        }
    
            
    }
}
