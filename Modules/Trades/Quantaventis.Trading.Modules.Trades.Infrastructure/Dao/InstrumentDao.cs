using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
        Task CreateAsync(Instrument entity);
        Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds);

        Task<IEnumerable<Instrument>> GetAllAsync();
    }
    internal class InstrumentDao : IInstrumentDao
    {
        private TradesDbContext DbContext { get; }

        public InstrumentDao(TradesDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        //TODO: manage in clause limitation!! also in other dao of the project using batch requests
        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => instrumentIds.Contains(x.InstrumentId))                 
                              .Distinct()
                              .ToListAsync();
        }
        public async Task<IEnumerable<Instrument>> GetAllAsync()
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Distinct()
                              .ToListAsync();
        }
        public async Task CreateAsync(Instrument entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
