using Quantaventis.Trading.Modules.Execution.Domain.Model;
using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Repositories
{

    internal class EmsxOrderRepository : IEmsxOrderRepository
    {

        private IEmsxOrderDao EmsxOrderDao { get; }

        public EmsxOrderRepository(IEmsxOrderDao emsxOrderDao)
        {

            EmsxOrderDao = emsxOrderDao;
        }



        public async Task<EmsxOrder?> GetByOrderIdAsync(int orderId)
        {
            Entities.EmsxOrder? emsxOrderEntity = await EmsxOrderDao.GetByEmsxOrderIdAsync(orderId);
            return emsxOrderEntity?.Map();
        }

        public async Task UpdateAsync(EmsxOrder emsxOrder)
        {
            await EmsxOrderDao.UpdateAsync(emsxOrder.Map());
        }

        public async Task UpsertAsync(IEnumerable<EmsxOrder> emsxOrders)
        {
            await EmsxOrderDao.UpsertAsync(emsxOrders.Map());
        }

        public async Task<EmsxOrder> AddAsync(EmsxOrder emsxOrder)
        {
            var entity = await EmsxOrderDao.CreateAsync(emsxOrder.Map());
            return entity.Map();
        }
    }
}
