using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IFxForwardDao
    {
        Task<IEnumerable<FxForward>> GetByCurrencyPairIdAsync(int CurrencyPairId);
        Task<FxForward> CreateAsync(FxForward entity);
        Task<IEnumerable<FxForward>> CreateAsync(IEnumerable<FxForward> entities);
        Task<IEnumerable<FxForward>> UpdateAsync(IEnumerable<FxForward> entities);
    }
    internal class FxForwardDao : IFxForwardDao
    {
        private InstrumentsDbContext DbContext { get; }

        public FxForwardDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     
        public async Task<IEnumerable<FxForward>>  CreateAsync(IEnumerable<FxForward> entities)
        {

            if (entities.Any())
                await DbContext.AddRangeAsync(entities);


             await DbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<FxForward>> UpdateAsync(IEnumerable<FxForward> entities)
        {
 
            if (entities.Any())
                DbContext.UpdateRange(entities);

            await DbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<FxForward> CreateAsync(FxForward entity)
        {
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<FxForward>> GetByCurrencyPairIdAsync(int currencyPairId)
        {
            return await DbContext
         .FxForwards
         .Where(x => x.CurrencyPairId == currencyPairId)
          .Include(x => x.FxForwardNavigation)
          .ThenInclude(x => x.Currency)
          .Include(x => x.FxForwardNavigation)
          .ThenInclude(x => x.InstrumentType)
          .Include(x => x.FxForwardNavigation)
          .ThenInclude(x => x.Exchange)
          .Include(x => x.FxForwardNavigation)
          .ThenInclude(x => x.MarketSector)
          .Include(x=>x.CurrencyPair)
          .ThenInclude(x=>x.BaseCurrency)
           .Include(x => x.CurrencyPair)
          .ThenInclude(x => x.QuoteCurrency)
          .ToListAsync();
        }
    }
}
