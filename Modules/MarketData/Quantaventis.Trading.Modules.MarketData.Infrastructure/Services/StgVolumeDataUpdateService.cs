using Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal class StgVolumeDataUpdateService : IDBIntegrationService<StgVolumeDatum>
    {
        private IStgVolumeDataDao StgVolumeDataDao { get; }

        public StgVolumeDataUpdateService(IStgVolumeDataDao stgVolumeDataDao)
        {
            StgVolumeDataDao = stgVolumeDataDao;
        }

        public async Task IntegrateDataBatchAsync(IEnumerable<StgVolumeDatum> data)
        {
           await StgVolumeDataDao.UpdateDataBatch(data);
        }
    }
}
