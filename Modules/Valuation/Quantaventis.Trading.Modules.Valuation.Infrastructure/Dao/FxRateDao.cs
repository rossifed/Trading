using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface IFxRateDao
    {
        Task<IEnumerable<FxRate>> GetByQuoteCurrencyAsync(string quoteCurrency);
        Task SaveAsync(IEnumerable<FxRate> entities);

        Task<FxRate> GetAsync(string baseCurrency, string quoteCurrency);
    }
    internal class FxRateDao : IFxRateDao
    {
        private ValuationDbContext DbContext { get; }

        public FxRateDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<FxRate> GetAsync(string baseCurrency, string quoteCurrency)
        {
            return await DbContext.FxRates
                              .AsNoTracking()
                              .Where(x => x.BaseCurrency == baseCurrency && x.QuoteCurrency == quoteCurrency)
                              .OrderByDescending(x => x.Date)
                              .FirstAsync();
        }


        public async Task<IEnumerable<FxRate>> GetByQuoteCurrencyAsync(string quoteCurrency)
        {
            return await DbContext.FxRates
                              .AsNoTracking()
                              .Where(x =>  x.QuoteCurrency == quoteCurrency)
                              .ToListAsync();
        }
 

        public async Task SaveAsync(IEnumerable<FxRate> entities)
        {
            await DbContext.BulkInsertOrUpdateAsync<FxRate>(entities);
        }
    }
}
