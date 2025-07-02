using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal interface IDBIntegrationService<T>
    {

        Task IntegrateDataBatchAsync(IEnumerable<T> data);
    }
}
