using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IMarketSectorDao
    {
        Task<IEnumerable<MarketSector>> GetAllAsync();
        Task<MarketSector> SaveAsync(MarketSector entity);

    }
    internal class MarketSectorDao : IMarketSectorDao
    {
        private InstrumentsDbContext DbContext { get; }

        public MarketSectorDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     

       public async Task<IEnumerable<MarketSector>> GetAllAsync()
        {
            return await DbContext.MarketSectors
                .AsNoTracking()
                    .ToListAsync();
        }

       public async Task<MarketSector> SaveAsync(MarketSector entity)
        {
            if (entity.MarketSectorId <= 0)
                await DbContext.AddAsync(entity);
            else
                DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
