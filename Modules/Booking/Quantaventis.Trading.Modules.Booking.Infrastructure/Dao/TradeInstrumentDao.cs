using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ITradeInstrumentTypeDao
    {
        Task<TradeInstrumentType?> GetAsync(string instrumentType, bool isSwap);

    }

    internal class TradeInstrumentTypeDao : ITradeInstrumentTypeDao
    {
        private BookingDbContext DbContext { get; }

        public TradeInstrumentTypeDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<TradeInstrumentType?> GetAsync(string instrumentType, bool isSwap)
        {
            return await DbContext
             .TradeInstrumentTypes
             .AsNoTracking()
             .Where(x => x.InstrumentType == instrumentType && x.IsSwap == isSwap)
             .FirstOrDefaultAsync();
        }
    }
}
