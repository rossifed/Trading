using Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal class StgMarketDataUpdateService : IDBIntegrationService<StgMarketDatum>
    {
        private IStgMarketDataDao StgMarketDataDao { get; }

        public StgMarketDataUpdateService(IStgMarketDataDao stgMarketDataDao)
        {
            StgMarketDataDao = stgMarketDataDao;
        }

        public async Task IntegrateDataBatchAsync(IEnumerable<StgMarketDatum> data)
        {
           await StgMarketDataDao.UpdateDataBatch(data);
        }
    }
}
