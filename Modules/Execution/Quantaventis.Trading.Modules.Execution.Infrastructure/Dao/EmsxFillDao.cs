using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Dao
{
    internal interface IEmsxFillDao
    {
        Task<IEnumerable<EmsxFill>> GetByEmsxOrderIdAsync(int emsxOrderId);
        Task UpsertAsync(IEnumerable<EmsxFill> emsxFilla);
        Task<IEnumerable<EmsxFill>> GetByFillDateAsync(DateOnly fillDate);
    }
    internal class EmsxFillDao : IEmsxFillDao
    {
        private ExecutionDbContext DbContext { get; }

        public EmsxFillDao(ExecutionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



        public async Task UpsertAsync(IEnumerable<EmsxFill> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => new { x.OrderId, x.FillId })             
                .RunAsync();
        }

        public async Task<IEnumerable<EmsxFill>> GetByFillDateAsync(DateOnly fillDate)
        {
            
                return await DbContext.EmsxFills
                    .Where(x => DateOnly.FromDateTime(x.DateTimeOfFill) == fillDate)
                       .AsNoTracking()
                       .ToListAsync();
            
        }

        public async Task<IEnumerable<EmsxFill>> GetByEmsxOrderIdAsync(int emsxOrderId)
        {
            return await DbContext.EmsxFills
                     .Where(x => x.OrderId == emsxOrderId)
                        .AsNoTracking()
                        .ToListAsync();
        }
    }
}
