using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Dao
{
    internal interface IEmsxOrderDao
    {
        Task<EmsxOrder?> GetByEmsxOrderIdAsync(int sequence);
        Task UpsertAsync(IEnumerable<EmsxOrder> entities);
        Task<EmsxOrder> CreateAsync(EmsxOrder entity);
        Task DeleteAsync(int orderId);
        Task UpdateAsync(EmsxOrder entity);
    }
    internal class EmsxOrderDao : IEmsxOrderDao
    {
        private ExecutionDbContext DbContext { get; }

        public EmsxOrderDao(ExecutionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



        public async Task UpsertAsync(IEnumerable<EmsxOrder> entities)
        {
            await DbContext.UpsertRange(entities).On(x => x.EmsxSequence).RunAsync();
        }
        public async Task<EmsxOrder> CreateAsync(EmsxOrder entity)
        {
            await DbContext.EmsxOrders
             .AddAsync(entity);
           await DbContext.SaveChangesAsync();
            return entity;
         }

        public async Task DeleteAsync(int orderId)
        {
             DbContext.EmsxOrders.Remove(new EmsxOrder() { EmsxSequence = orderId});
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmsxOrder entity)
        {
            
            DbContext.EmsxOrders.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task<EmsxOrder?> GetByEmsxOrderIdAsync(int sequence)
        {
           return await DbContext
                .EmsxOrders
                .AsNoTracking()
                .Where(x => x.EmsxSequence == sequence)
                .FirstOrDefaultAsync();
        }
    }
}
