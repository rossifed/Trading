using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface ICurrencyPairDao
    {
        Task<IEnumerable<CurrencyPair>> GetAllAsync();
        Task<IEnumerable<CurrencyPair>> GetBySymbolsAsync(IEnumerable<string> symbols);
        Task<CurrencyPair> CreateAsync(CurrencyPair entity);

        Task<CurrencyPair> UpdateAsync(CurrencyPair entity);
        Task<IEnumerable<CurrencyPair>> CreateAsync(IEnumerable<CurrencyPair> entities);

        Task<IEnumerable<CurrencyPair>> UpdateAsync(IEnumerable<CurrencyPair> entities);
    }
    internal class CurrencyPairDao : ICurrencyPairDao
    {
        private InstrumentsDbContext DbContext { get; }

        public CurrencyPairDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     
        public async Task<IEnumerable<CurrencyPair>>  CreateAsync(IEnumerable<CurrencyPair> entities)
        {

            if (entities.Any())
                await DbContext.AddRangeAsync(entities);

             await DbContext.SaveChangesAsync();
            return entities;

        }
        public async Task<IEnumerable<CurrencyPair>> UpdateAsync(IEnumerable<CurrencyPair> entities)
        {
        
            if(entities.Any())
                DbContext.UpdateRange(entities);

            await DbContext.SaveChangesAsync();
            return entities;

        }
        public async Task<CurrencyPair> CreateAsync(CurrencyPair entity)
        {

                await DbContext.AddAsync(entity);
       
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<CurrencyPair> UpdateAsync(CurrencyPair entity)
        {
     
                DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<CurrencyPair>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            return await DbContext.CurrencyPairs
                          .AsNoTracking()
                          .Where(x => symbols.Contains(x.CurrencyPairNavigation.Symbol))
                          .Include(x => x.BaseCurrency)
                           .Include(x => x.QuoteCurrency)
                          .Include(x => x.CurrencyPairNavigation)
                          .ThenInclude(x => x.Currency)
                          .Include(x => x.CurrencyPairNavigation)
                          .ThenInclude(x => x.InstrumentType)
                           .Include(x => x.CurrencyPairNavigation)
                          .ThenInclude(x => x.Exchange)
                           .Include(x => x.CurrencyPairNavigation)
                          .ThenInclude(x => x.MarketSector)
                          .Distinct()
                          .ToListAsync();
        }

        public async Task<IEnumerable<CurrencyPair>> GetAllAsync()
        {
            return await DbContext.CurrencyPairs
                         .AsNoTracking()
                         .Include(x => x.BaseCurrency)
                          .Include(x => x.QuoteCurrency)
                         .Include(x => x.CurrencyPairNavigation)
                         .ThenInclude(x => x.Currency)
                         .Include(x => x.CurrencyPairNavigation)
                         .ThenInclude(x => x.InstrumentType)
                          .Include(x => x.CurrencyPairNavigation)
                         .ThenInclude(x => x.Exchange)
                          .Include(x => x.CurrencyPairNavigation)
                         .ThenInclude(x => x.MarketSector)
                         .Distinct()
                         .ToListAsync();
        }
    }
}
