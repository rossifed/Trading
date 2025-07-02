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
    internal interface IFutureContractDao
    {
        Task CreateAsync(FutureContract futureContract);
        Task SaveAsync(IEnumerable<FutureContract> futureContracts);
    }
    internal class FutureContractDao : IFutureContractDao
    {
        private ValuationDbContext DbContext { get; }

        public FutureContractDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => instrumentIds.Contains(x.InstrumentId))
                              .Include(x => x.FutureContract)                     
                              .Distinct()
                              .ToListAsync();
        }

        public async Task SaveAsync(IEnumerable<FutureContract> futureContracts)
        {
           await DbContext.BulkInsertOrUpdateAsync(futureContracts);
        }

        public async Task CreateAsync(FutureContract futureContract)
        {
            await DbContext.AddAsync(futureContract);
            await DbContext.SaveChangesAsync();
        }
    }
}
