using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ISettlementInfoDao
    {
        Task<SettlementInfo?> GetByCounterpartyAndInstrumentAsync(int counterpatyId, int instrumentId,bool isSwap);

    }

    internal class SettlementInfoDao : ISettlementInfoDao
    {
        private BookingDbContext DbContext { get; }
        public SettlementInfoDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<SettlementInfo?> GetByCounterpartyAndInstrumentAsync(int counterpartyId, int instrumentId, bool isSwap)
        {
            // First attempt to find a matching SettlementInfo via InstrumentId matching the provided instrumentId

            Entities.Instrument? ins = await DbContext.Instruments.Where(x => x.InstrumentId == instrumentId).FirstOrDefaultAsync();
            if (ins != null) {
                int keyInstrument = ins.GenericFutureId != null? ins.GenericFutureId.Value: ins.InstrumentId;
                return await DbContext
                    .SettlementInfos
                    .AsNoTracking()
                    .Include(i => i.Instrument)
                    .ThenInclude(i => i.InverseGenericFuture)
                     .Where(x => x.CounterpartyId == counterpartyId
                      && x.InstrumentId == keyInstrument
                      && x.IsSwap == isSwap)
                    .FirstOrDefaultAsync();
            }
            return null;
        }

    }
}
