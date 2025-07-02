using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Dao
{
    internal interface IPositionDao
    {
        Task<IEnumerable<Position>> GetByPortfolioIdAsOfAsync(byte portfolioId, DateOnly asOfDate);

        Task<DateOnly?> GetMaxPositionDateAsync(byte portfolioId);
        Task BulkMergeAsync(IEnumerable<Position> entities, int batchSize = 5000);
         Task<IEnumerable<Position>> GetLastByPortfolioIdAsync(byte portfolioId);
        Task<IEnumerable<Position>> GetFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap);
        Task<Position?> GetLastBeforeDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly date);

        Task<IEnumerable<Position>> GetByInstrumentIdAsync(int instrumentId, bool isSwap);
        Task DeleteAfterDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly date);
        Task UpsertAsync(Position position);
        Task UpsertRangeAsync(IEnumerable<Position> position);
    }
    internal class PositionDao : IPositionDao
    {
        private PositionsDbContext DbContext { get; }

        public PositionDao(PositionsDbContext dbContext) { DbContext = dbContext; }

        public async Task<IEnumerable<Position>> GetFromInceptionAsync(byte portfolioId, int instrumentId, bool isSwap)
        {
            return await DbContext
                .Positions
                .AsNoTracking()
                .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == instrumentId && x.IsSwap == isSwap)
                .ToListAsync();
        }

        public async Task<Position?> GetLastBeforeDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly date)
        {
            DateTime beforeDateTime = date.ToDateTime(TimeOnly.MinValue);
            return await DbContext
             .Positions
             .AsNoTracking()
             .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == instrumentId && x.IsSwap == isSwap && x.PositionDate < beforeDateTime)
             .OrderByDescending(x => x.PositionDate)
             .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Position>> GetByInstrumentIdAsync(int instrumentId, bool isSwap)
        {
            return await DbContext
             .Positions
             .AsNoTracking()
             .Where(x => x.InstrumentId == instrumentId && x.IsSwap == isSwap)

             .ToListAsync();
        }



        public async Task UpsertAsync(Position entity)
        {
            await DbContext
                     .Upsert(entity)
                     .On(x => new { x.PortfolioId, x.InstrumentId, x.IsSwap, x.LocalCurrency, x.PositionDate })
                     .RunAsync();
        }

        public async Task UpsertRangeAsync(IEnumerable<Position> entities)
        {
            await DbContext
                  .UpsertRange(entities)
                  .On(x => new { x.PortfolioId, x.InstrumentId, x.IsSwap, x.LocalCurrency,x.PositionDate })
                  .RunAsync();
        }
        public async Task BulkMergeAsync(IEnumerable<Position> entities, int batchSize= 5000)
        {
            int totalRecords = entities.Count();
            int totalBatches = (int)Math.Ceiling((double)totalRecords / batchSize);

            for (int i = 0; i < totalBatches; i++)
            {
                var batch = entities.Skip(i * batchSize).Take(batchSize).ToList();
              
                    await DbContext.BulkInsertOrUpdateOrDeleteAsync(batch, options => options.TemporalColumns = new List<string>() { "ValidFrom", "ValidTo" });
              
               
            }
           // await DbContext.BulkInsertOrUpdateOrDeleteAsync(entities, options => options.TemporalColumns =new List<string>(){ "ValidFrom" , "ValidTo"});
        }
        public async Task DeleteAfterDateAsync(byte portfolioId, int instrumentId, bool isSwap, DateOnly afterDate)
        {
            DateTime afterDateTime = afterDate.ToDateTime(TimeOnly.MinValue);
            var entities = await DbContext
             .Positions
             .AsNoTracking()
             .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == instrumentId && x.IsSwap == isSwap && x.PositionDate > afterDateTime)
             .OrderByDescending(x => x.PositionDate)
             .ToListAsync();

            if (entities.Any())
            {
                DbContext.RemoveRange(entities);

                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Position>> GetByPortfolioIdAsOfAsync(byte portfolioId, DateOnly asOfDate)
        {
            DateTime asOfDateTime = asOfDate.ToDateTime(TimeOnly.MinValue);

            return await DbContext.Positions
                .Where(p => p.PortfolioId == portfolioId && p.PositionDate <= asOfDateTime)
                .GroupBy(p => new { p.InstrumentId, p.IsSwap ,p.LocalCurrency})
                .Select(g => g.OrderByDescending(p => p.PositionDate).First())
                .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.Positions
                .Where(p => p.PortfolioId == portfolioId)
                .GroupBy(p => new { p.InstrumentId, p.IsSwap, p.LocalCurrency })
                .Select(g => g.OrderByDescending(p => p.PositionDate).First())
                .ToListAsync();
        }

        public async Task<DateOnly?> GetMaxPositionDateAsync(byte portfolioId)
        {
            DateTime? maxPositionDate = await DbContext.Positions
               .Where(p => p.PortfolioId == portfolioId)
               .MaxAsync(p => p.PositionDate);

            return maxPositionDate.HasValue ? DateOnly.FromDateTime(maxPositionDate.Value) : null;
        }
    }
}
