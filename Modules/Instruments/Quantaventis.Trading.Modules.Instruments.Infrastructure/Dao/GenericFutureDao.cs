using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IGenericFutureDao
    {
        Task<IEnumerable<GenericFuture>> GetAllAsync();
        Task<IEnumerable<GenericFuture>> GetBySymbolsAsync(IEnumerable<string> symbols);

        Task<GenericFuture> GetBySymbolAsync(string symbol);
        Task<IEnumerable<GenericFuture>> CreateAsync(IEnumerable<GenericFuture> entities);
        Task<GenericFuture> CreateAsync(GenericFuture entity);
        Task<GenericFuture> UpdateAsync(GenericFuture entity);

        Task<IEnumerable<GenericFuture>> UpdateAsync(IEnumerable<GenericFuture> entities);
    }
    internal class GenericFutureDao : IGenericFutureDao
    {
        private InstrumentsDbContext DbContext { get; }

        public GenericFutureDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<GenericFuture>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {

            //if(symbols.IsNullOrEmpty() || DbContext.GenericFutures.IsNullOrEmpty())
            //    return new List<GenericFuture>();
            return await DbContext.GenericFutures
                              .AsNoTracking()
                            .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.Currency)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.Exchange)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.MarketSector)
                   .Where(x => symbols.Contains(x.GenericFutureNavigation.Symbol))
                              .ToListAsync();
        }
        public async Task<GenericFuture> CreateAsync(GenericFuture entity)
        {

            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<GenericFuture> UpdateAsync(GenericFuture entity)
        {

            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<GenericFuture>> UpdateAsync(IEnumerable<GenericFuture> entities)
        {
            DbContext.UpdateRange(entities);

            await DbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<GenericFuture>> GetAllAsync()
        {
            return await DbContext.GenericFutures
                            .AsNoTracking()
                             .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.Currency)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.Exchange)
                 .Include(x => x.GenericFutureNavigation)
                 .ThenInclude(x => x.MarketSector)
                  .Include(x => x.FutureContracts)
                            .ToListAsync();
        }

        public async Task<IEnumerable<GenericFuture>> CreateAsync(IEnumerable<GenericFuture> entities)
        {

            await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<GenericFuture?> GetBySymbolAsync(string symbol)
        {
            return await DbContext.GenericFutures
                              .AsNoTracking()
                              .Where(x=>x.GenericFutureNavigation.Symbol== symbol)
                               .Include(x => x.GenericFutureNavigation)
                   .ThenInclude(x => x.Currency)
                   .Include(x => x.GenericFutureNavigation)
                   .ThenInclude(x => x.InstrumentType)
                   .Include(x => x.GenericFutureNavigation)
                   .ThenInclude(x => x.Exchange)
                   .Include(x => x.GenericFutureNavigation)
                   .ThenInclude(x => x.MarketSector)
                    .Include(x => x.FutureContracts)
                              .FirstOrDefaultAsync();
        }

      
    }
}
