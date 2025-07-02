using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class CommissionRepository : ICommissionRepository
    {
     private ICommissionScheduleDao CommissionScheduleDao { get; }
        private IInstrumentDao InstrumentDao { get; }

        public CommissionRepository(ICommissionScheduleDao commissionScheduleDao, IInstrumentDao instrumentDao)
        {
            CommissionScheduleDao = commissionScheduleDao;
            InstrumentDao = instrumentDao;
        }

        public async Task<Commission?> GetAsync(int instrumentId, string executionBroker, int counterpartyRoleSetupId, string executionType)
        {
            Entities.Instrument? instrument = await InstrumentDao.GetByInstrumentIdAsync(instrumentId);
            Entities.CommissionSchedule? entity = null;
            if (instrument != null)
            {
                int definedInstrumentId = instrument.GenericFutureId != null ? instrument.GenericFutureId.Value : instrumentId;
                entity = await CommissionScheduleDao.GetAsync(definedInstrumentId, executionBroker, counterpartyRoleSetupId, executionType);

            }
         
            return entity?.MapToCommission();
        }
    }
}
