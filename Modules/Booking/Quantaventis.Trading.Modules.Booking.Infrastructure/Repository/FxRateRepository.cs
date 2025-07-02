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
    internal class FxRateRepository : IFxRateRepository
    {
     private   IFxRateDao FxRateDao { get; }

        public FxRateRepository(IFxRateDao fxRateDao)
        {
            FxRateDao = fxRateDao;
        }

        public async Task<FxRate?> GetLastAsOfDateAsync(string baseCurrency, string quoteCurrency, DateTime date)
        {
            Entities.FxRate? fxRate = await FxRateDao.GetLastAsOfDateAsync(baseCurrency, quoteCurrency, date);
            return fxRate?.Map();
        }
    }
}
