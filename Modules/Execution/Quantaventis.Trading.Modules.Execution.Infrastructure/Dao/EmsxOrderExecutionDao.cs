using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Dao
{
    internal interface IEmsxOrderExecutionDao
    {
        Task<VwEmsxOrderExecution?> GetByOrderIdAsync(int orderId);
    }
    internal class EmsxOrderExecutionDao : IEmsxOrderExecutionDao
    {
        private ExecutionDbContext DbContext { get; }

        public EmsxOrderExecutionDao(ExecutionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<VwEmsxOrderExecution?> GetByOrderIdAsync(int orderId)
        {         
                return await DbContext.VwEmsxOrderExecutions
                    .Where(x => x.OrderId == orderId)
                       .AsNoTracking()
                       .FirstOrDefaultAsync();           
        }
    }
}
