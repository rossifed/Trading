using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao
{
    internal interface IBookedTradeAllocationDao
    {
        Task DeleteByTradeIdAsync(int tradeId);
        Task UpsertRangeAsync(IEnumerable<BookedTradeAllocation> entities);
    }
    internal class BookedTradeAllocationDao : IBookedTradeAllocationDao
    {
        private PortfoliosDbContext DbContext { get; }

        public BookedTradeAllocationDao(PortfoliosDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
  

 

        public async Task UpsertRangeAsync(IEnumerable<BookedTradeAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => x.TradeAllocationId)
                .RunAsync();
        }

        public async Task DeleteByTradeIdAsync(int tradeId)
        {
            IEnumerable<BookedTradeAllocation> entities = await DbContext.BookedTradeAllocations.Where(x => x.TradeId == tradeId).ToListAsync();

            if (entities.Any())
            {
                DbContext.RemoveRange(entities);
                await DbContext.SaveChangesAsync();
            }
            
        }
    }
}
