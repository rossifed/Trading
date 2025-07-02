using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ICounterpartyRoleSetupDao
    {
        Task<CounterpartyRoleSetup?> GetAsync(int portfolioId, int instrumentId, string executionBroker);
    }

    internal class CounterpartyRoleSetupDao : ICounterpartyRoleSetupDao
    {
        private BookingDbContext DbContext { get; }

        public CounterpartyRoleSetupDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }
  
        public async Task<CounterpartyRoleSetup?> GetAsync(int portfolioId, int instrumentId, string executionBroker)
        {
            Entities.Instrument? ins = await DbContext.Instruments.Where(x => x.InstrumentId == instrumentId).FirstOrDefaultAsync();
            if (ins != null)
            {
                int keyInstrument = ins.GenericFutureId != null ? ins.GenericFutureId.Value : ins.InstrumentId;

                var counterpartyRoleAssignment = await DbContext
                     .CounterpartyRoleAssignments
                     .AsNoTracking()
                     .Include(x => x.ExecutionBroker)
                     .Where(x => x.PortfolioId == portfolioId && x.InstrumentId == keyInstrument && x.ExecutionBroker.Code == executionBroker)
                    .Include(x => x.CounterpartyRoleSetup)
                    .ThenInclude(x => x.PrimeBroker)
                     .Include(x => x.CounterpartyRoleSetup)
                    .ThenInclude(x => x.ClearingBroker)
                     .Include(x => x.CounterpartyRoleSetup)
                    .ThenInclude(x => x.Custodian)
                     .FirstOrDefaultAsync();

                return counterpartyRoleAssignment?.CounterpartyRoleSetup;
            }
            return null;

        }
    }
}
