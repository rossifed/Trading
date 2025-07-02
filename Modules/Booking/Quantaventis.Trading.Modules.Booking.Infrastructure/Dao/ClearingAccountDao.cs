using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IClearingAccountDao
    {
        Task<ClearingAccount?> GetAsync(int portfolioId, string tradeInstrumentType, int clearingBrokerId);

    }

    internal class ClearingAccountDao : IClearingAccountDao
    {
        private BookingDbContext DbContext { get; }

        public ClearingAccountDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ClearingAccount?> GetAsync(int portfolioId, string tradeInstrumentType, int clearingBrokerId)
        {
            return await DbContext
            .ClearingAccounts
            .AsNoTracking()
            .Include(x=>x.TradeInstrumentType)
            .Include(x=>x.ClearingBroker)
            .Where(x => x.PortfolioId == portfolioId
                 && x.TradeInstrumentType.Mnemonic== tradeInstrumentType
                 && x.ClearingBrokerId == clearingBrokerId)
            .FirstOrDefaultAsync();
        }
    }
}
