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
    internal interface IOrderAllocationDao
    {
 


        Task<IEnumerable<OrderAllocation>> GetByOrderIdAsync(int orderId);

    }

    internal class OrderAllocationDao : IOrderAllocationDao
    {
        private OrdersDbContext DbContext { get; }

        public OrderAllocationDao(OrdersDbContext dbContext) {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<OrderAllocation>> GetByOrderIdAsync(int orderId)
        {

            return await DbContext.OrderAllocations
                 .AsNoTracking()
                 .Where(x => x.OrderId == orderId)
                 .Include(x => x.Portfolio)
                 .Include(x=>x.TradingAccount)
                   
                 .Include(x => x.PositionSide)
                 .ToListAsync();
        }




    }

}
