using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IOrderDao
    {


        Task<IEnumerable<int>> ReplaceAsync(IEnumerable<Order> Orders);
        Task<IEnumerable<int>> CreateAsync(IEnumerable<Order> Orders);
        Task<IEnumerable<Order>> GetByLastRebalancingAsync();
        Task<IEnumerable<Order>> GetByRebalancingIdAsync(int reblancingId);
        Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<int> ids);
    }

    internal class OrderDao : IOrderDao
    {
        private OrdersDbContext DbContext { get; }

        public OrderDao(OrdersDbContext dbContext) {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<Order>> GetByLastRebalancingAsync()
        {
            var maxRebalancingId = await DbContext.Orders.AsNoTracking()
                .Include(x => x.Instrument)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.TradingAccount)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.Portfolio)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.PositionSide)
                 .Include(x => x.TradeMode)
                 .Include(x => x.HandlingInstruction)
                 .Include(x => x.ExecutionChannel)
                 .Include(x => x.ExecutionAlgorithm)

                 .Include(x => x.OrderType)
                 .Include(x => x.OrderSide)
                 .Include(x => x.TimeInForce)
                 .Include(x => x.TradingDesk)
                 .Include(x => x.Broker)
                .Select(x => (int?)x.RebalancingSessionId)
                 
                .DefaultIfEmpty()
                .MaxAsync();


            if (maxRebalancingId != null)
            return await GetByRebalancingIdAsync(maxRebalancingId.Value);
            return Enumerable.Empty<Order>();
        }
        public async Task<IEnumerable<Order>> GetByRebalancingIdAsync(int reblancingId)
        {

            return await DbContext.Orders
                 .AsNoTracking()
                 .Where(x => x.RebalancingSessionId == reblancingId )
              .Include(x => x.Instrument)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.TradingAccount)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.Portfolio)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.PositionSide)
                 .Include(x => x.TradeMode)
                 .Include(x => x.HandlingInstruction)
                 .Include(x => x.ExecutionChannel)
                 .Include(x => x.ExecutionAlgorithm)
                 .Include(x => x.OrderType)
                 .Include(x => x.OrderSide)
                 .Include(x => x.TimeInForce)
                 .Include(x => x.TradingDesk)
                 .Include(x => x.Broker)
                 .ToListAsync();
        }

        public async Task<IEnumerable<int>> ReplaceAsync(IEnumerable<Order> orders)
        {
 
             DbContext.Orders.RemoveRange(DbContext.Orders);        

            return await CreateAsync(orders);
        }
        public async Task<IEnumerable<int>> CreateAsync(IEnumerable<Order> orders)
        {

            var entities = orders.ToArray();
                await DbContext.AddRangeAsync(entities);


            await DbContext.SaveChangesAsync();

            return entities.Select(x=>x.OrderId);
        }

        public async Task<IEnumerable<Order>> GetByIdsAsync(IEnumerable<int> ids)
        {

            return await DbContext.Orders
                 .AsNoTracking()
                 .Where(x => ids.Contains(x.OrderId))
                . Include(x => x.Instrument)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.TradingAccount)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.Portfolio)
                 .Include(x => x.OrderAllocations)
                 .ThenInclude(x => x.PositionSide)
                 .Include(x => x.TradeMode)
                 .Include(x => x.HandlingInstruction)
                 .Include(x => x.ExecutionChannel)
                 .Include(x => x.ExecutionAlgorithm)
           
                 .Include(x => x.OrderType)
                 .Include(x => x.OrderSide)
                 .Include(x => x.TimeInForce)
                 .Include(x => x.TradingDesk)
                 .Include(x => x.Broker)
                 .ToListAsync();
        }
    }

}
