using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IFutureContractDao
    {
        Task<IEnumerable<FutureContract>> GetByGenericFutureIdAsync(int genericFutureId);
        Task<FutureContract> CreateAsync(FutureContract entity);
        Task<IEnumerable<FutureContract>> CreateAsync(IEnumerable<FutureContract> entities);

        Task<IEnumerable<FutureContract>> UpdateAsync(IEnumerable<FutureContract> entities);
    }
    internal class FutureContractDao : IFutureContractDao
    {
        private InstrumentsDbContext DbContext { get; }

        public FutureContractDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     
        public async Task<IEnumerable<FutureContract>> CreateAsync(IEnumerable<FutureContract> entities)
        {
            await DbContext.AddRangeAsync(entities);


             await DbContext.SaveChangesAsync();
            return entities;
        }
        public async Task<IEnumerable<FutureContract>> UpdateAsync(IEnumerable<FutureContract> entities)
        {
    
    
            DbContext.UpdateRange(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<FutureContract> CreateAsync(FutureContract entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<FutureContract>> GetByGenericFutureIdAsync(int genericFutureId)
        {
            return await DbContext
                .FutureContracts
                .Where(x => x.GenericFutureId == genericFutureId)
                 .Include(x => x.FutureContractNavigation)
                 .ThenInclude(x => x.Currency)
                 .Include(x => x.FutureContractNavigation)
                 .ThenInclude(x => x.InstrumentType)
                 .Include(x => x.FutureContractNavigation)
                 .ThenInclude(x => x.Exchange)
                 .Include(x => x.FutureContractNavigation)
                 .ThenInclude(x => x.MarketSector)
                 .ToListAsync();
                 
        }
    }
}
