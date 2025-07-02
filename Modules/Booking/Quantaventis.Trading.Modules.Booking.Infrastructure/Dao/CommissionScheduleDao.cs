using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ICommissionScheduleDao
    {
        Task<CommissionSchedule?> GetAsync(int instrumentId, string executionBroker, int counterpartyRoleSetupId, string executionType);
    }

    internal class CommissionScheduleDao : ICommissionScheduleDao
    {
        private BookingDbContext DbContext { get; }

        public CommissionScheduleDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<CommissionSchedule?> GetAsync(int instrumentId, string executionBroker, int counterpartyRoleSetupId, string executionType)
        {
            Entities.Instrument? ins = await DbContext.Instruments.Where(x => x.InstrumentId == instrumentId).FirstOrDefaultAsync();
            if (ins != null)
            {
                int keyInstrument = ins.GenericFutureId != null ? ins.GenericFutureId.Value : ins.InstrumentId;
                return await DbContext
              .CommissionSchedules
              .AsNoTracking()
              .Include(x => x.ExecutionBroker)
              .Include(x => x.ExecutionType)
              .Include(x => x.CommissionType)
              .Include(x => x.ExecutionType)
              .Include(x => x.Instrument)
              .Where(x => x.InstrumentId == keyInstrument
              && x.ExecutionBroker.Code == executionBroker
              && x.CounterpartyRoleSetupId == counterpartyRoleSetupId
              && x.ExecutionType.Code == executionType)
              .FirstOrDefaultAsync();
            } return null;
        }
    }
}
