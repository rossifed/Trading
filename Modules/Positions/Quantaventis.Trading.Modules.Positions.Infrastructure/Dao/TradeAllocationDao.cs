using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Dao
{
    internal interface ITradeAllocationDao
    {
        Task<IEnumerable<TradeAllocation>> GetAllByPortfolioIdFromDateAsync(byte portfolioId, DateOnly fromDate);



        Task<IEnumerable<TradeAllocation>> GetFromDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly fromTradeDate);
        
            Task<IEnumerable<TradeAllocation>> GetFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap);
        Task<IEnumerable<TradeAllocation>> GetByTradeIdAsync(int tradeid);
        Task<IEnumerable<TradeAllocation>> GetAfterDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly tradeDate);
        Task RemoveAsync(int tradeAllocationId);

        Task UpsertAsync(TradeAllocation tradeAllocation);
        Task UpsertRangeAsync(IEnumerable<TradeAllocation> tradeAllocations);
    }
    internal class TradeAllocationDao : ITradeAllocationDao
    {
        private PositionsDbContext DbContext { get; }

        public TradeAllocationDao(PositionsDbContext dbContext) { DbContext = dbContext; }

        public async Task<IEnumerable<TradeAllocation>> GetFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap)
        {
            return await DbContext.TradeAllocations
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == instrumentId && x.IsSwap == isSwap)
                .ToListAsync();
        }

        public async Task<IEnumerable<TradeAllocation>> GetByTradeIdAsync(int tradeid)
        {
            return await DbContext.TradeAllocations
             .AsNoTracking()
             .Where(x => x.TradeId == tradeid)
             .ToListAsync();
        }

        public async Task<IEnumerable<TradeAllocation>> GetAfterDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly tradeDate)
        {
            DateTime afterDateTime = tradeDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext.TradeAllocations
            .AsNoTracking()
            .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == instrumentId && x.IsSwap == isSwap && x.TradeDate > afterDateTime)
            .ToListAsync();
        }

        public async Task RemoveAsync(int tradeAllocationId)
        {
            TradeAllocation? entity = await DbContext.TradeAllocations
            .AsNoTracking().Where(x => x.TradeAllocationId == tradeAllocationId)
            .FirstOrDefaultAsync();

            if (entity != null)
            {
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
            }

        }

        public async Task UpsertAsync(TradeAllocation entity)
        {
            await DbContext
               .Upsert(entity)
               .On(x => new { x.TradeAllocationId })
               .RunAsync();
        }

        public async Task UpsertRangeAsync(IEnumerable<TradeAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => new { x.TradeAllocationId })
                .RunAsync();
        }

        public async Task<IEnumerable<TradeAllocation>> GetAllByPortfolioIdFromDateAsync(byte portfolioId, DateOnly fromDate)
        {
            DateTime fromDateTime = fromDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext.TradeAllocations
            .AsNoTracking()
            .Where(x => x.PortfolioId == portfolioId
       
            && x.TradeDate >= fromDateTime)
            .ToListAsync();
        }

        public async Task<IEnumerable<TradeAllocation>> GetFromDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly fromDate)
        {
            DateTime fromDateTime = fromDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext.TradeAllocations
            .AsNoTracking()
            .Where(x => x.PortfolioId == portfolioId 
            && x.InstrumentId == instrumentId 
            && x.IsSwap == isSwap 
            && x.TradeDate >= fromDateTime)
            .ToListAsync();
        }
    }
}
