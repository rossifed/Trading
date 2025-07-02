using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao
{
    internal interface ITradeAllocationDao
    {
        Task<IEnumerable<TradeAllocation>> GetByPortfolioIdAsync(byte portfolioId);

        Task UpsertAsync(IEnumerable<TradeAllocation> entities);
    }
    internal class TradeAllocationDao : ITradeAllocationDao
    {
        private PortfoliosDbContext DbContext { get; }

        public TradeAllocationDao(PortfoliosDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<TradeAllocation>> GetByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.TradeAllocations
                .Where(x=>x.PortfolioId == portfolioId)
                   .AsNoTracking()
                   .Include(x=>x.Instrument)
                   .Include(x=>x.Portfolio)
                   .ToListAsync();
        }

        public async Task UpdateAsync(Position entity)
        {
            DbContext.Update(entity);
           await DbContext.SaveChangesAsync();
        }

        public async Task<Position> CreateAsync(Position entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpsertAsync(IEnumerable<TradeAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => x.TradeAllocationId)
                .WhenMatched(x => new TradeAllocation()
                {
                    NetAmount = x.NetAmount,
                    Commission = x.Commission,
                    Fees = x.Fees,
                    GrossAmount = x.GrossAmount,                   
                    Quantity = x.Quantity,
                    InstrumentId = x.InstrumentId,
                    LastTradeDate = x.LastTradeDate,
                    TradeCurrency = x.TradeCurrency,
                    TradePrice = x.TradePrice,
                    PortfolioId = x.PortfolioId
                })
                .RunAsync();
        }
    }
}
