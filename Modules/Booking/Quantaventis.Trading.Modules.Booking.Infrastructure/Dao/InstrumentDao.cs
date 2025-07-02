using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
        Task<Instrument?> GetBySymbolAsync(string symbol);
        Task<Instrument?> GetByInstrumentIdAsync(int instrumentId);
    }

    internal class InstrumentDao : IInstrumentDao
    {
        private BookingDbContext DbContext { get; }

        public InstrumentDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Instrument?> GetBySymbolAsync(string symbol)
        {
            return await DbContext
                 .Instruments
                 .AsNoTracking()
                 .Where(x => x.Symbol == symbol)
                 .FirstOrDefaultAsync();
        }

        public async Task<Instrument?> GetByInstrumentIdAsync(int instrumentId)
        {
            return await DbContext
               .Instruments
               .AsNoTracking()
               .Where(x => x.InstrumentId == instrumentId)
               .FirstOrDefaultAsync();
        }
    }
}
