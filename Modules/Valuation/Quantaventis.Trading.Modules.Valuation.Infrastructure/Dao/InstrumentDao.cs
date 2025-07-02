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
    internal interface IInstrumentDao
    {
        Task CreateAsync(Instrument entity);
        Task SaveAsync(IEnumerable<Instrument> instruments);
        Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds);
    }
    internal class InstrumentDao : IInstrumentDao
    {
        private ValuationDbContext DbContext { get; }

        public InstrumentDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => instrumentIds.Contains(x.InstrumentId))
                              .Include(x => x.FutureContract) 
                              .Include(x => x.InstrumentPricing)                         
                              .Distinct()
                              .ToListAsync();
        }

        public async Task SaveAsync(IEnumerable<Instrument> entities)
        {
           await DbContext.BulkInsertOrUpdateAsync<Instrument>(entities);
        }

        public async Task CreateAsync(Instrument entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
