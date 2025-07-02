using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class ClearingAccountRepository : IClearingAccountRepository
    {
        private IClearingAccountDao ClearingAccountDao { get; }

        public ClearingAccountRepository(IClearingAccountDao clearingAccountDao)
        {
            ClearingAccountDao = clearingAccountDao;
        }

  
        public async Task<Account?> GetAsync(int portfolioId, string tradeInstrumentType, int clearingBrokerId)
        {
            Entities.ClearingAccount? entity = await ClearingAccountDao.GetAsync(portfolioId, tradeInstrumentType, clearingBrokerId);
            return entity?.Map();
        }
    }
}
