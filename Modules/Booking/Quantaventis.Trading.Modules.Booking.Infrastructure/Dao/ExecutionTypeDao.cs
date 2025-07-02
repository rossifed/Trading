using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IExecutionTypeDao
    {
        Task<ExecutionType?> GetExecutionTypeAsync(int ExecutionDeskId, string strategy);

    }

    internal class ExecutionTypeDao : IExecutionTypeDao
    {
        private BookingDbContext DbContext { get; }

        public ExecutionTypeDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ExecutionDesk?> GetBySymbolAsync(string code)
        {
           return await DbContext
                .ExecutionDesks
                .AsNoTracking()
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<ExecutionType?> GetExecutionTypeAsync(int executionDeskId, string strategy)
        {

            var execTypeMapping =  await DbContext
             .ExecutionTypeMappings
             .AsNoTracking()
             .Include(x => x.ExecutionType)
             .Where(x => x.ExecutionDeskId == executionDeskId && x.Strategy == strategy)         
             .FirstOrDefaultAsync();
            return execTypeMapping?.ExecutionType;
        }
    }
}
