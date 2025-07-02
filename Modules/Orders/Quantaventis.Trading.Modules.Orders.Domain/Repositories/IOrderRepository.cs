using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Repositories
{
    internal interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetByLastRebalancingAsync();
        Task<IEnumerable<Order>> GetByRebalancingSessionId(int rebalancingSessionId);
        Task<IEnumerable<Order>> AddAsync(IEnumerable<Order> orders);
        Task<IEnumerable<Order>> ReplaceAsync(IEnumerable<Order> orders);
    }
}
