using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        private IOrderDao OrderDao { get; }
        private IOrderAllocationDao OrderAllocationDao { get; }
        private IUnitOfWork UnitOfWork { get; }

        public OrderRepository(IOrderDao orderDao,
            IOrderAllocationDao orderAllocationDao,
            IUnitOfWork unitOfWork)
        {
            OrderDao = orderDao;
            OrderAllocationDao = orderAllocationDao;
            UnitOfWork = unitOfWork;
        }

        public async Task<Order?> GetByOrderIdAsync(int orderId)
        {
            Entities.Order? entity = await OrderDao.GetByOrderId(orderId);
            return entity?.Map();
        }

        public async Task UpsertRangeAsync(IEnumerable<Order> orders)
        {
            var entities = orders.Map();
            foreach (var entity in entities)
            {
                await UnitOfWork.ExecuteAsync(async () =>
                {

                    await OrderDao.UpsertAsync(entity);
                    await OrderAllocationDao.UpsertRangeAsync(entity.OrderAllocations);

                });
            }
        }

        public async Task<IEnumerable<Order>> GetByInstrumentAndTradeDateAsync(int instrumentId, DateOnly tradeDate)
        {
            IEnumerable<Entities.Order> entities = await OrderDao.GetByInstrumentAndTradeDateAsync(instrumentId, tradeDate);
            return entities.Map();
        }
    }
}
