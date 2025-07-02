using Quantaventis.Trading.Modules.Execution.Domain.Model;
using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Repositories
{

    internal class EmsxOrderExecutionRepository : IEmsxOrderExecutionRepository
    {
        private IEmsxFillDao EmsxFillDao { get; }
        private IEmsxOrderDao EmsxOrderDao { get; }

        public EmsxOrderExecutionRepository(IEmsxFillDao emsxFillDao, IEmsxOrderDao emsxOrderDao)
        {
            EmsxFillDao = emsxFillDao;
            EmsxOrderDao = emsxOrderDao;
        }

        public async Task<EmsxTrade?> GetByEmsxOrderIdAsync(int orderId)
        {
            IEnumerable<Entities.EmsxFill> emsxFillEntities = await EmsxFillDao.GetByEmsxOrderIdAsync(orderId);
            Entities.EmsxOrder? emsxOrderEntity = await EmsxOrderDao.GetByEmsxOrderIdAsync(orderId);

            IEnumerable<EmsxFill> emsxFills = emsxFillEntities.Map();
            EmsxOrder? emsxOrder = emsxOrderEntity?.Map();
            return new EmsxTrade(emsxOrder, emsxFills);
        }
    }
}
