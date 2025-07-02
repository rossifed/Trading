using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class CounterpartyRoleSetupRepository : ICounterpartyRoleSetupRepository
    {
     private   ICounterpartyRoleSetupDao CounterpartyRoleSetupDao { get; }

        public CounterpartyRoleSetupRepository(ICounterpartyRoleSetupDao counterpartyRoleSetupDao)
        {
            CounterpartyRoleSetupDao = counterpartyRoleSetupDao;
        }
    

        public async Task<CounterpartyRoleSetup?> GetAsync(int portfolioId, int instrumentId, string executionBroker)
        {
            var entity = await CounterpartyRoleSetupDao.GetAsync(portfolioId, instrumentId, executionBroker);
            return entity?.Map();
        }
    }
}
