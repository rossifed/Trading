using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IExecutionDeskDao
    {
        Task<ExecutionDesk?> GetByCodeAsync(string code);

    }

    internal class ExecutionDeskDao : IExecutionDeskDao
    {
        private BookingDbContext DbContext { get; }

        public ExecutionDeskDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<ExecutionDesk?> GetByCodeAsync(string code)
        {
           return await DbContext
                .ExecutionDesks
                .AsNoTracking()
                .Where(x => x.Code == code)
                .Include(x=>x.ExecutionBroker)
                .FirstOrDefaultAsync();
        }
    }
}
