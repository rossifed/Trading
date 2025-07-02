using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;
using System.Collections;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {

       private IOrderDao OrderDao { get; }

        public OrderRepository(IOrderDao orderDao)
        {
            OrderDao = orderDao;
        }

        public async Task<IEnumerable<Order>> AddAsync(IEnumerable<Order> orders)
        {
          
         var ids =   await OrderDao.CreateAsync(orders.Map());
            IEnumerable<Entities.Order> entities = await OrderDao.GetByIdsAsync(ids);
            return entities.Map();  
        }

        public async Task<IEnumerable<Order>> GetByRebalancingSessionId(int rebalancingSessionId)
        {
            IEnumerable<Entities.Order> entities = await OrderDao.GetByRebalancingIdAsync(rebalancingSessionId);
            return entities.Map();
        }


        public async Task<IEnumerable<Order>> GetByLastRebalancingAsync()
        {
            IEnumerable<Entities.Order> entities = await OrderDao.GetByLastRebalancingAsync();
            return entities.Map();
        }

        public async Task<IEnumerable<Order>> ReplaceAsync(IEnumerable<Order> orders)
        {
            var ids = await OrderDao.ReplaceAsync(orders.Map());
            IEnumerable<Entities.Order> entities = await OrderDao.GetByIdsAsync(ids);
            return entities.Map();
        }
    }
}
