using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
        Task CreateAsync(Instrument entity);
        Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds);
    }
    internal class InstrumentDao : IInstrumentDao
    {
        private OrdersDbContext DbContext { get; }

        public InstrumentDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        //TODO: manage in clause limitation!! also in other dao of the project using batch requests
        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => instrumentIds.Contains(x.InstrumentId))
                              .Include(x=>x.InstrumentType)
                  
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
