using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal interface IDBIntegrationService<T>
    {

        Task IntegrateDataBatchAsync(IEnumerable<T> data);
    }
}
