using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal class StgRefDataUpdateService : IDBIntegrationService<StgRefDatum>
    {
        private IStgRefDataDao StgRefDataDao { get; }

        public StgRefDataUpdateService(IStgRefDataDao stgRefDataDao)
        {
            StgRefDataDao = stgRefDataDao;
        }

        public async Task IntegrateDataBatchAsync(IEnumerable<StgRefDatum> data)
        {
           await StgRefDataDao.UpdateDataBatch(data);
        }
    }
}
