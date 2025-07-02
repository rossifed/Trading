using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    internal interface IEmsxSessionFactory {
        EmsxSession CreateSession();
        EmsxSession CreateSession(IEmsxEventHandler emsxEventHandler);
    }
    internal class EmsxSessionFactory : IEmsxSessionFactory
    {
        private EmsxSessionOptions EmsxSessionOptions { get; }
        public EmsxSessionFactory(EmsxSessionOptions options)
        {
            EmsxSessionOptions = options;
        }
        public EmsxSession CreateSession(IEmsxEventHandler emsxEventHandler)
        {
            return EmsxClient.Connect(EmsxSessionOptions, emsxEventHandler);
        }
        public EmsxSession CreateSession() {
          return  EmsxClient.Connect(EmsxSessionOptions);
        }
    }
}
