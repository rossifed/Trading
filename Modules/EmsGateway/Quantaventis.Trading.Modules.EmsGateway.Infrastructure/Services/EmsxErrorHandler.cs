using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services
{
    internal class EmsxErrorHandler : IEmsxErrorHandler


    { ILogger<EmsxErrorHandler> Logger { get; }

        public EmsxErrorHandler(ILogger<EmsxErrorHandler> logger)
        {
            Logger = logger;
        }

        public void OnError(int errorCode, string errorMessage)
        {
            Logger.LogError(errorCode, errorMessage);
            throw new InvalidOperationException(errorMessage);
        }

        public void OnError(string errorMessage)
        {
            Logger.LogError(errorMessage);
            throw new InvalidOperationException(errorMessage);
        }
    }
}
