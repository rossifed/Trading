using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class OrderAllocationRepository : IOrderAllocationRepository
    {
        private IOrderAllocationDao OrderAllocationDao { get; }

        public OrderAllocationRepository(IOrderAllocationDao orderAllocationDao)
        {
            this.OrderAllocationDao = orderAllocationDao;
        }
        public async Task<IEnumerable<OrderAllocation>> GetByOrderIdAsync(int orderId)
        {
            IEnumerable<Entities.OrderAllocation> entities = await OrderAllocationDao.GetByOrderId(orderId);
            return entities.Map();
        }
    }
}
