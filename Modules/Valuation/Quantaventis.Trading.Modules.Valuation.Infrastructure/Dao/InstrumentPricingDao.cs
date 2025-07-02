using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using EFCore.BulkExtensions;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface IInstrumentPricingDao
    {

        Task SaveAsync(IEnumerable<InstrumentPricing> entities);
        Task<IEnumerable<InstrumentPricing>> GetByInstrumentIdsAsync(IEnumerable<int> instrumentIds);
        Task<InstrumentPricing> GetByInstrumentIdAsync(int instrumentId);
    }
    internal class InstrumentPricingDao : IInstrumentPricingDao
    {
        private ValuationDbContext DbContext { get; }

        public InstrumentPricingDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<InstrumentPricing> GetByInstrumentIdAsync(int instrumentId)
        {
            return await DbContext.InstrumentPricings
                              .AsNoTracking()
                              .Where(x => x.InstrumentId == instrumentId)
                              .FirstAsync();
        }

        public async Task SaveAsync(IEnumerable<InstrumentPricing> entities)
        {
            await DbContext.BulkInsertOrUpdateAsync<InstrumentPricing>(entities);
        }

        public async Task<IEnumerable<InstrumentPricing>> GetByInstrumentIdsAsync(IEnumerable<int> instrumentIds)
        {
         return   await DbContext.InstrumentPricings.AsNoTracking().Where(x => instrumentIds.Contains(x.InstrumentId))
                .ToListAsync();
        }
    }
}
