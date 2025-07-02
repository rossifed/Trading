using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IFutureSwapDao
    {
        Task<FutureSwap?> GetAsync(int genericFutureId, int executionBrokerId);

    }

    internal class FutureSwapDao : IFutureSwapDao
    {
        private BookingDbContext DbContext { get; }

        public FutureSwapDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

 

        public async Task<FutureSwap?> GetAsync( int genericFutureId, int executionBrokerId)
        {
            return await DbContext
           .FutureSwaps
           .AsNoTracking()
           .Where(x => x.ExecutionBrokerId == executionBrokerId && x.GenericFutureId == genericFutureId)
           .FirstOrDefaultAsync();
        }
    }
}
